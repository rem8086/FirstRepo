using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser
{
    /*
     * алгоритм сортировочной станции
     * для привидения формулы к виду польской записи
     */

    class ShuntingYard
    {
        private string InputString;
        private string OutputString;
        private Stack<string> SYStack;
        AlphabetConst ac;

        public ShuntingYard(string str)
        {
            InputString = str;
            ac = new AlphabetConst();
            SYStack = new Stack<string>();
        }

        public void StringAnalys() 
        {
            SpaceInserter si = new SpaceInserter(InputString);
            si.InsertSpaces();
            InputString = si.GetOutputString(); // с пробелами разбираемся

            if (!(new CorrectFormula(InputString).IsCorrect())) { OutputString = ""; return; } // проверка на допустимость формулы
            if (InputString.Length == 0) { OutputString = ""; return; }

            StringLikeArray sla = new StringLikeArray();
            ArrayList tokenList = new ArrayList();
            tokenList = sla.CreateArray(InputString); // разбили строку на массив лексем
            for (int i = 0; i < tokenList.Count; i++)
            {
                if (ac.IsNumber((string)tokenList[i]) | ac.IsVariable((string)tokenList[i])) 
                {
                    OutputString += tokenList[i] + " "; // если строка или переменная, то записали в выходную строку
                }
                Statement currentStatement = ac.IsStatement((string)tokenList[i]); // а вот если оператор...
                if (currentStatement != null)
                {
                    if (currentStatement.st == StateType.isOpen) // открывающую скобку сразу в стек
                    {
                        SYStack.Push(currentStatement.symbol);
                    }
                    if (currentStatement.st == StateType.isClose) // если закрывающая, то достаем все из стека в выходную строку
                    {
                        string str = SYStack.Pop(); while (ac.IsStatement(str).st != StateType.isOpen) { OutputString += str + " "; str = SYStack.Pop(); }
                    }
                    if ((currentStatement.st == StateType.isStatementLeft) | (currentStatement.st == StateType.isStatementRight))
                    {                       // если на вершине стека более крутая операция чем новая, то перенесли ее в выходную строку
                        bool doIt = true;   // если менее крутая, то текущую в стек скинули
                        while (doIt)
                        {
                            if (SYStack.Count == 0) { SYStack.Push(currentStatement.symbol); doIt = false; }
                            else
                            {
                                string top = SYStack.Peek();
                                if ((currentStatement.priority > ac.IsStatement(top).priority & currentStatement.st == StateType.isStatementLeft) | 
                                    (currentStatement.priority >= ac.IsStatement(top).priority & currentStatement.st == StateType.isStatementRight))
                                {
                                    SYStack.Push(currentStatement.symbol);// текущую воткнули в стек
                                    doIt = false;
                                }
                                else
                                {
                                    OutputString += SYStack.Pop() + " "; 
                                }
                            }
                        }
                    }
                }
            }
            while (SYStack.Count > 0) { OutputString += SYStack.Pop() + " "; }
            OutputString = OutputString.Trim();
        }

        public string ReturnReversePolish()
        {
            return OutputString;
        }

    }
}
