using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserLoh
{
    class OperationSubtract : IOperation
    {
        public int Arity
        {
            get { return 2; }
        }

        public double Execute(ArrayList operands)
        {
            return (double)operands[1] - (double)operands[0];
        }
    }
}
