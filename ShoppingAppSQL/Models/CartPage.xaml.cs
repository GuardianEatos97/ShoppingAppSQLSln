using ShoppingAppSQL.DataBaseItems;
using ShoppingAppSQL.ShoppingDatabaseServices;
using System.Collections.ObjectModel;
namespace ShoppingAppSQL.Models;

public partial class CartPage : ContentPage
{
    
    private ShoppingDatabase _database;
    private ObservableCollection<CartItem> _basketitems;
    public ObservableCollection<CartItem> BasketItems 
    {
        get {return _basketitems;}
        set 
        { _basketitems = value;
            OnPropertyChanged();
        }
    }
    public decimal TotalPrice => BasketItems.Sum(item => item.FoodPrice * item.FoodQantity);
    public CartPage()
    {
        InitializeComponent();
        //_viewModel = (CartViewModel)BindingContext;
        BindingContext = this;
        _database = new ShoppingDatabase();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadData();
    }
    public void LoadData() 
    {
        BasketItems = new ObservableCollection<CartItem>(_database.GetCartItems());//See if additional code is needed here
    }
    private void OnRemoveClicked(object sender, EventArgs e)
    {
        Button button = sender as Button;
        var item = button.CommandParameter as CartItem;
        if (item != null)//(sender is Button button && button.BindingContext is CartItem item)
        {
            BasketItems.Remove(item);
            _database.GetCartItems().Remove(item); //Check this
        }
    }
}