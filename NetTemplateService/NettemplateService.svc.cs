using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using NetTemplateService.Model;

// Ingat ini, jika kamu ngubah nama file SVC nya ubah juga di markupnya karena ga tau kenapa ga ke refactor
// caranya, klik kanan file SVC nya, trus pilih view markup. terus samain nama nya sama nama yang baru kita ganti  
namespace NetTemplateService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class NettemplateService : INettemplateService
    {
        //INI ADALAH CONTOH YANG DI SEDIAKAN OLEH VISUAL STUDIO
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        // -- INI ADALAH CONTOH YANG DI SEDIAKAN OLEH VISUAL STUDIO

        //Mulai koding dari sini
        public string ValidateLoginJson(string username, string password, out string sessionCode) {

            sessionCode = "Login Failed";

            NetTemplateServiceDataContext db = new NetTemplateServiceDataContext();
            var user = (from qrs in db.USERs 
                        where qrs.USERNAME == username && qrs.PASSWORD == password
                        select qrs).FirstOrDefault(); 

            if (user != null) {
                sessionCode = "Login Successful";
            }

            return string.Format("You entered: {0}", username + password);


        }

        public string ValidateLoginXml(string username, string password, out string sessionCode)
        {

            sessionCode = "Login Failed";

            NetTemplateServiceDataContext db = new NetTemplateServiceDataContext();
            var user = (from qrs in db.USERs
                        where qrs.USERNAME == username && qrs.PASSWORD == password
                        select qrs).FirstOrDefault();

            if (user != null)
            {
                sessionCode = "Login Successful";
            }

            return string.Format("You entered: {0}", username + password);


        }

    }
}
