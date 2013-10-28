using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserLoh.Operations
{
    class OperationTangens: IOperation
    {
        public int Arity
        {
            get { return 1; }
        }

        public double Execute(ArrayList operands)
        {
            return Math.Tan((double)operands[0]);
        }
    }
}
