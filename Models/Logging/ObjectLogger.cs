using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningProjectModels.Logging
{
   public class ObjectLogger
    {
        public string ChangedObjectDetails { get; set; }
        public string UserID { get; set; }
        public string MethodName { get; set; }
        public string IPAdress { get; set; }
        public string ResponseMessage { get; set; } // create a response class
        public DateTime CreatedDate { get; set; }
    }
}
