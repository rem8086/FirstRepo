using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace ParserLoh
{
    /*
     * алгоритм вычисления выражения,
     * записанного обратной польской записью
     */

    struct Variable // здесь создана структура, для хранения переменной и ее обозначения
    {
        public string var;
        public double value;
        public Variable(string v, double val)
        {
            var = v;
            value = val;
        }
    }
    
    class ReversePolish
    {
        private string InputString;
        public double Result;
        public ArrayList VariableSet;   // массив переменных
        ArrayList tokenArray;           //массив всех кусков формулы (числа, переменные, операторы)
        Stack<double> polishStack;      //вспомогательный стек алгоритма
        AlphabetConst ac;               //алфавит заного определяется зачем-то

        public ReversePolish(string str)
        {
            VariableSet = new ArrayList();
            InputString = str;
            ac = new AlphabetConst();
            tokenArray = new ArrayList();
            StringLikeArray sla = new StringLikeArray();
            tokenArray = sla.CreateArray(InputString);   //разодрали формулу на лексемы
            polishStack = new Stack<double>();
        }

        public bool VariableCollect()      //по алфавиту вычленяются переменные из формулы
        {                                  //ага, а значения им потом когда захотят присвоят 
            for (int i = 0; i < tokenArray.Count; i++)
            {
                if (ac.IsVariable((string)tokenArray[i]))
                {
                    bool alreadyExists = false;
                    foreach (Variable var in VariableSet)
                    {
                        if (var.var == (string)tokenArray[i]) { alreadyExists = true; }
                    }
                    if (!alreadyExists)
                    {
                        Variable variable = new Variable();
                        variable.var =(string)tokenArray[i];
                        VariableSet.Add(variable);
                    } 
                }
            }
            return VariableSet.Count != 0 ? true: false;
        }

        public void Calculate ()    //сам алгоритм. тут хреново как проверяется чем является лексема
        {                           //(число, переменная или оператор) ну и жеско на бинарные операции забито
            for (int i = 0; i < tokenArray.Count; i++) // не, тут норм уже все - все траблы вынесены в другие места
            {
                string token = (string)(tokenArray[i]);

                foreach (Variable var in VariableSet)
                {
                    if (token == var.var) { polishStack.Push(var.value); }
                }

                if (ac.IsNumber(token)) { polishStack.Push(Convert.ToDouble(token)); }

                Statement statement = ac.IsStatement(token);
                if (statement != null)
                {
                    ArrayList operands = new ArrayList();
                    for (int j = 0; j < statement.operationType.Arity; j++)
                    {
                        operands.Add(polishStack.Pop());
                    }
                    OperationContext context = new OperationContext(statement.operationType);
                    polishStack.Push(context.Execute(operands));
                }
            }
            Result = polishStack.Pop();
        }

        
    }
}
