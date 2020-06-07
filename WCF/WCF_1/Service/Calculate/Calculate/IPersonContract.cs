using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Calculate
{
    [ServiceContract]
    public interface IPersonContract
    {
        [OperationContract]
        double WeightPlus(ref Person person, double x);
        [OperationContract (IsOneWay =true)]
        void HelloPerson(Person person, string hello);
    }
}
