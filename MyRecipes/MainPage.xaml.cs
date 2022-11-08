using MyRecipes.Views;

namespace MyRecipes;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    
    private async void Add_Recipe(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddRecipe());

    }
}

