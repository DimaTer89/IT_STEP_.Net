using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPatterns.AbstractFactory;
using System.Windows.Forms;

namespace ExamPatterns.ChainOfResponsibility
{
    abstract class ShishKebabOrder
    {
        public ShishKebabOrder NextCafe { get; set; }
        public abstract void ShishKebab(ListBox listbox,string meat,int index);
    }
}
