using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Parser
{
    class StringLikeArray // класс содержит функцию, разбивающую строку на элементы по пробелам
    {
        public ArrayList CreateArray(string inputString)
        {
            ArrayList arrList = new ArrayList();
            inputString += " ";
            int tokenStart = 0;
            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] == ' ')
                {
                    arrList.Add(inputString.Substring(tokenStart,i-tokenStart));
                    tokenStart = i + 1;
                }
            }
            return UnaryMinusReplace(arrList);
        }

        public ArrayList UnaryMinusReplace(ArrayList ar)
        {
            AlphabetConst ac = new AlphabetConst();
            if ((string)ar[0] == "-") ar[0] = "~";
            for (int i = 1; i < ar.Count; i++)
            {
                if (ar[i]=="-") 
                {
                    Statement stat = ac.IsStatement((string)ar[i-1]);
                    if ((stat!=null)&&stat.symbol!=")") ar[i] = "~";
                }
            }
            return ar;
        }
    }
}
