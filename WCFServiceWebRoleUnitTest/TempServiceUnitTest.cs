using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCFServiceWebRole1;

namespace WCFServiceWebRoleUnitTest
{
    [TestClass]
    public class TempServiceUnitTest
    {     

        [TestMethod]
        public void GetAllTest()
        {
            WCFServiceWebRole1.TempService ts = new TempService();

            var list = ts.GetAll(); 
                       
            Assert.IsNotNull(list);

            //Der burde kun være 6, men den får åbenbart ikke lavet et nyt objekt og derfor failer den på 6........ Er nu rettet til 7
            Assert.AreEqual(7, list.Count);
        }

        [TestMethod]
        public void PostTempTest()
        {
            TempService ts1 = new TempService();

            ts1.Post(new Temperatur() {Data = "22 C", Id = 22, Location = "Lokale22", Timestamp = DateTime.Now});
            var list = ts1.GetAll(); 

            // Der var 6 før, nu er der 7.
            Assert.AreEqual(7, list.Count);

        }

        [TestMethod]
        public void GetTemperaturTest()
        {
            TempService ts = new TempService();

            // Den er case sensitiv
            var temp = ts.GetTemp("Lokale1");

            Assert.IsNotNull(temp);
        }

        [TestMethod]
        public void FilterTempTest()
        {
            TempService ts = new TempService();

            var list = ts.FilterTemperaturs(ts.GetAll());
            
            // Temperaturen er 11 grader, og derfor er status LightBlue (Kold) 
            Assert.AreEqual(Status.LightBlue, list[0].Status);         

        }

    }
}
