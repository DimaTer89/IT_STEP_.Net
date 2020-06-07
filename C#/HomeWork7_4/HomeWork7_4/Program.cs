using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
/*Сформировать строку типа StringBuilder из последних двух слов предложений исходной строки типа String, в которых больше трех слов и есть дата в формате дд/мм/гггг. Разделителями предложений считать восклицательный знак, вопросительный знак, точку и любую комбинацию этих символов. Разделителями слов считать пробел, запятую, точку с запятой, сочетание любой буквы русского алфавита с буквой ‘x’ и любую комбинацию этих разделителей. В полученной строке заключить все слова, содержащие цифры, в скобки.
Например,
Исходная строка: 
Мама, ax ax,, мыла   раму 25/05/2015 ух;25раз!!!  Потом  26/05/2015 смотрела, ох  долго, фх,фх Дом2!...  Без хх труда не выловишь и рыбку из пруда?!! 27/05/2015 она ых отдыхала…
Результат:
(25/05/2015) (25раз) долго (Дом2)
*/
namespace HomeWork7_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Мама, ах ах,, мыла   раму 25/05/2015 ух;25раз!!!  Потом  26/05/2015 смотрела, ох  долго, фх,фх Дом2!...  Без хх труда не выловишь и рыбку из пруда?!! 27/05/2015 она ых отдыхала...";
            Console.WriteLine("Исходная строка \n"+input);
            string deleteAnyX = @"\b[а-я]х\b";
            string sensPattenr = @"[.!?]+\s*";
            string spacerWords = @"[ ,;]+";
            string words = @"(\b\w+\d*\d*/*\d*\d*/*\d*\d*\d*\d*\b\w*)";
            string date = @"\b[0][1-9]|[1,2][0-9]|[3][0-1]/[0][1-9]|[1][0-2]/\d\d\d\d\b";
            string wordsWithDigit = @"\b\w+\d+\w+\b|\b\d+\w+\b|\b\w+\d+\b|\b\d+\w*\b";
            Regex deleteAnyXRegex = new Regex(deleteAnyX);
            Regex spacerWordsRagex = new Regex(spacerWords);
            Regex sensRegex = new Regex(sensPattenr);
            Regex wordsRegex = new Regex(words);
            Regex dateRegex = new Regex(date);
            Regex wordWithDigit = new Regex(wordsWithDigit);
            input = deleteAnyXRegex.Replace(input, "");
            input = spacerWordsRagex.Replace(input, " ");
            string[] sens = sensRegex.Split(input);
            int count=0;
            MatchCollection word;
            foreach (string item in sens)
            {
                word = wordsRegex.Matches(item);
                if (word.Count>=4&&dateRegex.IsMatch(item))
                    count++;
            }
            string[] newSens = new string[count];
            int i = 0;
            foreach (string item in sens)
            {
                word = wordsRegex.Matches(item);
                if (word.Count >= 4 && dateRegex.IsMatch(item))
                    newSens[i++] = item;
            }
            StringBuilder newInput = new StringBuilder();
            count = 0;
            foreach (string item in newSens)
            {
                word=wordsRegex.Matches(item);
                count= 0;
                foreach (Match item1 in word)
                {
                    count++;
                    if (count == word.Count - 1 || count == word.Count)
                    {
                        if (wordWithDigit.IsMatch(item1.Value))
                            newInput.Append("(" + item1 + ") ");
                        else
                            newInput.Append(item1 + " ");
                    }
                }
            }
            Console.WriteLine("Результирующая строка : "+newInput);
            Console.ReadKey();
        }
    }
}
