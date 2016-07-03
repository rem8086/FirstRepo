using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParserLoh.Operations;

namespace ParserLoh
{
    /* класс, реализующий алфавит программы
     * указываются символы чисел, символы переменных, символы операторов
    */

    class AlphabetConst
    {
        public List<Char> PARTSOFNUMBERSET = new List<Char>();
        public List<Char> PARTSOFVARIABLESET = new List<Char>();
        public List<Char> PARTSOFSTATEMENTS = new List<Char>();
        public List<Statement> STATEMENTSSET = new List<Statement>();

        public AlphabetConst()
        {
            for (int i = 48; i < 58; i++)
            {
                PARTSOFNUMBERSET.Add((char)i);
            }
            PARTSOFNUMBERSET.Add(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0]);
            PARTSOFNUMBERSET.Add((char)'-');
            for (int i = 65; i < 91; i++)
            { 
                PARTSOFVARIABLESET.Add((char)i);
            }
            for (int i = 97; i < 123; i++)
            { 
                PARTSOFVARIABLESET.Add((char)i);
            }
            PARTSOFSTATEMENTS.Add((char)'+');
            PARTSOFSTATEMENTS.Add((char)'-');
            PARTSOFSTATEMENTS.Add((char)'*');
            PARTSOFSTATEMENTS.Add((char)'/');
            PARTSOFSTATEMENTS.Add((char)'^');
            PARTSOFSTATEMENTS.Add((char)'(');
            PARTSOFSTATEMENTS.Add((char)')');
            PARTSOFSTATEMENTS.Add((char)'!');
            Statement plus = new Statement("+", 1, StateType.isStatementLeft);
                plus.operationType = new OperationPlus(); STATEMENTSSET.Add(plus);
            Statement minus = new Statement("-", 1, StateType.isStatementLeft);
                minus.operationType = new OperationSubtract(); STATEMENTSSET.Add(minus);
            Statement multiply = new Statement("*", 2, StateType.isStatementLeft);
                multiply.operationType = new OperationMultiply(); STATEMENTSSET.Add(multiply);
            Statement divide = new Statement("/", 2, StateType.isStatementLeft);
                divide.operationType = new OperationDivision(); STATEMENTSSET.Add(divide);
            Statement degree = new Statement("^", 4, StateType.isStatementRight);
                degree.operationType = new OperationDegree(); STATEMENTSSET.Add(degree);
            Statement factorial = new Statement("!", 5, StateType.isStatementLeft);
                factorial.operationType = new OperationFactorial(); STATEMENTSSET.Add(factorial);
            Statement sinus = new Statement("sin", 3, StateType.isStatementRight);
                sinus.operationType = new OperationSinus(); STATEMENTSSET.Add(sinus);
            Statement cosinus = new Statement("cos", 3, StateType.isStatementRight);
                cosinus.operationType = new OperationCosinus(); STATEMENTSSET.Add(cosinus);
            Statement unaryminus = new Statement("~", 3, StateType.isStatementRight);
                unaryminus.operationType = new OperationUnaryMinus(); STATEMENTSSET.Add(unaryminus);
            Statement openBracket = new Statement("(", 0, StateType.isOpen); STATEMENTSSET.Add(openBracket);
            Statement closeBracket = new Statement(")", 0, StateType.isClose); STATEMENTSSET.Add(closeBracket);
        }

        public bool IsNumber(string token)
        {
            bool isNumber = true;
            for (int i = 0; i < token.Length; i++)
            {
                if (!PARTSOFNUMBERSET.Contains((char)token[i])) { isNumber = false; }
            }
            if (IsStatement(token) != null) {isNumber = false;}
            return isNumber;
        }

        public Statement IsStatement(string token)
        {
            foreach (Statement state in STATEMENTSSET)
            {
                if (state.symbol == token) { return state; }
            }
            return null;
        }

        public bool IsVariable(string token)
        {
            bool isVariable=false;
            for (int i = 0; i < token.Length; i++)
            {
                if (PARTSOFVARIABLESET.Contains((char)token[i])) { isVariable = true; }
            }
            if (IsStatement(token) != null) { isVariable = false; }
                //если есть из алфавита переменных и IsStatement возвращает null
            return isVariable;
        }
    }
}
