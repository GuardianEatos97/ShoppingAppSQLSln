
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
        FoodItems.Clear();
        FoodItems = new ObservableCollection<FoodItems>(_database.GetFoodItems());
    }
}