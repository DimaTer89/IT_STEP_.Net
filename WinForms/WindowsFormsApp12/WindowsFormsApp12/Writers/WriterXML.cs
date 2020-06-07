using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp12.InterFaces;
using WindowsFormsApp12.Models;
using System.Xml;

namespace WindowsFormsApp12.Writers
{
    class WriterXML : IWriter<Student>
    {
        public void Write(List<Student> data, string filename)
        {
            XmlDocument xdoc = new XmlDocument();
            XmlNode xmld = xdoc.CreateXmlDeclaration("1.0", "", "");
            xdoc.AppendChild(xmld);
            XmlNode root = xdoc.CreateElement("Students", "http://tempuri.org/Students.xsd");
            foreach (Student st in data)
            {
                XmlNode newSt = xdoc.CreateElement("Student");
                XmlNode elemName = xdoc.CreateElement("Name");
                XmlNode textName = xdoc.CreateTextNode(st.Name);
                elemName.AppendChild(textName);
                newSt.AppendChild(elemName);
                XmlNode elemAge = xdoc.CreateElement("Age");
                XmlNode textAge = xdoc.CreateTextNode(st.Age.ToString());
                elemAge.AppendChild(textAge);
                newSt.AppendChild(elemAge);
                XmlNode marks = xdoc.CreateElement("Marks");
                foreach (int item in st.Marks)
                {
                    XmlNode elemBall = xdoc.CreateElement("Ball");
                    XmlNode ballText = xdoc.CreateTextNode(item.ToString());
                    elemBall.AppendChild(ballText);
                    marks.AppendChild(elemBall);
                }
                newSt.AppendChild(marks);
                root.AppendChild(newSt);
            }
            xdoc.AppendChild(root);
            xdoc.Save(filename);
        }
    }
}
