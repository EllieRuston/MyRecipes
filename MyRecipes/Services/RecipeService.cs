using MyRecipes.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Services
{
    public class RecipeService 
    {
        readonly SQLiteAsyncConnection database;
        
        public RecipeService(string dbPath)
        {    database = new SQLiteAsyncConnection(dbPath);
             database.CreateTableAsync<RecipeInfo>().Wait();
        }

        public Task<List<RecipeInfo>> GetRecipesAsync()
        {   //Get all notes.
            return database.Table<RecipeInfo>().ToListAsync();
        }

        public Task<RecipeInfo> GetRecipeAsync(int id)
        {   // Get a specific note.
            return database.Table<RecipeInfo>()
                            .Where(i => i.R_Id == id)
                            .FirstOrDefaultAsync();
        }


        public Task<int> SaveRecipeAsync(RecipeInfo recipe)
        {
            if (recipe.R_Id != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(recipe);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(recipe);
            }
        }

        // delete record
        public Task<int> DeleteRecipeAsync(RecipeInfo recipe)
        {
            // Delete a note.
            return database.DeleteAsync(recipe);
        }


    }
}
