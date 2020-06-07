using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Разработать второй производный класс (от базового) со скидкой к цене, если количество единиц товара не меньше некоторой константы подкласса. Переопределить нужные методы.
namespace HomeWork5_1
{
    class PriceDiscount:PurchaseOfGoods
    {
        const int count = 300;
        const int discount = 25;
        public PriceDiscount() : base()
        {

        }
        public PriceDiscount(string name, decimal price, int qamount) : base(name, price, qamount)
        {

        }
        public PriceDiscount(PurchaseOfGoods obj) : base(obj.NameProduct, obj.Price, obj.Qamount)
        {

        }
        public bool Discount()
        {
            if (Qamount > count)
                return true;
            else
                return false;
        }
        public new decimal GetCost
        {
            get
            {
                decimal num = Qamount * Price;
                if (Discount())
                {
                    return (num = num - ((num / 100) * discount));
                }
                else
                    return num;
            }
        }
        public override string ToString()
        {
            return (NameProduct + ";" + Price + " рублей;" + Qamount + ";" + GetCost+" рублей");
        }
    }
}
