using System;
using System.Collections.Generic;
using System.Linq; 
using System.Web;
using Dapper;

namespace DutyFreePraxe.Models
{

    public static class DapperORM
    {
        private static string connectionString = @"Data Source=localhost;Database=DutyFreeDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param)
        {

        }

    }
}