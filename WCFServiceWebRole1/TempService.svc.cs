using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TempService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TempService.svc or TempService.svc.cs at the Solution Explorer and start debugging.
    public class TempService : ITempService
    {
        private static List<Temperatur> _tempList = new List<Temperatur>()
        {
            new Temperatur()
            {
                Id = 1, 
                Location = "Lokale 1", 
                Data = "20C",
                Timestamp = DateTime.Now
            },

            new Temperatur()
            {
                Id = 2,
                Location = "Lokale 1",
                Data = "18C",
                Timestamp = DateTime.Now
            },

            new Temperatur()
            {
                Id = 3,
                Location = "Lokale 1",
                Data = "24C",
                Timestamp = DateTime.Now
            },

        };

        public List<Temperatur> GetAll()
        {
            return _tempList; 
        }

        public void Post(Temperatur t)
        {
            _tempList.Add(t);
        }
    }
}
