using Dapper;
using DiaDeBolaClassLibrary;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DiaDeBolaClassLibrary
{
    public class SqliteDataAccess
    {
        public static List<EventMapper> LoadEvents(string connectionString) 
        {
            using (IDbConnection cnn = new SqliteConnection(connectionString)) 
            {
                var output = cnn.Query<EventMapper>("SELECT * FROM AspNetEvents", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveEvent(string connectionString, IEvent gameEvent) 
        {
            using (IDbConnection cnn = new SqliteConnection(connectionString))
            {
                cnn.Execute("INSERT INTO AspNetEvents " +
                    "(MaxNumberOfPlayers, Admins, Teams, DateTime, Location) " +
                    "values " +
                    "(@MaxNumberOfPlayers,@Admins, @Teams, @DateTime, @Location)", gameEvent);
            }
        }
    }
}
