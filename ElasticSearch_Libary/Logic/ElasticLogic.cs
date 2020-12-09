using ElasticSearch_Libary.Interface;
using Nest;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ElasticSearch_Libary.Logic
{
    public static class ElasticLogic<T> where T : class
    {
        public static void CreateIndex(string indexName)
        {
           var response = ElasticConnector.ElasticClient(indexName).Indices.Create(indexName,
                index => index.Map<T>(
                    x => x.AutoMap()
             ));
        }

        public static void AddToIndex(T item, string indexName)
        {
           // if (item != null && indexName != null && CheckIfIndexExist(indexName))
             var response = ElasticConnector.ElasticClient(indexName).IndexDocument(item);
        }

        public static bool CheckIfIndexExist(string indexName)
        {
            return ElasticConnector.ElasticClient(indexName).Indices.Exists(indexName).Exists;
        }

        private static void LogingExceptions(ResponseBase apiCall)
        {
         
        }
    }
}
