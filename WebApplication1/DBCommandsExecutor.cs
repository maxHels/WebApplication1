using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class DBCommandsExecutor
    {
        private MySqlConnection WordpressDbConnection { get; set; } 

        public DBCommandsExecutor()
        {
            var server = "35.196.212.207";
            var database = "wordpress";
            var uid = "root";
            var password = "yyY9AH8HQKt64G";
            string connectionString = "SERVER=" + server + "; DATABASE=" + database + "; UID=" + uid + "; PASSWORD=" + password + ";";
            WordpressDbConnection = new MySqlConnection(connectionString);
        }

        public IEnumerable<string> GetStringListResult(string command, string dbField)
        {
            List<string> toReturn = new List<string>();
            try
            {
                using (WordpressDbConnection)
                {
                    WordpressDbConnection.Open();
                    MySqlCommand executingCommand = new MySqlCommand(command, WordpressDbConnection);
                    MySqlDataReader reader = executingCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        toReturn.Add(reader[dbField].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                toReturn.Add("Something went wrong " + e.ToString());
            }
            return toReturn;
        }
    }
}
