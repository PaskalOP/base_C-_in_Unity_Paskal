using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Maze
{
    public static class  ExtensionString
    {
        public static String ExtenString(this string str)
        {
           // char[] arrChar;

           // arrChar = str.ToCharArray();
           int count = str.Length;
            string massage = ("Количество знаков в строке: " + count);
            return massage;

        }
    }
}

