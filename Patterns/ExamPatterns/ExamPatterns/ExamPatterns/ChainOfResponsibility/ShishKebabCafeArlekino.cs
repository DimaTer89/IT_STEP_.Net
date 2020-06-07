using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPatterns.AbstractFactory;
using System.Windows.Forms;

namespace ExamPatterns.ChainOfResponsibility
{
    class ShishKebabCafeArlekino : ShishKebabOrder
    {
        ICafeFactory cafeArlekino;
        public override void ShishKebab(ListBox listbox,string meat,int index)
        {
            cafeArlekino = new CafeArlekino();
            listbox.Items.Add(cafeArlekino.CreateBarbecue().CreateBarbecue(meat));
        }
    }
}
