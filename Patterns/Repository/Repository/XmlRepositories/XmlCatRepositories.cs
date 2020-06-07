using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;
using Repository.Interfaces;
using System.Xml;
using System.Xml.Linq;

namespace Repository.XmlRepositories
{
    class XmlCatRepositories : IRepository<Cat>
    {
        List<Cat> cats = new List<Cat>();
        XmlDocument xDocument = new XmlDocument();
        string path = @"..\..\App_Data\cats.xml";
        public void Create(Cat item)
        {
            if (!cats.Any(d => d.Id == item.Id))
            {
                xDocument.Load(path);
                XmlElement xmlRoot = xDocument.DocumentElement;
                XmlElement catElem = xDocument.CreateElement("cat");
                XmlAttribute idAttr = xDocument.CreateAttribute("id");
                XmlElement nameElem = xDocument.CreateElement("name");
                XmlElement ageElem = xDocument.CreateElement("weight");
                XmlText idText = xDocument.CreateTextNode(Convert.ToString(item.Id));
                XmlText nameText = xDocument.CreateTextNode(item.Name);
                XmlText ageText = xDocument.CreateTextNode(Convert.ToString(item.Weight));
                idAttr.AppendChild(idText);
                nameElem.AppendChild(nameText);
                ageElem.AppendChild(ageText);
                catElem.Attributes.Append(idAttr);
                catElem.AppendChild(nameElem);
                catElem.AppendChild(ageElem);
                xmlRoot.AppendChild(catElem);
                xDocument.Save(path);
            }
            else
                throw new Exception("Собака в базу уже существует");
        }

        public void Delete(int id)
        {
            XDocument doc=XDocument.Load(path);
            var delete = from node in doc.Descendants("cat")
                         where Convert.ToInt32(node.Attribute("id").Value) == id
                         select node;
            delete.ToList().ForEach(elem => elem.Remove());
            doc.Save(path);
        }

        public Cat Get(int id)
        {
            XDocument document = XDocument.Load(path);
            var cat = (from c in document.Descendants(XName.Get("cat"))
                       where Convert.ToInt32(c.Attribute(XName.Get("id")).Value) == id select c).FirstOrDefault();
            Cat findCat = new Cat();
            findCat.Id = Convert.ToInt32(cat.Attribute(XName.Get("id")).Value);
            findCat.Name = cat.Attribute(XName.Get("name")).Value;
            findCat.Weight = Convert.ToDouble(cat.Attribute(XName.Get("weight")).Value);
            return findCat;         
        }

        public IEnumerable<Cat> GetAll()
        {
            xDocument.Load(path);
            XmlNodeList catNodes = xDocument.DocumentElement.GetElementsByTagName("cat");
            foreach (XmlNode item in catNodes)
            {
                Cat cat = new Cat();
                cat.Id = Convert.ToInt32(item.Attributes["id"].Value);
                cat.Name = item["name"].InnerText;
                cat.Weight = Convert.ToDouble(item["weight"].InnerText);
                cats.Add(cat);
            }
            return cats;
        }

        public void Update(Cat item)
        {
            xDocument.Load(path);
            XmlElement xRoot = xDocument.DocumentElement;
            XmlNode findCat = xRoot.SelectSingleNode("cat[id]=='item.Id");
            findCat.Attributes["id"].Value = Convert.ToString(item.Id);
            findCat["name"].InnerText = item.Name;
            findCat["weight"].InnerText = Convert.ToString(item.Weight);
            xDocument.Save(path);
        }
    }
}
