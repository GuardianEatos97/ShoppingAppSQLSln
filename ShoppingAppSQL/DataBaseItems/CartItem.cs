using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppSQL.DataBaseItems
{
    public class CartItem
    {
        [PrimaryKey,AutoIncrement]
        public int CartItemId { get; set; }
        public int ItemQuantity { get; set; }
        public decimal CartPrice { get; set; }
        public string FoodName { get; set;}
        public int FoodQuantity { get; set; }
        

        [ForeignKey(typeof(FoodItems))]
        public int FoodItemId { get; set;}
        public int FoodQantity { get; internal set; }
        public int FoodPrice { get; internal set; }
    }
}
