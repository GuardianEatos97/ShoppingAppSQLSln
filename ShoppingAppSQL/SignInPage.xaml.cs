using ShoppingAppSQL.ShoppingDatabaseServices;
using ShoppingAppSQL.DataBaseItems;
using System.Collections.ObjectModel;
using System.Transactions;

namespace ShoppingAppSQL;

public partial class SignInPage : ContentPage
{
    private ShoppingDatabase _database;

    private Client _currentClient;

    public Client CurrentClient
    {
        get { return _currentClient; }
        set
        {
            _currentClient = value;

            OnPropertyChanged();

        }
    }

    public SignInPage()
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

    private void LoadButton_Clicked(object sender, EventArgs e)
    {
        LoadData();
    }

    private void LoadData()
    {
        Client client = _database.GetClientById(1);

        CurrentClient = client;

    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        _database.UpdateClient(CurrentClient);
        await DisplayAlert("Profile Saved", "Your Profile has been saved", "Okay");
    }
   
}
