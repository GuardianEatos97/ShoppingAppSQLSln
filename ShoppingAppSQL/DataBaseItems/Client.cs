using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppSQL.DataBaseItems
{
    public class Client
    {
        [PrimaryKey,AutoIncrement]
        public int ClientId { get; set; } 
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientEmail { get; set; }
        public string ContactNumber { get; set; }
        public string ClientPassword { get; set; }

        [ForeignKey(typeof(ClientType))]
        public int ClientTypeId { get; set; }

        [OneToOne]
        public ClientType ClientType { get; set; }
    }
}
