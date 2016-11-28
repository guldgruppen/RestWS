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
        private static List<Temperatur> _tempList = new List<Temperatur>()
        {
           #region TestingData
		 new Temperatur()
            {
                Id = 1,
                Location = "Lokale1",
                Data = "11 C",
                Timestamp = DateTime.Now - TimeSpan.FromHours(2),
            },

            new Temperatur()
            {
                Id = 2,
                Location = "Lokale1",
                Data = "17 C",
                Timestamp = DateTime.Now - TimeSpan.FromHours(2)
            },

            new Temperatur()
            {
                Id = 3,
                Location = "Lokale1",
                Data = "24 C",
                Timestamp = DateTime.Now
            },

            new Temperatur()
            {
                Id = 4,
                Location = "Lokale2",
                Data = "22 C",
                Timestamp = DateTime.Now - TimeSpan.FromHours(2)
            },

            new Temperatur()
            {
                Id = 5,
                Location = "Lokale2",
                Data = "30 C",
                Timestamp = DateTime.Now
            },

            new Temperatur()
            {
                Id = 6,
                Location = "Lokale3",
                Data = "20 C",
                Timestamp = DateTime.Now
            },

	#endregion
        };

        public List<Temperatur> GetAll()
        {
            FilterTemperaturs(_tempList); 
            return _tempList; 
        }

        public Temperatur GetTemp(string location)
        {
            FilterTemperaturs(_tempList);

            var temp = _tempList.OrderByDescending(t => t.Timestamp).Where((temperatur => temperatur.Location == location)).FirstOrDefault(); 

            return temp; 

        }

        public void Post(Temperatur t)
        {
            _tempList.Add(t);
        }

        public List<Temperatur> FilterTemperaturs(List<Temperatur> list)
        {
            foreach (var temperatur in list)
            {
                if (double.Parse(temperatur.Data.Split()[0]) < 15)
                    temperatur.Status = Status.LightBlue; 
                else if (double.Parse(temperatur.Data.Split()[0]) >= 15 && int.Parse(temperatur.Data.Split()[0]) < 18)
                    temperatur.Status = Status.Blue;
                else if(double.Parse(temperatur.Data.Split()[0]) >= 18 && int.Parse(temperatur.Data.Split()[0]) <= 22)
                    temperatur.Status = Status.Green;
                else if(double.Parse(temperatur.Data.Split()[0]) > 22 && int.Parse(temperatur.Data.Split()[0]) < 25)
                    temperatur.Status = Status.Yellow;
                else 
                    temperatur.Status = Status.Green;
            }

            return list;
        }

    }
}
