using exmane1.Collections;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exmane1.Models
{
    public class ContextoMongo
    {
        public IMongoDatabase database;
        public ContextoMongo()
        {
            var connectionString = Properties.Settings.Default.mongoConnection;
            var client = new MongoClient(connectionString);
            database = client.GetDatabase(Properties.Settings.Default.databaseName);
        }

        public IMongoCollection<Estudiante> LosEstudiantes
        {
            get
            {
                return (database.GetCollection<Estudiante>("estudiante"));
            }
            set
            {
            }
        }

    }
}