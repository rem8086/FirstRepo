using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserLoh
{
    /*
     * класс ставит пробелы между лексемами, чтобы удобней анализировать было 
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
            bool specMinusFlag = false;
            //InputString = InputString.Replace(" ",string.Empty);
            InputString = DecimalSeparatorReplace(InputString);
            for (int i = 0; i < InputString.Length; i++)
            {
                if ((ac.PARTSOFNUMBERSET.Contains(InputString[i])) | (ac.PARTSOFVARIABLESET.Contains(InputString[i])))
                {
                    if ((ac.PARTSOFSTATEMENTS.Contains(InputString[i])) && (specMinusFlag == true))
                    {
                        OutputString += " " + InputString[i] + " ";
                        specMinusFlag = false;
                    }
                    else
                    {
                        OutputString += InputString[i];
                        specMinusFlag = true;
                    }
                    continue;
                }
                if (ac.PARTSOFSTATEMENTS.Contains(InputString[i]))
                {
                    OutputString += " " + InputString[i] + " ";
                    specMinusFlag = false;
                }
                if (InputString[i] == ' ') { OutputString += " "; }
                if (!((ac.PARTSOFNUMBERSET.Contains(InputString[i]))|
                    (ac.PARTSOFVARIABLESET.Contains(InputString[i]))|
                    (ac.PARTSOFSTATEMENTS.Contains(InputString[i]))| InputString[i]==' '))
                { OutputString = ""; return; }
            }
            OutputString = OutputString.Replace("   ", " "); 
            OutputString = OutputString.Replace("  ", " "); 
            OutputString = OutputString.Trim();
        }

        public string GetOutputString()
        {
            return OutputString;
        }

        string DecimalSeparatorReplace(string str) // замена разделителя на обрабатываемый Convert.ToDecimal()
        {
            char decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
            if (decimalSeparator == '.')
            {
                return str.Replace(',', decimalSeparator);
            } else
            {
                return str.Replace('.', decimalSeparator);
            }
        }


    }
}
