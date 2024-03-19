using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Extensions;
using SQLitePCL;
using ShoppingAppSQL.DataBaseItems;

namespace ShoppingAppSQL.ShoppingDatabaseServices
{
    public class ShoppingDatabase
    {
        private SQLiteConnection _dbConnection;

        public string GetDatabasePath()
        {
            string filename = "shoppingdata.db";
            string pathToDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(pathToDb, filename);
        }

        public ShoppingDatabase()
        {

            _dbConnection = new SQLiteConnection(GetDatabasePath());

            _dbConnection.CreateTable<Client>();
            _dbConnection.CreateTable<ClientType>();

            SeedDatabase();
        }

        public void SeedDatabase()
        {
            if (_dbConnection.Table<ClientType>().Count() == 0)
            {

                ClientType clientType = new ClientType()
                {
                    ClientTypeDescription = "Cash Client"
                };

                _dbConnection.Insert(clientType);

                clientType = new ClientType()
                {
                    ClientTypeDescription = "Credit Account Holder"
                };

                _dbConnection.Insert(clientType);

                if (_dbConnection.Table<Client>().Count() == 0)
                {

                    Client client = new Client()
                    {
                        ClientName = "",
                        ClientSurname = "",
                        ClientEmail = "",
                        ContactNumber = "",
                        ClientPassword = "",
                    };

                    _dbConnection.Insert(client);
                } 

            }

                
        }

        public List<ClientType> GetAllClientTypes()
        {
            var clientTypes = _dbConnection.Table<ClientType>().ToList();

            return clientTypes;
        }

        public List<Client> GetAllClients()
        {
            return _dbConnection.Table<Client>().ToList();
        }

        public void UpdateClient(Client client)
        {
            _dbConnection.Update(client);
        }

        public Client GetClientById(int id)
        {
            Client client = _dbConnection.Table<Client>().Where(x => x.ClientId == id).FirstOrDefault();

            if (client != null)
                _dbConnection.GetChildren(client, true);

            return client;
        }
    }
} 

