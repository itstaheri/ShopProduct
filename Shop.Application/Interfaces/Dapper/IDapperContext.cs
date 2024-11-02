using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces.Dapper
{
    public interface IDapperContext
    {
        Task<object> QueryExecuteReaderToDB(string tableName, DynamicParameters? parameters = null);
        Task<IEnumerable<T>> QueryExecuteReaderToDB<T>(string query, DynamicParameters? parameters = null);
        Task<object> CallSPAsync(string spName, DynamicParameters? parameters = null);
        Task<T> CallSPAsync<T>(string spName, DynamicParameters? parameters = null);
        object CallSP(string spName, DynamicParameters? parameters = null);
        Task BulkInsertAsync(DataTable dataTable);
        DataTable ToDataTable<T>(List<T> items);
        DataSet ToDataSet<T>(List<T> list);
    }
}
