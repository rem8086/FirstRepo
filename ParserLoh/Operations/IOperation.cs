using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser
{
    /*интерфейс для выполнения арифметических
*/
    
    interface IOperation
    {
        int Arity
        {
            get;
        }

        double Execute(ArrayList operands);
    }
}
