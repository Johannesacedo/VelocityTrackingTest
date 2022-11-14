using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace VelocityTrackingTest.Models
{
    public class DapperORM
    {
        private static string connectionString = @"Data Source=JOHANNES-PC;Initial Catalog=VelocityTrackingTestDB;Integrated Security=True";

        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param)
        {
            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlConnection.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }

        public static T ExecuteScalar<T>(string procedureName, DynamicParameters param)
        {
            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                return (T) Convert.ChangeType(sqlConnection.ExecuteScalar(procedureName, param, commandType: CommandType.StoredProcedure), typeof(T));
            }
        }

        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                return sqlConnection.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
