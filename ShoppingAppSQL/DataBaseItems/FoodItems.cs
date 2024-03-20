using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppSQL.DataBaseItems
{
     public class FoodItems
     {
        public string FoodName { get; set; }
        public int FoodQuantity { get; set; }
        public string FoodImage { get; set; }
        public decimal FoodPrice { get; set; }
        public string FoodDescription { get; set;}
     }
}
