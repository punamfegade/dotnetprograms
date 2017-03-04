using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindMaxWord
{
    class Program
    {
       static void Main(string[] args)
        {
            string S = "We test coders. Give us a try?";
            int MaxWords = FindMaxWords(S);
            Console.WriteLine(MaxWords);
        }
        public static int FindMaxWords(string s)
        {
            int TotalWords = 0;
            int maxWords = 0;
            int temp = 0;
           
            String[] splitChars = new String[] { ".", "?", "!" };

            foreach (String words in s.Split(splitChars, StringSplitOptions.None))
            {

                maxWords = words.Trim().Split(' ').Count();

                if (maxWords > temp)
                {
                    TotalWords = maxWords;
                    temp = maxWords;
                }
            }
            return TotalWords;
        }
    }
    
}
