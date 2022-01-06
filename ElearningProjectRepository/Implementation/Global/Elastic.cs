using ElasticSearch_Libary.Logic;
using ElearningProjectModels.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Web;


namespace ElearningProjectRepository.Implementation.Global
{
    public static class Elastic
    {
        private static readonly string _objectLoggerName = "objectchangelogger";
        //response from executed task
        //objectChangeDetails the result of the object compare
        //For updates to any object
        public static void LogInformation<T>(T current, T newObject, string response, string methodName, string userID) where T : class
        {
            var objectResult = ObjectCompare.CompareObjects(current, newObject).ToString();
            LogInformation(response, objectResult, methodName, userID);
        }

       // To convert an Insert into Object logger...does not do an object compare.
        public static void LogInformation<T>(T newObject, string response, string methodName, string userID) where T : class
        {
            var jsonObject = JsonSerializer.Serialize(newObject);
            LogInformation(response, jsonObject, methodName, userID);
        }

        public static void LogInformation(string response, string objectChangeDetails, string methodName, string userID)
        {
            var _loggingItem = new ObjectLogger()
            {
                CreatedDate = DateTime.Now,
                ResponseMessage = response,
                ChangedObjectDetails = objectChangeDetails,
                IPAdress = Network.GetLocalIPAddress(),
                MethodName = methodName,
                UserID = userID //in future get userid from jwt
            };
            ElasticLogic<ObjectLogger>.AddToIndex(_loggingItem, _objectLoggerName);
        }
    }
}
