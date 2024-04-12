using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Define the namespace for the program, which encapsulates the RecipeManager class
namespace RecipeBook
{
    // Define an internal class named Ingredient to represent an ingredient in a recipe
    internal class Ingredient
    {
        // Public property to store the name of the ingredient
        public string Name { get; set; }

        // Public property to store the quantity of the ingredient
        public double Quantity { get; set; }

        // Public property to store the unit of measurement for the ingredient quantity
        public string Unit { get; set; }
    }
}
}
