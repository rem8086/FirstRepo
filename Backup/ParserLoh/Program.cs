using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserLoh
{
    /*
     *сделать возможность введения унарных операций DONE (изменен интерфейс - в качестве параметра ArrayList, добавлена арность - проверяется при вычислении
     *                                                  на основании ее заполняется массив для  интерфейса)
     *переделать подчистую алгоритм парсинга (SpaceInserter)
     *реализовать поддержку отрицательных чисел
     *как-то дописать про операции, входящие в алфавит переменных DONE
    */

    class Program
    {
        static void Main(string[] args)
        {
            StringLikeArray sla = new StringLikeArray();
            Console.WriteLine("Введите формулу:");
            SpaceInserter si = new SpaceInserter(Console.ReadLine());
            si.InsertSpaces();
            ShuntingYard sy = new ShuntingYard(si.GetOutputString());
            sy.StringAnalys();
            Console.WriteLine("Обратная польская запись:");
            Console.WriteLine(sy.ReturnReversePolish());
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
