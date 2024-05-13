
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Define the namespace for the program, which encapsulates the RecipeManager class
namespace RecipeBookPOE
{
    // Define an internal class named ScaledRecipe to represent a scaled version of a recipe
    internal class ScaledRecipe
    {
        // Public properties
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<Step> Steps { get; set; } = new List<Step>();
    }

    // Define a delegate for notifying user about recipe calorie exceedance
    internal delegate void RecipeCalorieExceedanceHandler(Recipe recipe);
}
