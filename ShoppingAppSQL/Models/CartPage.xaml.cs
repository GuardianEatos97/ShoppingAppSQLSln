using ShoppingAppSQL.DataBaseItems;
namespace ShoppingAppSQL.Models;

public partial class CartPage : ContentPage
{
    private readonly CartViewModel _viewModel;

    public CartPage()
    {
        InitializeComponent();
        _viewModel = (CartViewModel)BindingContext;
    }

    private void OnRemoveClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is CartItem item)
        {
            _viewModel.RemoveItem(item);
        }
    }
}