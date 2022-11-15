using MyRecipes.Views;
using MyRecipes.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace MyRecipes;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {   // load all recipes
        base.OnAppearing();
        collectionView.ItemsSource = await App.Database.GetRecipesAsync();
    }

    async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null)
        {
            // Navigate to the NoteEntryPage, passing the ID as a query parameter.
            RecipeInfo recipe = (RecipeInfo)e.CurrentSelection.FirstOrDefault();
            await Shell.Current.GoToAsync($"{nameof(AddRecipe)}?{nameof(AddRecipe.ItemId)}={recipe.R_Id.ToString()}");
        }
    }

    async void OnAddClicked(object sender, EventArgs e)
    {
       // await Shell.Current.GoToAsync(nameof(AddRecipe));
        await Navigation.PushAsync(new AddRecipe());

    }
}

