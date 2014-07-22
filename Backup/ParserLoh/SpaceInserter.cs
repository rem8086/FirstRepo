using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserLoh
{
    /*
     * класс ставит пробелы между лексемами, чтобы удобней анализировать было - полностью переделывать на строку
     */

    class SpaceInserter
    {
        AlphabetConst ac;
        private string InputString;
        private string OutputString;

        public SpaceInserter(string str)
        {
            InputString = str;
            ac = new AlphabetConst();
        }

        public void InsertSpaces()
        {
            //InputString = InputString.Replace(" ",string.Empty);
            for (int i = 0; i < InputString.Length; i++)
            {
                if ((ac.PARTSOFNUMBERSET.Contains(InputString[i])) | (ac.PARTSOFVARIABLESET.Contains(InputString[i])))
                {
                    OutputString += InputString[i]; 
                }
                if (ac.PARTSOFSTATEMENTS.Contains(InputString[i]))
                {
                    OutputString += " " + InputString[i] + " "; 
                }
                if (InputString[i] == ' ') { OutputString += " "; }
                if (!((ac.PARTSOFNUMBERSET.Contains(InputString[i]))|
                    (ac.PARTSOFVARIABLESET.Contains(InputString[i]))|
                    (ac.PARTSOFSTATEMENTS.Contains(InputString[i]))| InputString[i]==' '))
                { OutputString = ""; return; }
            }
            OutputString = OutputString.Replace("   ", " "); // это пиздец голимый
            OutputString = OutputString.Replace("  ", " "); // это пиздец голимый
            OutputString = OutputString.Trim();
        }

        public string GetOutputString()
        {
            return OutputString;
        }


    }
}
