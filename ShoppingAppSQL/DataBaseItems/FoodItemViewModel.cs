using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ShoppingAppSQL.Models;
using ShoppingAppSQL.DataBaseItems;

namespace ShoppingAppSQL.DataBaseItems
{
    public class FoodItemViewModel
    {
        public ObservableCollection<FoodItems> FoodItems { get; set; }

        //public ObservableCollection<FoodItems> CartProducts { get; set; }

        public FoodItems SelectedProduct { get; set; }

        public ICommand ProductClick { get; set; }

        //public ICommand CartProductClick { get; set; }
        public FoodItemViewModel(INavigation navigation) 
        {
            FoodItems = new ObservableCollection<FoodItems>
            {
                new FoodItems()
                {
                    FoodImage = "water.png",
                    FoodName = "Nestle Pure Life Water 500ml",
                    FoodPrice = 17,
                    FoodQuantity = 150,
                    FoodDescription = "Enjoy the unique flavour and taste of our natural spring water, bottled at the source.",

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

                },
            };

            //CartProducts = new ObservableCollection<FoodItems> { };

            ProductClick = new Command<FoodItems>(executeProductClickCommand);

            //CartProductClick = new Command<FoodItems>(executeCartProductClickCommand);

            this.navigation = navigation;
        }
        private INavigation navigation;

        async void executeProductClickCommand(FoodItems item)
        {
            this.SelectedProduct = item;
            await navigation.PushModalAsync(new FoodDetailsPage(this));
        }

        //async void executeCartProductClickCommand(FoodItems item)
        //{
        //    this.CartProducts.Add(this.SelectedProduct);
        //    //await navigation.PushModalAsync(new CartPage(this));
        //}

    }
}
