using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPatterns.AbstractFactory
{
    class Barbekue : IBarbecue
    {
        public string CreateBarbecue(string ingredient)
        {
            StringBuilder builder = new StringBuilder(ingredient);
            builder.Remove(builder.Length - 1, 1);
            builder.Append('ы');
            return ("Шашлык из " + builder + " 350 гр.");
        }
    }
}
