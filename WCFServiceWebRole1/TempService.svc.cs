using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;

namespace WCFServiceWebRole1
{
    
    /// <summary>
    /// Status nummer: 
    /// 0: Ikke filtret 
    /// 1: Kold             Under 15
    /// 2: Mellem-Kold      15-18
    /// 3: God              18-22
    /// 4: Mellem-Varmt     22-25
    /// 5: Varmt            Over 25
    /// </summary>

    public class TempService : ITempService
    {
        TempContext db = new TempContext();
        private UdpServerHandler _udpHandler;
        public TempService()
        {
            _udpHandler = UdpServerHandler.Instance;
        }
       

        public List<Temperatur> GetAll()
        {
            var list = db.Temperatur.ToList();
            return list;
        }
        public string Get()
        {
            return JsonConvert.SerializeObject(db.Temperatur.ToList());
        }
        public string GetUdpServerData() 
        {           
            return _udpHandler.GetDataFromUdp();
        }

        public Temperatur GetTemp(string locationId)
        {
            var temp = db.Temperatur.ToList()
                .OrderByDescending((temperatur => temperatur.Timestamp))
                .Where((temperatur => temperatur.Location == int.Parse(locationId)))
                .SingleOrDefault();

            return temp; 
        }

        public void Post(string jsonData)
        {
            Temperatur temp = JsonConvert.DeserializeObject<Temperatur>(jsonData);
            temp.Data = "16";
            SetStatus(temp); 
            db.Temperatur.Add(temp);
            db.SaveChanges();
        }

        private void SetStatus(Temperatur t)
        {
            if (double.Parse(t.Data) < 15)
                t.Status = 1; 
            else if (double.Parse(t.Data) >= 15 && double.Parse(t.Data) < 18)
                t.Status = 2; 
            else if (double.Parse(t.Data) >= 18 && double.Parse(t.Data) <= 22)
                t.Status = 3; 
            else if (double.Parse(t.Data) > 22 && double.Parse(t.Data) < 25)
                t.Status = 4;
            else
                t.Status = 5;
        }

    }
}
