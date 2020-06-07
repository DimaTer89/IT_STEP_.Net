using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WindowsFormsApp12.InterFaces;
using WindowsFormsApp12.Models;

namespace WindowsFormsApp12.Readers
{
    class ReaderXml : IReader<Student>
    {
        public List<Student> Read(string filename)
        {
            List<Student> students = new List<Student>();
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNodeList list = doc.GetElementsByTagName("Student");
            Student currentStudent = null;
            foreach (XmlNode item in list)
            {
                currentStudent = new Student();
                currentStudent.Name = item["Name"].InnerText;
                currentStudent.Age = int.Parse(item["Age"].InnerText);
                XmlNodeList marks = item["Marks"].GetElementsByTagName("Ball");
                int[] tmp = new int[marks.Count];
                int i = 0;
                foreach (XmlNode items in marks)
                {
                    tmp[i] = int.Parse(items.InnerText);
                    i++;
                }
                currentStudent.Marks = tmp;
                students.Add(currentStudent);
            }
            return students;
        }
    }
}
