using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace ParserLoh.Operations
{
    class OperationCosinus: IOperation
    {
        public int Arity
        {
            get { return 1; }
        }

        public double Execute(ArrayList operands)
        {
            return Math.Cos((double)operands[0]);
        }
    }
}
