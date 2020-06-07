using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Разработать первый производный класс, для покупки товара с фиксированной скидкой от цены и переопределить нужные методы (GetCost( ) и ToString( ).
namespace HomeWork5_1
{
    class FixesDiscount:PurchaseOfGoods
    {
        const int discount = 10;
        public FixesDiscount():base()
        {

        }
        public FixesDiscount(string name,decimal price, int qamount):base(name,price,qamount)
        {

        }
        public FixesDiscount(PurchaseOfGoods obj):base(obj.NameProduct,obj.Price,obj.Qamount)
        {

        }
        public new decimal GetCost
        {
            get
            {
                decimal num = Qamount * Price;
                return (num = num - ((num / 100) * discount));
            }
        }
        public override string ToString()
        {
            return (NameProduct + ";" + Price + " рублей;" + Qamount + ";" + GetCost+ " рублей");
        }
    }
}
