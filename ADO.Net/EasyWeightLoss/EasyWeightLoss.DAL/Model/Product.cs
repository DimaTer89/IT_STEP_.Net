using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyWeightLoss.DAL.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EnergyValue { get; set; }// энергетическая ценность ккал/100 гр.
    }
}
