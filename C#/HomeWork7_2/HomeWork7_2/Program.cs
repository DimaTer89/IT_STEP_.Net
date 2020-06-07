using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
/*Заменить все большие буквы в исходной строке маленькими. После каждого слова вставить символ $. 
 * Сформировать массив строк  String из предложений текста, в которых все слова состоят не больше чем из пяти символов.
 * Разделителями слов считать пробел, запятую, точку с запятой.
 * Разделителями предложений считать точку, восклицательный и вопросительный знаки, символ конца строки.
 * */
namespace HomeWork7_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string stroka = "What makes every American a typical one; is a desire to, get a well-paid; job that will, cover, their credit card. A credit card is an indispensable part of life in America\0 In other words, any India knows that how. He or she handles their credit card or cards, either will help them or haunt them for years? My name is Dima.";
            //string UpLowerPattern = @"\b([A-Z])";
            string fiveSim = @"\b[а-яА-Яa-zA-Z^-]{1,5}\b";
            string sentencesPattern = @"[.?!\0]+\s*";
            string wordPattern = @"[,;\s]+\b";
            string word = @"\b([а-яА-Яa-zA-Z^-]+)\b";
            Regex wordFiveSim = new Regex(fiveSim);
            Regex regexWord = new Regex(word);
            Regex wordsRegex = new Regex(wordPattern);
            Regex sentesRegex = new Regex(sentencesPattern);
            string[] sent = sentesRegex.Split(stroka);
           
            Console.WriteLine("Исходная строка");
            Console.WriteLine("*********************");
            Console.WriteLine(stroka);
            Console.WriteLine("*********************");
            Console.WriteLine("Замена заглавных букв");
            Console.WriteLine("*********************");
            string smallLitter = stroka.ToLower();
            Console.WriteLine(smallLitter);
            Console.WriteLine("*********************");
            Console.WriteLine("Установка знака $ после каждого слова");
            Console.WriteLine("*********************");
            string strokaWithBaks = regexWord.Replace(stroka, @"$1$$");
            Console.WriteLine(strokaWithBaks);
            Console.WriteLine("*********************");
            Console.WriteLine("Предложения состоящие из слов, в которых не более пяти символов");
            Console.WriteLine("*********************");
            string[] newStr = NewStroka(sent, wordFiveSim, wordsRegex);
            foreach (string item in newStr)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("*********************");
            Console.ReadKey();
        }
        static string[] NewStroka(string[] sent, Regex notMoreFiveSim, Regex wordsRegex)
        {
            string[] str = null;
            int count;
            int words = 0;
            for (int i = 0; i < sent.Length; i++)
            {
                str = wordsRegex.Split(sent[i]);
                count = 0;
                foreach (string item in str)
                {
                    if (notMoreFiveSim.IsMatch(item))
                        count++;
                }
                if (count == str.Length)
                    words++;
            }
            string[] newStr = new String[words];
            int j = 0;
            for (int i = 0; i < sent.Length; i++)
            {
                str = wordsRegex.Split(sent[i]);
                count = 0;
                foreach (string item in str)
                {
                    if (notMoreFiveSim.IsMatch(item))
                        count++;
                }
                if (count == str.Length)
                    newStr[j++] += sent[i];
            }
            return newStr;
        }
    }
}
