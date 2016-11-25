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
                Location = "Lokale 1",
                Data = "11 C",
                Timestamp = DateTime.Now,
            },

            new Temperatur()
            {
                Id = 2,
                Location = "Lokale 1",
                Data = "17 C",
                Timestamp = DateTime.Now
            },

            new Temperatur()
            {
                Id = 3,
                Location = "Lokale 1",
                Data = "24 C",
                Timestamp = DateTime.Now
            },

            new Temperatur()
            {
                Id = 4,
                Location = "Lokale 1",
                Data = "22 C",
                Timestamp = DateTime.Now
            },

            new Temperatur()
            {
                Id = 5,
                Location = "Lokale 1",
                Data = "30 C",
                Timestamp = DateTime.Now
            },

            new Temperatur()
            {
                Id = 6,
                Location = "Lokale 1",
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

        public void Post(Temperatur t)
        {
            _tempList.Add(t);
        }

        public List<Temperatur> FilterTemperaturs(List<Temperatur> list)
        {
            foreach (var temperatur in list)
            {
                if (int.Parse(temperatur.Data.Split()[0]) < 15)
                    temperatur.Status = Status.Kold; 
                else if (int.Parse(temperatur.Data.Split()[0]) >= 15 && int.Parse(temperatur.Data.Split()[0]) < 18)
                    temperatur.Status = Status.Mellemkold;
                else if(int.Parse(temperatur.Data.Split()[0]) >= 18 && int.Parse(temperatur.Data.Split()[0]) <= 22)
                    temperatur.Status = Status.God;
                else if(int.Parse(temperatur.Data.Split()[0]) > 22 && int.Parse(temperatur.Data.Split()[0]) < 25)
                    temperatur.Status = Status.Mellemvarm;
                else 
                    temperatur.Status = Status.Varm;
            }

            return list;
        }

    }
}
