using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser.Operations
{
    class OperationSinus: IOperation
    {
        public int Arity
        {
            get { return 1; }
        }

        public double Execute(ArrayList operands)
        {
            return Math.Sin((double)operands[0]);
        }
    }
}
