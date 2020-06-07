using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
/*
Определить сколько раз самое длинное слово встретилось в тексте. Сформировать новую строку типа StringBuilder из слов, заключенных в скобки.
Разделителями слов считать пробел, точку, запятую или символ конца строки.
Исходную строку не вводить, а задавать в виде константы.
*/
namespace HomeWork7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string stroka = "hello\0(friend), animal. (actually) (certainly), (write) actually. (Hello)\0write, certainly";
            string wordPattern = @"[,.\0\s]+";
            Regex wordRegax = new Regex(wordPattern);
            Console.WriteLine("Исходная строка : "+stroka);
            string[] words = wordRegax.Split(stroka);
            string maxWord = null;
            maxWord=(FindMaxWord(words));
            int countOfCoinc=NumberOfCoincidences(words, maxWord);
            string bout = " раз";
            Console.WriteLine("Самое длинное слово (" + maxWord + ") встречается " + countOfCoinc + Bout(countOfCoinc, ref bout));
            StringBuilder newStroka = new StringBuilder();
            Console.WriteLine("Новая строка : " + newStr(words,newStroka));
            Console.ReadKey();
        }
        static string Bout(int number,ref string bout)
        {
            if (number >= 2 && number <= 4)
            {
                bout = " раза";
                return bout;
            }
            else
                return bout;
        }
        static string FindMaxWord(string[] words)
        {
            int max = 0;
            int count;
            StringBuilder str=new StringBuilder();
            str.Append(words[0]);
            for (int i = 0; i < words.Length; i++)
            {
                count = 0;
                for(int j=0;j<words[i].Length;j++)
                {
                    if (words[i][j] == '(' || words[i][j] == ')')
                        continue;
                    else
                        count++;
                }
                if (count > max)
                {
                    str.Remove(0, str.Length);
                    str.Append(words[i]);
                }
                   
            }
            return str.ToString();
        }
        static int NumberOfCoincidences(string[] words,string model)
        {
            int count = 0;
            StringBuilder str = new StringBuilder();
            for(int i=0;i<words.Length;i++)
            {
                for(int j=0;j<words[i].Length;j++)
                {
                    if (words[i][j] == '(' || words[i][j] == ')')
                        continue;
                    else
                        str.Append(words[i][j]);
                }
                if (str.ToString() == model)
                    count++;
                str.Remove(0,str.Length);
            }
            return count;
        }  
        static StringBuilder newStr(string[] words,StringBuilder str)
        {
            bool flag;
            for(int i=0;i<words.Length;i++)
            {
                flag = false;
                for(int j=0;j<words[i].Length;j++)
                {
                    if(words[i][j]=='(')
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                    str.Append(words[i]);
            }
            return str;
        }
    }
}
