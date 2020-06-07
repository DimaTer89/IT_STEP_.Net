using Repository.Interfaces;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Repository.XmlRepositories
{
    class XmlDogRepository : IRepository<Dog>
    {
        List<Dog> dogs = new List<Dog>();
        XmlDocument document = new XmlDocument();
        string fileName=@"..\..\App_Data\dogs.xml";
        public void Create(Dog item)
        {
            if (!dogs.Any(d => d.Id == item.Id))
            {
                document.Load(fileName);
                XmlElement xmlRoot = document.DocumentElement;
                XmlElement catElem = document.CreateElement("dog");
                XmlAttribute idAttr = document.CreateAttribute("id");
                XmlElement nameElem = document.CreateElement("name");
                XmlElement ageElem = document.CreateElement("age");
                XmlText idText = document.CreateTextNode(Convert.ToString(item.Id));
                XmlText nameText = document.CreateTextNode(item.Name);
                XmlText ageText = document.CreateTextNode(Convert.ToString(item.Age));
                idAttr.AppendChild(idText);
                nameElem.AppendChild(nameText);
                ageElem.AppendChild(ageText);
                catElem.Attributes.Append(idAttr);
                catElem.AppendChild(nameElem);
                catElem.AppendChild(ageElem);
                xmlRoot.AppendChild(catElem);
                document.Save(fileName);
            }
            else
                throw new Exception("Собака в базу уже существует");

        }

        public void Delete(int id)
        {
            XDocument doc = XDocument.Load(fileName);
            var delete = from node in doc.Descendants("dog")
                         where Convert.ToInt32(node.Attribute("id").Value) == id
                         select node;
            delete.ToList().ForEach(elem => elem.Remove());
            doc.Save(fileName);
        }

        public Dog Get(int id)
        {
            XDocument doc = XDocument.Load(fileName);
            var result = (from d in doc.Descendants(XName.Get("dog"))
                         where Convert.ToInt32(d.Attribute(XName.Get("id")).Value) ==id
                         select d).FirstOrDefault();
            Dog dog = new Dog();
            dog.Id = Convert.ToInt32(result.Attribute(XName.Get("id")).Value);
            dog.Name = result.Element(XName.Get("name")).Value;
            dog.Age = Convert.ToInt32(result.Element(XName.Get("age")).Value);
            return dog;
        }

        public IEnumerable<Dog> GetAll()
        {
            document.Load(fileName);
            XmlNodeList dogNodes = document.DocumentElement.GetElementsByTagName("dog");
            foreach (XmlNode node in dogNodes)
            {
                Dog dog = new Dog();
                dog.Id= Convert.ToInt32(node.Attributes["id"].Value);
                dog.Name = node["name"].InnerText;
                dog.Age= Convert.ToInt32(node["age"].InnerText);
                dogs.Add(dog);
            }
            return dogs;
        }

        public void Update(Dog item)
        {
            document.Load(fileName);
            XmlElement xRoot = document.DocumentElement;
            XmlNode findDog = xRoot.SelectSingleNode("dog[id]=='item.Id'");
            findDog.Attributes["id"].Value =Convert.ToString(item.Id);
            findDog["name"].InnerText = item.Name;
            findDog["age"].InnerText = Convert.ToString(item.Age);
            document.Save(fileName);
        }
    }
}
