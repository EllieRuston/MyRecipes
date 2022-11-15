using MyRecipes.Models;
using MyRecipes.Views;
using System;
using MyRecipes.Services;
namespace MyRecipes.Views;


[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class AddRecipe : ContentPage
{
    public string ItemId
    {
        set
        {
            LoadRecipe(value);
        }
    }
    
    public AddRecipe()
    {
        InitializeComponent();
        BindingContext = new RecipeInfo();
    }

    async void LoadRecipe(string itemId)
    {
        try
        {
            int id = int.Parse(itemId);
            RecipeInfo recipe = await App.Database.GetRecipeAsync(id);
            BindingContext = recipe;
        }
        catch (Exception)
        {
            Console.WriteLine("failed to load recipe");
        }
    }

    // button functionality
    async void OnSaveButtonClicked(object sender, EventArgs e)
	{
		var recipe = (RecipeInfo)BindingContext;
		if (!string.IsNullOrWhiteSpace(recipe.R_Title))
		{ 
            await App.Database.SaveRecipeAsync(recipe);
		}
		await Shell.Current.GoToAsync("..");
	}

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var recipe = (RecipeInfo)BindingContext;
        await App.Database.DeleteRecipeAsync(recipe);

        // Navigate backwards
        await Shell.Current.GoToAsync("..");
    }

}