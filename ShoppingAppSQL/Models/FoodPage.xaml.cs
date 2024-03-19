
using System.Collections.ObjectModel;
using System.Transactions;
using ShoppingAppSQL.DataBaseItems;
using ShoppingAppSQL.Models;
namespace ShoppingAppSQL.Models;

public partial class FoodPage : ContentPage
{
	public FoodPage()
	{
        InitializeComponent();
        this.BindingContext = new FoodItemViewModel(this.Navigation);
    }

    void ListView_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
        Console.WriteLine("I got clicked");
    }
}