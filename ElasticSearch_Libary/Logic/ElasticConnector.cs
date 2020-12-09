using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticSearch_Libary.Logic
{
    public static class ElasticConnector
    {
        private static readonly SniffingConnectionPool _sniffingConnectionPool;
        private static readonly ConnectionSettings _connectionSettings;

        static ElasticConnector()
        {
            _sniffingConnectionPool = new SniffingConnectionPool(GetUris());
            _connectionSettings = new ConnectionSettings(_sniffingConnectionPool).DisableDirectStreaming();
        }

        private static Uri[] GetUris()
        {
            return new[]
            {
                new Uri("http://localhost:9200/"),
            };
        }

        public static ElasticClient ElasticClient(string defaultIndex)
        {
            var connectionPool = new StaticConnectionPool(GetUris());
            var connectionSettings = new ConnectionSettings(connectionPool).DisableDirectStreaming();
            connectionSettings.BasicAuthentication("elastic","password"); // into a config.....
            var elasticClient = new ElasticClient(connectionSettings.DefaultIndex(defaultIndex));
            return elasticClient;
        }
    }
}
