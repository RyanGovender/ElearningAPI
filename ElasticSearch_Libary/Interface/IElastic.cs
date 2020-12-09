using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticSearch_Libary.Interface
{
    public interface IElastic<T>
    {
        void CreateIndex(string indexName,T mappingClass);
    }
}
