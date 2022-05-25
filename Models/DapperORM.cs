using System;
using System.Collections.Generic;
using System.Linq; 
using System.Web;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace DutyFreePraxe.Models
{

    public static class DapperORM
    {
        private static string connectionString = @"Data Source=localhost;Database=DutyFreeDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param)
        {
           using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                sqlCon.Execute(procedureName,param,commandType: CommandType.StoredProcedure);
            }
        }

        //DapperORM.ExecuteReturnScalar<int>(_,_);
        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param)
        {
           using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                return (T)Convert.ChangeType(sqlCon.Execute(procedureName,param,commandType: CommandType.StoredProcedure),typeof(T));
            }
        }

        //DapperORM.ReturnList<ProductModel> <= IEnumerable<ProductModel>
        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param)
        {
           using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(procedureName,param,commandType: CommandType.StoredProcedure);
            }
        }

    }
}