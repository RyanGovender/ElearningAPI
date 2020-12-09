using ElasticSearch_Libary.Logic;
using ElearningProjectModels.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningProjectBusiness.Implementation.Global
{
    public static class Elastic
    {
        private static readonly string _objectLoggerName = "insertupdatelogger";
        public static void LogInformation(object response, object updatedItem)
        {
            var _loggingItem = new ObjectLogger() { 
                DateTime = DateTime.Now,
                ResponseMessage = response,
                CurrentObjectDetails = null,
                IPAdress = "Inset IP HERE",
                MethodName = "Method Name Here ()",
                NewObjectDetails = updatedItem,
                UserID = "7893247-342-3243-324"
            };
            ElasticLogic<ObjectLogger>.AddToIndex(_loggingItem,_objectLoggerName);
        }
    }
}
