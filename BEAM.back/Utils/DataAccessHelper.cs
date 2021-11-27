using System;

namespace BEAM.back.Utils
{
    public class DataAccessHelper
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }

        public string GetConnectionString()
        {
            return $"Host={Host};Port={Port};Username={Username};Password={Password};Database={Database}";
        }
        public static string ConnectionString()
        {
            return new DataAccessHelper()
            {
                Host = Environment.GetEnvironmentVariable("HOST"),
                Port = int.Parse(Environment.GetEnvironmentVariable("PORT")),
                Username = Environment.GetEnvironmentVariable("USERNAME"),
                Password = Environment.GetEnvironmentVariable("PASSWORD"),
                Database = Environment.GetEnvironmentVariable("DATABASE"),
            }.GetConnectionString();
        }
    }
}
