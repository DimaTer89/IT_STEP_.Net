using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Calculate
{
    [ServiceContract]
    public interface IDopContract
    {
        [OperationContract]
        double SinXCosY(double x, double y);
        [OperationContract]
        double TexX(double x);
    }
}
