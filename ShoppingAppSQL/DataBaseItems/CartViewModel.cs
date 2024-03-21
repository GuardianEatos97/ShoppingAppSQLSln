using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppSQL.DataBaseItems
{
    public class CartViewModel : BindableObject
    {
        private ObservableCollection<CartItem> _cartItems = new ObservableCollection<CartItem>();
        public ObservableCollection<CartItem> CartItems
        {
            get => _cartItems;
            set { _cartItems = value; OnPropertyChanged(); }
        }

        //public decimal TotalPrice => CartItems.Sum(item => item.FoodName.FoodPrice * item.FoodQantity);

        //public void AddItem(FoodItems product)
        //{
        //    var existingItem = CartItems.FirstOrDefault(item => item.Product.FoodName == product.FoodName);
        //    if (existingItem != null)
        //    {
        //        existingItem.Quantity++;
        //    }
        //    else
        //    {
        //        CartItems.Add(new CartItem { FoodName = product, Quantity = 1 });
        //    }
        //    OnPropertyChanged(nameof(TotalPrice));
        //}

        //public void RemoveItem(CartItem item)
        //{
        //    CartItems.Remove(item);
        //    OnPropertyChanged(nameof(TotalPrice));
        //}
    }
}
