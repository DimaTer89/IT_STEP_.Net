using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp12.InterFaces
{
    interface IWriter<T>
    {
        void Write(List<T> data,string filename);
    }
}
