using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TempService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TempService.svc or TempService.svc.cs at the Solution Explorer and start debugging.
    public class TempService : ITempService
    {
        private static List<string> _tempList = new List<string>() {"13C", "14C", "17C", "20C", "25C"};

        public List<string> GetAll()
        {
            return _tempList; 
        }

        public void Post(string temp)
        {
            _tempList.Add(temp);
        }
    }
}
