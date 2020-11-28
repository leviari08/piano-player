using System;
using System.Linq;

namespace PianoPlayer
{
    public static class Utils
    {
        public static string nSpaces(int n)
        {
            return new string(' ', n);
        }

        public static string ExtendEachCharWith(this string s, string mix)
        {
            string res = "";
            foreach (char c in s)
            {
                res += c + mix;
            }
            return res;
        }

        public static string Repeat(this string s, int times)
        {
            //return string.Concat(Enumerable.Repeat(s, times));

            string res = "";
            for (int i = 0; i < times; i++)
            {
                res += s;
            }
            return res;
        }
    }
}
