using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserLoh
{
    /*интерфейс для выполнения арифметических
     * действий над числами 
     * пока работает только с бинарными операциями - и это печально*/
    
    interface IOperation
    {
        int Arity
        {
            get;
        }

        double Execute(ArrayList operands);
    }
}
