﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser
{
    /* класс, через который другие классы будут работать
     * с интерфейсом выполнения операций
     *  стратегия типа*/

    class OperationContext
    {
        IOperation operation;

        public OperationContext(IOperation operation)
        {
            this.operation = operation;
        }

        public double Execute(ArrayList operands)
        {
            return operation.Execute(operands);
        }
    }
}
