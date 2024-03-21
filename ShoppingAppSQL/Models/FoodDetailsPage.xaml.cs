using ShoppingAppSQL.DataBaseItems;
using ShoppingAppSQL.ShoppingDatabaseServices;

namespace ShoppingAppSQL.Models;

public partial class FoodDetailsPage : ContentPage
{
    private ShoppingDatabase _database;

    public FoodDetailsPage()
    {
    }

    //private readonly CartViewModel _viewmodel;
    public FoodDetailsPage(FoodItemViewModel item)
	{
		InitializeComponent();
        this.BindingContext = item;
        _database = new ShoppingDatabase();
        //_viewmodel = (CartViewModel)BindingContext;
    }

  /*  private void AddToCartBtn_Clicked(object sender, EventArgs e)
    {

        if (sender is Button button && button.BindingContext is CartItem item)
        {
            _viewmodel.AddItem(item);
        }
    }*/
        
}