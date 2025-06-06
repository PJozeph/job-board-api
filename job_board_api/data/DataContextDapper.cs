using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace JobBoard.Data {
    public class DataContextDapper {

        private IConfiguration _config;

        public DataContextDapper(IConfiguration config) {
            _config = config;
        }

        public IEnumerable<T> LoadData<T>(string sql) {
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbConnection.Query<T>(sql);
        }

    }
}