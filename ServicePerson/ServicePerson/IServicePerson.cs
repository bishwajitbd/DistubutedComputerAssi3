using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicePerson
{
    // Service interface for using service of person
    // GetPerson for getting person inforamtion and SavePerson to save
    [ServiceContract]
    public interface IServicePerson
    {
        [OperationContract]
        Person GetPerson(int Id, String Auth);

        [OperationContract]
        void SavePerson(Person person, String Auth);
    }
}
