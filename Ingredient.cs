using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Define the namespace for the program, which encapsulates the RecipeManager class
namespace RecipeBookPOE
{
    // Define an internal class named Ingredient to represent an ingredient in a recipe
    internal class Ingredient
    {
        // Public properties
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }
    }
}

