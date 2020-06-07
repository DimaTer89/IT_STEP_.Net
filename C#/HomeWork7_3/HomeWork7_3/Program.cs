using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
/*Определить количество предложений, содержащих даты в формате дд/мм/гггг или дд.мм.гггг и адреса электронной почты.
 * Заменить в исходной строке в каждой дате год из четырех цифр на год из двух цифр.
 */
namespace HomeWork7_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input= @"Вася прислал Маше 12.03.2018 письмо по адресу masha3@mail.ru с шифром ы12/04/201890!!!!? Маша была рада ... Она 31/12/2018 ждёт Васю в гости по адресу wa_s.d2@yandex.com.ru. Она надеется, что он приедет!!! Это мечта под номером 45.06.2000";
            string datePattern = @"\b(([0][1-9]|[1,2][0-9]|[3][0-1])[./]?([0][1-9]|[1][0-2])[./]?)\d\d(\d\d)\b";
            string emailPattern = @"\b\w+[.,_]?\w+[.]?@\w{1,20}[.]{1}\w{2,3}\b";
            string sentensesPattern = @"[.?!]+\s+";
            Console.WriteLine("Исходная строка : \n**********************\n"+input);
            Regex emailRegex = new Regex(emailPattern);
            Regex dateRegex = new Regex(datePattern);
            Regex sentRegex = new Regex(sentensesPattern);
            string[] sentences = sentRegex.Split(input);
            int count = 0;
            foreach (string item in sentences)
            {
                if (dateRegex.IsMatch(item) && emailRegex.IsMatch(item))
                    count++;
            }
            Console.WriteLine("*********************\nМыло и дата встречаются в "+count+" предложениях\n************************");
            string output = dateRegex.Replace(input, @"$1$4");
            Console.WriteLine("Изменёная строка : \n************************\n"+output);
            Console.ReadKey();
        }
    }
}
