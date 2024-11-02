using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shop.Application.Interfaces.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ODD.Api.Infrastructure.Utility.Interfaces
{
    public class DapperContext : IDapperContext
    {
        private readonly IConfiguration _configuration;
        private string forbiddenCharacters = "";

        SqlConnection connection = new SqlConnection();

        public DapperContext(IConfiguration configuration)
        {

            _configuration = configuration;
            //open connection



        }
        public async Task<object> CallSPAsync(string spName, DynamicParameters? parameters)
        {

            IEnumerable<dynamic> queryResult = null;



            var procedure = spName;
            try
            {

                connection.ConnectionString = _configuration.GetConnectionString("SSMS");



                //call stored procedure and fetch result
                if (parameters != null)
                    queryResult = await connection.QueryAsync(procedure, parameters, commandType: CommandType.StoredProcedure, commandTimeout: 480);
                else
                    queryResult = await connection.QueryAsync(procedure, commandType: CommandType.StoredProcedure, commandTimeout: 480);

              
                return queryResult;
            }
            catch (Exception ex)
            {
                //  _logger.LogError($"MethodName : {nameof(CallSPAsync)} Date : {DateTime.Now} Message : {ex.Message} , InnerException : {ex.InnerException}");
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally { connection.Close(); connection.Dispose(); }

        }
        public object CallSP(string spName, DynamicParameters? parameters)
        {

            IEnumerable<dynamic> queryResult = null;


            var procedure = spName;
            try
            {

                connection.ConnectionString = _configuration.GetConnectionString("SSMS");


                //call stored procedure and fetch result
                if (parameters != null)
                    queryResult = connection.Query(procedure, parameters, commandType: CommandType.StoredProcedure, commandTimeout: 480);
                else
                    queryResult = connection.Query(procedure, commandType: CommandType.StoredProcedure, commandTimeout: 480);


                return queryResult;

            }
            catch (Exception ex)
            {
                // _logger.LogError($"MethodName : {nameof(CallSP)} Date : {DateTime.Now} Message : {ex.Message} , InnerException : {ex.InnerException}");
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally { connection.Close(); connection.Dispose(); }

        }

        public async Task BulkInsertAsync(DataTable dataTable)
        {


            try
            {
                connection.ConnectionString = _configuration.GetConnectionString("SSMS");

                connection.Open();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = dataTable.TableName;
                    await bulkCopy.WriteToServerAsync(dataTable);
                }

            }
            catch (Exception ex)
            {
                //   _logger.LogError($"MethodName : {nameof(BulkInsertAsync)} Date : {DateTime.Now} Message : {ex.Message} , InnerException : {ex.InnerException}");
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally { connection.Close(); connection.Dispose(); }

        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            PropertyInfo[] array = properties;
            foreach (PropertyInfo propertyInfo in array)
            {
                dataTable.Columns.Add(propertyInfo.Name);
            }


            foreach (T item in items)
            {
                object[] array2 = new object[properties.Length];
                for (int j = 0; j < properties.Length; j++)
                {

                    string propType = properties[j].PropertyType.ToString();


                    array2[j] = properties[j].GetValue(item, null);
                }

                dataTable.Rows.Add(array2);
            }

            return dataTable;
        }
        public DataSet ToDataSet<T>(List<T> list)
        {

            Type elementType = typeof(T);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                t.Columns.Add(propInfo.Name, propInfo.PropertyType);
            }

            //go through each property on T and add each value to the table
            foreach (T item in list)
            {
                DataRow row = t.NewRow();
                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null);
                }

                //This line was missing:
                t.Rows.Add(row);
            }


            return ds;
        }

        public async Task<object> QueryExecuteReaderToDB(string query, DynamicParameters? parameters = null)
        {
            IEnumerable<dynamic> queryResult = null;



            try
            {
                connection.ConnectionString = _configuration.GetConnectionString("SSMS");




                //call stored procedure and fetch result
                if (parameters != null)
                    queryResult = await connection.QueryAsync(query, parameters, commandTimeout: 480);
                else
                    queryResult = await connection.QueryAsync(query, parameters, commandTimeout: 480);
                return queryResult;
            }
            catch (Exception ex)
            {
                // _logger.LogError($"MethodName : {nameof(CallSPAsync)} Date : {DateTime.Now} Message : {ex.Message} , InnerException : {ex.InnerException}");
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally { connection.Close(); connection.Dispose(); }
        }

        public async Task<T> CallSPAsync<T>(string spName, DynamicParameters? parameters = null)
        {
            T queryResult;


            var procedure = spName;
            try
            {
                connection.ConnectionString = _configuration.GetConnectionString("SSMS");



                //call stored procedure and fetch result
                if (parameters != null)
                {
                    var result = await connection.QueryAsync<T>(procedure, parameters, commandType: CommandType.StoredProcedure, commandTimeout: 480);
                    queryResult = result.FirstOrDefault();

                }
                else
                {
                    var result = await connection.QueryAsync<T>(procedure, commandType: CommandType.StoredProcedure, commandTimeout: 480);
                    queryResult = result.FirstOrDefault();
                }
             

                return queryResult;
            }
            catch (Exception ex)
            {
                // _logger.LogError($"MethodName : {nameof(CallSPAsync)} Date : {DateTime.Now} Message : {ex.Message} , InnerException : {ex.InnerException}");
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally { connection.Close(); connection.Dispose(); }
        }

        public async Task<IEnumerable<T>> QueryExecuteReaderToDB<T>(string query, DynamicParameters? parameters = null)
        {
            IEnumerable<T> queryResult;



            try
            {
                connection.ConnectionString = _configuration.GetConnectionString("SSMS");


                //call stored procedure and fetch result
                if (parameters != null)
                {
                    queryResult = await connection.QueryAsync<T>(query, parameters, commandTimeout: 480);

                }
                else
                {
                    queryResult = await connection.QueryAsync<T>(query, commandTimeout: 480);
                }
               
                return queryResult;
            }
            catch (Exception ex)
            {
                // _logger.LogError($"MethodName : {nameof(CallSPAsync)} Date : {DateTime.Now} Message : {ex.Message} , InnerException : {ex.InnerException}");
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally { connection.Close(); connection.Dispose(); }
        }
    }

}