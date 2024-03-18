using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppSQL.DataBaseItems
{
    public class FoodItemViewModel
    {
        public ObservableCollection<FoodItems> FoodItems { get; set; }
        public FoodItemViewModel() 
        {
            FoodItems = new ObservableCollection<FoodItems>
            {
                new FoodItems
                {
                    FoodImage = "water.png",
                    FoodName = "Nestle Pure Life Water 500ml",
                    FoodPrice = "R17",
                    FoodQuantity = "150",

                },

                new FoodItems
                {
                    FoodImage = "coke.png",
                    FoodName = "Coca-Cola No Sugar",
                    FoodPrice = "R28",
                    FoodQuantity = "88",

                },

                new FoodItems
                {
                    FoodImage = "fruits.jpg",
                    FoodName = "Assorted Fruits",
                    FoodPrice = "R45/Kg",
                    FoodQuantity = "Store Dependant",

                },

                new FoodItems
                {
                    FoodImage = "cupcakes.jpg",
                    FoodName = "Bar-One Cupcakes",
                    FoodPrice = "R22 each",
                    FoodQuantity = "14",

                },
                new FoodItems
                {
                    FoodImage = "pies.jpg",
                    FoodName = "Baked Pies (Assorted)",
                    FoodPrice = "R15 each",
                    FoodQuantity = "51",

                },
            };
        }
    }
}
