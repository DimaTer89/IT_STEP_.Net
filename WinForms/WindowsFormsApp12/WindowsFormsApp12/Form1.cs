using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp12.InterFaces;
using WindowsFormsApp12.Models;
using WindowsFormsApp12.Readers;
using System.Text.RegularExpressions;
using WindowsFormsApp12.Writers;
using System.Xml.Schema;
using System.Xml;
using System.Runtime.Serialization.Json;

namespace WindowsFormsApp12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.InitialDirectory = Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName;
            saveFileDialog1.InitialDirectory = Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName;
        }
        void Read<T>(string filename,IReader<T> reader)
        {
            richTextBox1.Clear();
            List<T> data = reader.Read(filename);
            for (int i = 0; i < data.Count; i++)
                richTextBox1.AppendText(data[i] + "\n");
        }
        void Write(string filename,IWriter<Student> writer)
        {
            List<Student> data = new List<Student>(richTextBox1.Lines.Count());
            Regex reg = new Regex(" +(?:ratings:)? *");
            foreach (string  item in richTextBox1.Lines)
            {
                try
                {
                    string[] tmp = reg.Split(item);
                    Student st = new Student();
                    st.Name = tmp[0];
                    st.Age = int.Parse(tmp[1]);
                    st.Marks = new int[tmp.Length - 2];
                    for (int i = 0; i < tmp.Length - 2; i++)
                        st.Marks[i] = int.Parse(tmp[i + 2]);
                    data.Add(st);
                }
                catch { }
            }
            writer.Write(data, filename);
        }
        //метод для проверки валидации
        void validateStudentXml(string filename)
        {
            richTextBox1.Clear();
            XmlSchemaSet sc = new XmlSchemaSet();
            sc.Add("http://tempuri.org/Students.xsd", @"..\..\Students.xsd");
            //Настройки валидации
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = sc;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
            XmlReader xmlReader = XmlReader.Create(filename, settings);
            while (xmlReader.Read()) ;
            if (richTextBox1.Lines.Count() == 0)
                richTextBox1.Text += "It's so good\n";
        }

        private void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            richTextBox1.Text += e.Message + "\n";
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                Read<Student>(openFileDialog1.FileName, new ReaderXml());
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void вXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                Write(saveFileDialog1.FileName,new WriterXML());
            }
        }

        private void проверитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                validateStudentXml(openFileDialog1.FileName);
        }

        private void вJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Student>));
                List<Student> data = new List<Student>(richTextBox1.Lines.Count());
                Regex reg = new Regex(" +(?:ratings:)? *");
                foreach (string item in richTextBox1.Lines)
                {
                    try
                    {
                        string[] tmp = reg.Split(item);
                        Student st = new Student();
                        st.Name = tmp[0];
                        st.Age = int.Parse(tmp[1]);
                        st.Marks = new int[tmp.Length - 2];
                        for (int i = 0; i < tmp.Length - 2; i++)
                            st.Marks[i] = int.Parse(tmp[i + 2]);
                        data.Add(st);
                    }
                    catch { }
                }
                using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate))
                {
                    jsonFormatter.WriteObject(fs, data);
                }
            }
        }
    }
}
