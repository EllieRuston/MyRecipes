using MyRecipes.Views;

namespace MyRecipes;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(AddRecipe), typeof(AddRecipe));
	}
}
