using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserLoh
{
    public enum StateType { isOpen, isClose, isStatementLeft, isStatementRight }; //скобки либо оператор
    
    /*бессмысленный класс в который сохраняется информация
     * по операторам
     * чтобы и приоритет можно было задать и прописать что
     * за действие будет выполняться при встрече этого символа*/

    class Statement
    {
        
        public int priority;    //приоритет оператора
        public string symbol;     //оператор (заменил с чара на стринг, чтобы на будущее всякую тригонометрию захерачить)
        public StateType st;    
        public IOperation operationType;    // какое действие будет выполнять оператор

        public Statement(string ch)
        {
            symbol = ch;
        }
        public Statement(string ch, int pr)
        {
            symbol = ch; priority = pr;
        }
        public Statement(string ch, int pr, StateType stt)
        {
            symbol = ch; priority = pr; st = stt;
        }
    }
}
