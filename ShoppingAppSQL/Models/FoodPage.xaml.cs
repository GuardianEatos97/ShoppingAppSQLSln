
using System.Collections.ObjectModel;
using System.Transactions;
using ShoppingAppSQL.DataBaseItems;
using ShoppingAppSQL.Models;
using ShoppingAppSQL.ShoppingDatabaseServices;
namespace ShoppingAppSQL.Models;

public partial class FoodPage : ContentPage
{
    private ShoppingDatabase _database;

    private ObservableCollection<FoodItems> _foodItems;
    public ObservableCollection<FoodItems> FoodItems 
    {  get { return _foodItems; } 
       set 
       { _foodItems = value;
         OnPropertyChanged();
       }
    }
    private FoodItems _fooditems;

    public FoodItems Fooditems
    {
        get { return _fooditems; }
        set
        {
            _fooditems = value;

            OnPropertyChanged();

        }
    }
    private int _foodquantity;
    public int FoodQuantity 
    {
        get { return _foodquantity; }
        set 
        { _foodquantity = value; 
           OnPropertyChanged(); 
        }
    
    }
    private decimal _cartamount;
    public decimal CartAmount 
    {
        get { return _cartamount; }
        set 
        { _cartamount = value; 
           OnPropertyChanged(); 
        }
    }
	public FoodPage()
	{
        InitializeComponent();
        _database = new ShoppingDatabase();
        BindingContext = this;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadData();
    }
    public void LoadData() 
    {
        FoodItems = new ObservableCollection<FoodItems>(_database.GetFoodItems());
    }

    private List<CartItem> Basket = new List<CartItem>();
    private async void ViewBtn_Clicked(object sender, EventArgs e)
    {
        Button button = sender as Button;
        var item = button.CommandParameter as FoodItems;
        //Navigation.PushAsync(new FoodDetailsPage());
        //LoadItem();
        if (item != null)//(sender is Button button && button.BindingContext is FoodItems item)
        {
            CartItem AlreadyAdded = Basket.FirstOrDefault(i => i.FoodItemId == item.FoodItemId);
            if(AlreadyAdded != null) 
            {
                AlreadyAdded.ItemQuantity++;
                AlreadyAdded.CartPrice += item.FoodPrice;
            }
            else 
            {
                CartItem cartItem = new CartItem()
                {
                    CartItemId = item.FoodItemId,
                    FoodName = item.FoodName,
                    ItemQuantity = 1,
                    CartPrice = item.FoodPrice,
                    ItemImage = item.FoodImage,

                };
                Basket.Add(cartItem);
                _database.AddToDataBase(cartItem);
                await DisplayAlert("Notice", "Item Added To Cart", "Great");
            }
        }
    }

    private void LoadItem()
    {
        FoodItems foodItems = _database.GetItemById(1);

        Fooditems = foodItems;

    }
}