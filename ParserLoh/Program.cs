using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserLoh
{

    class Program
    {
        static void Main(string[] args)
        {
            //StringLikeArray sla = new StringLikeArray();
            Console.WriteLine("Введите формулу:");
            //SpaceInserter si = new SpaceInserter(Console.ReadLine());
            //si.InsertSpaces();
            ShuntingYard sy = new ShuntingYard(Console.ReadLine());//si.GetOutputString());
            sy.StringAnalys();
            Console.WriteLine("Обратная польская запись:");
            Console.WriteLine(sy.ReturnReversePolish());
            Console.ReadLine();
            ReversePolish rp = new ReversePolish(sy.ReturnReversePolish());
            if (!rp.VariableCollect())
            {
                Console.WriteLine("Переменных не обнаружено");
            }
            else
            {
                Console.WriteLine("Введите значения переменных:");
            }
            for (int i = 0; i < rp.VariableSet.Count; i++)
            {
                Variable v = (Variable)(rp.VariableSet[i]);
                Console.Write(v.var + " = ");
                v.value = Convert.ToDouble(Console.ReadLine());
                rp.VariableSet[i] = v;
            }
            rp.Calculate();
            Console.WriteLine("Результат: " + rp.Result);
            Console.ReadLine();
        }
    }
}
