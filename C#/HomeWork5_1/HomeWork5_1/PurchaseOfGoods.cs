using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Разработать базовый класс, определяющий покупку товара:
Поля:
●	+название товара;
●	+цена в рублях;
●	+кол-во единиц товара.
Конструкторы:
●	+по умолчанию;
●	+с параметрами.
Методы:
●	+установки/считывания полей;
●	+GetCost( ) – вычисляет стоимость покупки;
●	ToString( ) – переводит объект в строку с разделителями «;»;
●	Equals( ) – сравнивает две продажи (считаются равными, если совпадают название и цена).
*/
namespace HomeWork5_1
{
    class PurchaseOfGoods
    {
        string nameProduct;
        decimal price;
        int qamount;
        public PurchaseOfGoods()
        {
            nameProduct = "";
            price = 0;
            qamount = 0;
        }
        public PurchaseOfGoods(string name,decimal price,int qamount)
        {
            nameProduct = name;
            this.price = price;
            this.qamount = qamount;
        }
        public string NameProduct
        {
            get
            {
                return nameProduct;
            }
            set
            {
                nameProduct = value;
            }
        }
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
        public int Qamount
        {
            get
            {
                return qamount;
            }
            set
            {
                qamount = value;
            }
        }
        public decimal GetCost
        {
            get
            {
                return (price * qamount);
            }
        }
        public override string ToString()
        {
            return (nameProduct+";"+price+" рублей;"+qamount+";"+GetCost+" рублей");
        }
        //public static bool operator ==(PurchaseOfGoods ob1,PurchaseOfGoods ob2)
        //{
        //    object o1 = ob1;
        //    object o2 = ob2;
        //    if (o1 == null && o2 == null)
        //        return true;
        //    if (o1 == null || o2 == null)
        //        return false;
        //    return ((String.Compare(ob1.NameProduct, ob2.NameProduct) == 0) && ob1.Price == ob2.Price);
        //}
        //public static bool operator !=(PurchaseOfGoods ob1, PurchaseOfGoods ob2)
        //{
        //    return !(ob1 == ob2);
        //}
        public override bool Equals(object obj)
        {
           if(obj is PurchaseOfGoods)
           {
                PurchaseOfGoods goods = (PurchaseOfGoods)obj;
                return ((String.Compare(this.NameProduct, goods.NameProduct) == 0) && this.Price == goods.Price);
           }
            return false;
        }
        public override int GetHashCode()
        {
            return ((int)price);
        }
    }
}
