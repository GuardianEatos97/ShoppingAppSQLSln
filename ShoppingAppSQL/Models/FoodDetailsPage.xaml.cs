using ShoppingAppSQL.DataBaseItems;

namespace ShoppingAppSQL.Models;

public partial class FoodDetailsPage : ContentPage
{
    private readonly CartViewModel _viewmodel;
    public FoodDetailsPage(FoodItemViewModel item)
	{
		InitializeComponent();
        BindingContext = item;
        _viewmodel = (CartViewModel)BindingContext;
    }

  /*  private void AddToCartBtn_Clicked(object sender, EventArgs e)
    {

        if (sender is Button button && button.BindingContext is CartItem item)
        {
            _viewmodel.AddItem(item);
        }
    }*/
        
}