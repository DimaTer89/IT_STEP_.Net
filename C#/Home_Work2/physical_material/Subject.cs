using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace physical_material
{
    class Subject
    {
        Material mater;
        string name;
        double volume;
        public Subject()
        {
            mater = new Material();
        }
        public void setMater(string name,double des)
        {
            mater.Name_material = name;
            mater.Density = des;
        }
        public Material GetMaterial()
        {
            return mater;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public double Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;
            }
        }

        double GetMas()
        {
            return (mater.Density * volume);
        }
        public override string ToString()
        {
            return ($"({name};{mater.Name_material};{mater.Density};{volume:f2};{GetMas():f2})");
        }


    }
}
