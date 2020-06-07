using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace physical_material
{
    class Material
    {
        string name_material;
        double density;
        public string Name_material
        {
            get
            {
                return name_material;
            }
            set
            {
                name_material = value;
            }
        }
        public double Density
        {
            get
            {
                return density;
            }
            set
            {
                density = value;
            }
        }
        public override string ToString()
        {
            return ("("+name_material+";"+density+")");
        }
    }
}
