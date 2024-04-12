using RecipeBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Define the namespace for the program, which encapsulates the RecipeManager class
namespace RecipeBook
{
    // Define an internal class named Recipe to represent a recipe
    internal class Recipe
    {
        // Public property to store the name of the recipe
        public string Name { get; set; }

        // Public property to store an array of ingredients in the recipe
        public Ingredient[] Ingredients { get; set; }

        // Public property to store an array of steps in the recipe
        public Step[] Steps { get; set; }
    }
}
