using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp12.Models
{
    [DataContract]
    class Student
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public int[] Marks { get; set; }
        public override string ToString()
        {
            StringBuilder tmp = new StringBuilder(Name).Append(" ").Append(Age).Append(" ratings: ");
            foreach (int item in Marks)
            {
                tmp.Append(" ").Append(item);
            }
            return tmp.ToString();
        }
    }
}
