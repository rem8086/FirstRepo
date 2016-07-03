using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser.Operations
{
    class OperationFactorial: IOperation
    {
        public int Arity
        {
            get { return 1; }
        }

        public double Execute(ArrayList operands)
        {
            return (double) operands[0]; //дописать 
        }
    }
}
