using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPatterns.AbstractFactory;
using System.Windows.Forms;

namespace ExamPatterns.ChainOfResponsibility
{
    class ShishKebabCafeGarage : ShishKebabOrder
    {
        ICafeFactory cafeGarage;
        public override void ShishKebab(ListBox listbox,string meat,int index)
        {
            if (meat == "Свинина" && index == 0)
            {
                cafeGarage = new CafeGarage();
                listbox.Items.Add(cafeGarage.CreateBarbecue().CreateBarbecue(meat));
            }
            else if (meat == "Баранина" && index == 0)
            {
                MessageBox.Show("Перевод заказа в другое кафе просим свои извинения", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                NextCafe.ShishKebab(listbox, meat, index);
            }
            else
                NextCafe.ShishKebab(listbox, meat, index);
        }
    }
}
