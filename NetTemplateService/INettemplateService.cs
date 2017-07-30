using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NetTemplateService
{
    //INI ADALAH CONTOH YANG DI SEDIAKAN OLEH VISUAL STUDIO
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface INettemplateService
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        //INI ADALAH CONTOH YANG DI SEDIAKAN OLEH VISUAL STUDIO

        // TODO: Add your service operations here
        [OperationContract]
        string ValidateLogin(string username, string password, out string sessionCode);
    }


    //INI ADALAH CONTOH YANG DI SEDIAKAN OLEH VISUAL STUDIO
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract] //data contract adalah tempat pendeklarasian variabel pada WCF
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
    //INI ADALAH CONTOH YANG DI SEDIAKAN OLEH VISUAL STUDIO
}
