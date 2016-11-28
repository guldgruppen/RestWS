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
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Temperatur/Get/{locationId}")]
        Temperatur GetTemp(string locationId);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Temperatur/GetUdpServerData/")]
        string GetUdpServerData();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Temperatur/Post/")]
        void Post(Temperatur t); 
    }

    //[DataContract]
    //public class Temperatur
    //{
    //    int id;
    //    string location;
    //    string data;
    //    DateTime timestamp;
    //    Status status; 
        
    //    [DataMember]
    //    public int Id
    //    {
    //        get { return id; }
    //        set { id = value; }
    //    }

    //    [DataMember]       
    //    public string Location
    //    {
    //        get { return location; }
    //        set { location = value; }
    //    }

    //    [DataMember]      
    //    public string Data
    //    {
    //        get { return data; }
    //        set
    //        {
    //            data = value;
    //        }
    //    }

    //    [DataMember]
    //    public DateTime Timestamp
    //    {
    //        get { return timestamp; }
    //        set { timestamp = value; }
    //    }

    //    [DataMember]        
    //    public Status Status
    //    {
    //        get { return status; }
    //        set { status = value; }
    //    }
    //}


    //public enum Status
    //{
    //    LightBlue = 1,
    //    Blue = 2, 
    //    Green = 3, 
    //    Yellow = 4, 
    //    Red = 5
    //}

}
