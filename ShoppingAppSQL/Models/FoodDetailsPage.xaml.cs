using ShoppingAppSQL.DataBaseItems;

namespace ShoppingAppSQL.Models;

public partial class FoodDetailsPage : ContentPage
{
    public FoodDetailsPage()
    {
    }

    public FoodDetailsPage(FoodItemViewModel item)
	{
		InitializeComponent();
		BindingContext = item;
	}
}