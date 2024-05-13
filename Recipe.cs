using System.Collections.Generic;
using System.Linq;

namespace RecipeBookPOE
{
    internal class Recipe
    {
        // Public properties
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<Step> Steps { get; set; } = new List<Step>();

        // Properties to store original ingredients and steps
        public List<Ingredient> OriginalIngredients { get; set; } = new List<Ingredient>();
        public List<Step> OriginalSteps { get; set; } = new List<Step>();

        // Properties to store scaled ingredients and steps
        public List<Ingredient> ScaledIngredients { get; set; } = new List<Ingredient>();
        public List<Step> ScaledSteps { get; set; } = new List<Step>();

        // Method to calculate total calories for the original ingredients
        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories * ingredient.Quantity;
            }
            return totalCalories;
        }

        // Method to reset to original input
        public void ResetToOriginalInput()
        {
            // Restore original ingredients and steps
            Ingredients = new List<Ingredient>(OriginalIngredients.Select(i => new Ingredient
            {
                Name = i.Name,
                Quantity = i.Quantity,
                Unit = i.Unit,
                Calories = i.Calories,
                FoodGroup = i.FoodGroup
            }));
            Steps = new List<Step>(OriginalSteps.Select(s => new Step { Description = s.Description }));

            // Update original ingredients and steps to reflect changes
            OriginalIngredients = new List<Ingredient>(Ingredients.Select(i => new Ingredient
            {
                Name = i.Name,
                Quantity = i.Quantity,
                Unit = i.Unit,
                Calories = i.Calories,
                FoodGroup = i.FoodGroup
            }));
            OriginalSteps = new List<Step>(Steps.Select(s => new Step { Description = s.Description }));

            // Clear scaled ingredients and steps
            ScaledIngredients.Clear();
            ScaledSteps.Clear();
        }
    }
}