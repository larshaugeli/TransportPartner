﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TransportPartner.Tools
{
    public class AdministrationManager
    {
        public async Task connect()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "transportpartner.mysql.database.azure.com",
                Database = "transportpartner",
                UserID = "lhhaugel@transportpartner",
                Password = "Mjaupus12345",
                SslMode = MySqlSslMode.Required,
            };

            await using var conn = new MySqlConnection(builder.ConnectionString);
            Console.WriteLine("Opening connection");
            await conn.OpenAsync();

            await using (var command = conn.CreateCommand())
            {
                command.CommandText = "DROP TABLE IF EXISTS inventory;";
                await command.ExecuteNonQueryAsync();
                Console.WriteLine("Finished dropping table (if existed)");

                command.CommandText = "CREATE TABLE inventory (id serial PRIMARY KEY, name VARCHAR(50), quantity INTEGER);";
                await command.ExecuteNonQueryAsync();
                Console.WriteLine("Finished creating table");

                command.CommandText = @"INSERT INTO inventory (name, quantity) VALUES (@name1, @quantity1),
                        (@name2, @quantity2), (@name3, @quantity3);";
                command.Parameters.AddWithValue("@name1", "banana");
                command.Parameters.AddWithValue("@quantity1", 150);
                command.Parameters.AddWithValue("@name2", "orange");
                command.Parameters.AddWithValue("@quantity2", 154);
                command.Parameters.AddWithValue("@name3", "apple");
                command.Parameters.AddWithValue("@quantity3", 100);

                int rowCount = await command.ExecuteNonQueryAsync();
                Console.WriteLine(String.Format("Number of rows inserted={0}", rowCount));
            }

            // connection will be closed by the 'using' block
            Console.WriteLine("Closing connection");
        }
    }
}
