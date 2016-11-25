using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITempService" in both code and config file together.
    [ServiceContract]
    public interface ITempService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Temperatur/Getall")]
        List<Temperatur> GetAll();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Temperatur/Post/")]
        void Post(Temperatur t); 
    }

    [DataContract]
    public class Temperatur
    {
        int id;
        string location;
        string data;
        DateTime timestamp;
        Status status; 
        
        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]       
        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        [DataMember]      
        public string Data
        {
            get { return data; }
            set
            {
                data = value;
            }
        }

        [DataMember]
        public DateTime Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }

        [DataMember]        
        public Status Status
        {
            get { return status; }
            set { status = value; }
        }
    }


    public enum Status
    {
        Kold = 1,
        Mellemkold = 2, 
        God = 3, 
        Mellemvarm = 4, 
        Varm = 5
    }

}
