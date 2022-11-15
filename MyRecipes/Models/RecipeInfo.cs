
using SQLite;

namespace MyRecipes.Models
{
    [Table("RecipeInfo")]
    public class RecipeInfo
    {
        [PrimaryKey, AutoIncrement]
        public int R_Id { get; set; }
        public string R_Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Ingredients { get; set; }
        public string Steps { get; set; }
        
    }
}
