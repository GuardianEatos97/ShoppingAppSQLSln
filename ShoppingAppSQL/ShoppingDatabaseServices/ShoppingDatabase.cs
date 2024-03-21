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
            _dbConnection.CreateTable<FoodItems>();

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

                if (_dbConnection.Table<FoodItems>().Count() == 0) 
                {
                    List<FoodItems> foodItems = new List<FoodItems>()
                    {
                        new FoodItems()
                        {
                        FoodImage = "water.png",
                        FoodName = "Nestle Pure Life Water 500ml",
                        FoodPrice = 17,
                        FoodQuantity = 150,
                        FoodDescription = "Enjoy the unique flavour and taste of our natural spring water, bottled at the source."
                        },

                        new FoodItems()
                        {
                        FoodImage = "coke.png",
                        FoodName = "Coca-Cola No Sugar 2L",
                        FoodPrice = 28,
                        FoodQuantity = 88,
                        FoodDescription = "Welcome to the generation of NO. A generation that believes in NO rules, NO heat, NO labels and NO limits. This is a generation that enjoys the right to be free and do whatever makes them happy, even when others don’t agree. Beyond just the flavour, Coke No Sugar is an attitude!"

                        },

                        new FoodItems()
                        {
                        FoodImage = "fruits.jpg",
                        FoodName = "Assorted Fruit Mix",
                        FoodPrice = 45,
                        FoodQuantity = 250,
                        FoodDescription = "Our Delicious, Fresh and Healthy, Mixed Fruit, comes in a convenient bulk 1 KG unit. Fruits included is apple, apricots, peaches, pears, prunes and much much more."

                        },

                        new FoodItems()
                        {
                        FoodImage = "cupcakes.jpg",
                        FoodName = "Bar-One Cupcakes",
                        FoodPrice = 22,
                        FoodQuantity = 14,
                        FoodDescription = "Come and try our new addition to the in-store bakery. Baked fresh daily and served with love. Our bar-one is definitely number one."

                        },

                        new FoodItems()
                        {
                        FoodImage = "pies.jpg",
                        FoodName = "Baked Chicken Pies",
                        FoodPrice = 15,
                        FoodQuantity = 50,
                        FoodDescription = "Our pies are baked fresh daily. Enjoy the flakey dough and our succulent chicken filling."
                        }
                    };
                    
                    _dbConnection.InsertAll(foodItems); 
                  
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
        public List<FoodItems> GetFoodItems() 
        {
            return _dbConnection.Table<FoodItems>().ToList();
        }

        public FoodItems GetItemById(int id)
        {
            FoodItems foodItems = _dbConnection.Table<FoodItems>().Where(x => x.FoodItemId == id).FirstOrDefault();

            if (foodItems != null)
                _dbConnection.GetChildren(foodItems, true);

            return foodItems;
        }

    }
} 

