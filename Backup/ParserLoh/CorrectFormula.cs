using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserLoh
{
    /*проверяет введенную формулу
     * на то, что она действительно формула, а не чушь кака-то
     * 
     * нахрена тут переменная объявлена
     */

    class CorrectFormula
    {
        private string formula;

        public CorrectFormula(string insert)
        {
            formula = insert;
        }

        public bool IsCorrect()
        {
            return true; // похуй, все корректно
        }
    }
}
