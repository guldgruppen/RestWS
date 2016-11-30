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
        public List<Temperatur> Get()
        {
            return db.Temperatur.ToList();
        }
        public string GetUdpServerData() 
        {           
            return _udpHandler.GetDataFromUdp();
        }

        public Temperatur GetTemp(string locationId)
        {
            return db.Temperatur.ToList().FirstOrDefault(x => x.Location.Equals(int.Parse(locationId))); 
        }

        public List<DaysAndTemp> GetNextFiveDays()
        {
            List<DaysAndTemp> temps = new List<DaysAndTemp>();
            for (int i = 0; i < 5; i++)
            {
                temps.Add(GetDays(i));
            }
            return temps;
        }


        public void Post(string jsonData)
        {
            Temperatur temp = JsonConvert.DeserializeObject<Temperatur>(jsonData);
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

        private DaysAndTemp GetDays(int days)
        {
            var temp = db.Temperatur.ToList().Where(x => (x.Timestamp.DayOfWeek).Equals(DateTime.Now.AddDays(days).DayOfWeek));
            var dayCalc = DateTime.Now.AddDays(days).DayOfWeek.ToString();
            var tempCalc = temp.Select(x => double.Parse(x.Data)).Sum() / temp.Count();
            return new DaysAndTemp {
              Day = GetDanishDayName(dayCalc),
              Temp = tempCalc,
            };
        }
        private string GetDanishDayName(string day)
        {
            switch (day)
            {
                case "Monday":
                    return "Mandag";
                case "Tuesday":
                    return "Tirsdag";
                case "Wednesday":
                    return "Onsdag";
                case "Thursday":
                    return "Torsdag";
                case "Friday":
                    return "Fredag";
                case "Saturday":
                    return "Lørdag";
                case "Sunday":
                    return "Søndag";
                default:
                    return "Helligdag";
            }
        }

    }

    public class DaysAndTemp
    {
        public string Day { get; set; }
        public double Temp { get; set; }
    }
}
