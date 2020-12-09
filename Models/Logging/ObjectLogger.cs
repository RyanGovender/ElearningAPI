using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningProjectModels.Logging
{
   public class ObjectLogger
    {
        public object CurrentObjectDetails { get; set; }
        public object NewObjectDetails { get; set; }
        public string UserID { get; set; }
        public string MethodName { get; set; }
        public string IPAdress { get; set; }
        public object ResponseMessage { get; set; } // create a response class
        public DateTime DateTime { get; set; }
    }
}
