using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace ParserLoh
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
            return arrList;
        }
    }
}
