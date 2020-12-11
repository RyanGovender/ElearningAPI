using Dapper;
using ElearningProjectDAL.DAL;
using ElearningProjectRepository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningProjectRepository.Implementation
{
   public class DapperBaseRepository :IDapperBase
    {
        private static readonly string _storeProcReturnValueName = "@return";
        public async Task<int> Excute(string storedProcName, object parameters)
        {
                using (var _connection = DataService.SqlConnection())
                {
                    var _dynamicParameters = GetParameters(parameters); 
                    await _connection.ExecuteAsync(storedProcName, _dynamicParameters, commandType: CommandType.StoredProcedure);
                    return _dynamicParameters.Get<int>(_storeProcReturnValueName);
                }
        }

        private DynamicParameters GetParameters(object parameters)
        {
            var dynamicParameters = new DynamicParameters(parameters);
            dynamicParameters.Add(_storeProcReturnValueName, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            return dynamicParameters;
        }

        public async Task<bool> ExecuteQuery(string storeProcName, object parameters = null)
        {
            try
            {
                using var _connection = DataService.SqlConnection();
                var result = await _connection.ExecuteAsync(storeProcName, parameters, commandType: CommandType.StoredProcedure);
                return result < 0;

            }
            catch(Exception ex)
            {
                return false;
            }
         
        }

        public async Task<IQueryable<T>> Query<T>(string storeProcName, object parameters)
        {
            try
                {
                using var _connection = DataService.SqlConnection();
                var result = await _connection.QueryAsync<T>(storeProcName, parameters, commandType: CommandType.StoredProcedure);
                return result.AsQueryable();
            }
            catch
            {
                return new List<T>().AsQueryable();
            }
        }
          

    }
}
