using ElasticSearch_Libary.Logic;
using ElearningProjectModels.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningProjectRepository.Implementation.Global
{
    public static class Elastic
    {
        private static readonly string _objectLoggerName = "objectchangelogger";
        //response from executed task
        //objectChangeDetails the result of the object compare
        public static void LogInformation<T>(T current, T newObject, string response, string methodName) where T : class
        {
            var objectResult = ObjectCompare.CompareObjects(current, newObject).ToString();
            LogInformation(response, objectResult, methodName);
        }

        public static void LogInformation(string response, string objectChangeDetails, string methodName)
        {
            var _loggingItem = new ObjectLogger() { 
                CreatedDate = DateTime.Now,
                ResponseMessage =  response ,
                ChangedObjectDetails = objectChangeDetails,
                IPAdress = Network.GetLocalIPAddress(),
                MethodName = methodName,
                UserID = "7893247-342-3243-324" //in future get userid from jwt
            };
            ElasticLogic<ObjectLogger>.AddToIndex(_loggingItem,_objectLoggerName);
        }
    }
}
