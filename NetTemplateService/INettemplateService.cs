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
        // http://www.dotnettricks.com/learn/wcf/understanding-various-types-of-wcf-bindings <- tipe2 protocol WCF

        
        //contoh 1. Nilai kembalian JSON
        [OperationContract]
        // bagian webinvoke ini dibutuhkan untuk di gunakan pada endpoint REST, untuk ASMX ga uasah pake ini
        [WebInvoke(Method = "GET", //method ambil data nya. POST atau GET
                    ResponseFormat = WebMessageFormat.Json, //Nilai kembalian
                    BodyStyle = WebMessageBodyStyle.Wrapped, //gatau, tapi mandatory
                    UriTemplate = "validateLoginJson/{username}/{password}")] //nge set path url. Penjelasan :
                    // misal di web config kita set tag BaseAddress = http://localhost:65189/NettemplateService.svc
                    // terus kita set address di endpoint nya = /RESTendpoint
                    // naah, jadi url untuk manggil method ini melalui REST endpoint -> http://localhost:65189/NettemplateService.svc/RESTendpoint/validateLogin/param_username/param_password
        string ValidateLoginJson(string username, string password, out string sessionCode);

        //contoh 2. Niai kembalian XML
        [OperationContract]
        [WebInvoke(Method = "GET", 
                    ResponseFormat = WebMessageFormat.Xml, 
                    BodyStyle = WebMessageBodyStyle.Wrapped, 
                    UriTemplate = "validateLoginXml/{username}/{password}")] 
        string ValidateLoginXml(string username, string password, out string sessionCode);





        //Test URL
        //untuk yang basicHttpBinding di test by url di bawah ga muncul nilai nya
        // contoh 1. http://localhost:65189/NettemplateService.svc/RESTendpoint/validateLoginXml/giyansanusi/giyansanusi
        // contoh 2. http://localhost:65189/NettemplateService.svc/RESTendpoint/validateLoginJson/giyansanusi/giyansanusi 

       
       


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
