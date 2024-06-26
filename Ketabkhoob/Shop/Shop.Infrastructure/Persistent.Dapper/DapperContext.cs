﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Dapper
{
    public class DapperContext
    {
        private readonly string _connectionString;

        public DapperContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public string Inventories => "[Seller].Inventories";
        public string OrderItems => "[Order].Items";
        public string Products => "[Product].Products";
        public string Sellers => "[Seller].Sellers";
    }
}
