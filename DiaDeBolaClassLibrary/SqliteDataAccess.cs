using Dapper;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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
            string serializedEvent = gameEvent.ToJson();

            using (IDbConnection cnn = new SqliteConnection(connectionString))
            {
                cnn.Execute("INSERT INTO AspNetEvents " +
                    "(JsonEventContent) " +
                    "values " +
                    "(@serializedEvent)", new { serializedEvent } );
            }
        }

        public static List<string> LoadContacts(string connectionString, IRegisteredUser user)
        {
            using (IDbConnection cnn = new SqliteConnection(connectionString))
            {
                var output = cnn.Query<string>("SELECT Contact FROM AspNetContacts WHERE ListOwner = '@Email'", user);
                return output.ToList();
            }
        }

        public static void SaveContact(string connectionString, IRegisteredUser user, string contactToSave)
        {
            
            using (IDbConnection cnn = new SqliteConnection(connectionString))
            {
                cnn.Execute("INSERT INTO AspNetContacts " +
                    "(ListOwner,Contact) " +
                    "values " +
                    "(@Email, @NewContact)", new { user.Email, NewContact = contactToSave});
            }
        }
    }
}
