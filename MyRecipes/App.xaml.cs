using System.IO;
using MyRecipes.Models;
using MyRecipes.Services;


namespace MyRecipes;

public partial class App : Application
{
    static RecipeService database;
	
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
 
	}

	public static RecipeService Database
	{ get 
		{
			if (database == null)
			{
				database = new RecipeService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Recipes.db3"));
			}
			return database;
		} 
	}

    protected override void OnStart() { }
	protected override void OnSleep() { }
	protected override void OnResume() { }
}
