using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Lab2Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMathSevice" in both code and config file together.
    [ServiceContract]
    public interface IMathSevice
    {
        [OperationContract]
        double Add(double value1, double value2);

        [OperationContract]
        double Subtract(double value1, double value2);

        [OperationContract]
        double Multiply(double value1, double value2);

        [OperationContract]
        double Divide(double value1, double value2);

        [OperationContract]
        double CircleArea(double value1);
    }
}
