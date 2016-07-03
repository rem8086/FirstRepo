using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser
{
    public class FormulaCalculate
    {

        public static double Calculate(string formula)
        {
            StringLikeArray sla = new StringLikeArray();
            SpaceInserter si = new SpaceInserter(formula.Replace(",","."));
            si.InsertSpaces();
            ShuntingYard sy = new ShuntingYard(si.GetOutputString());
            sy.StringAnalys();
            ReversePolish rp = new ReversePolish(sy.ReturnReversePolish());
            rp.Calculate();
            return rp.Result;
        }
    }
}
