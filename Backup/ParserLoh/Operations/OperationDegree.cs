using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserLoh.Operations
{
    class OperationDegree : IOperation
    {
        public int Arity
        {
            get { return 2; }
        }

        public double Execute(ArrayList operands)
        {
            double b = (double) operands[0];
            double a = (double)operands[1];
            return System.Math.Exp(b*System.Math.Log(a));
        }
    }
}
