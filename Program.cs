using System;
using System.Collections.Generic;

namespace RecipeBookPOE
{
    class Program
    {
        static List<Recipe> recipes = new List<Recipe>(); // Collection to store recipes

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nTHE RECIPE BOOK");
                Console.ResetColor();
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Enter a recipe");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("3. Select a recipe");
                Console.WriteLine("4. Scale a recipe");
                Console.WriteLine("5. Reset a recipe");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("6. Exit");
                Console.ResetColor();

                Console.Write("\nEnter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        EnterRecipe();
                        break;
                    case 2:
                        DisplayAllRecipes();
                        break;
                    case 3:
                        SelectRecipe();
                        break;
                    case 4:
                        ScaleRecipe();
                        break;
                    case 5:
                        ResetRecipe();
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        break;
                }
            }
        }

        static void EnterRecipe()
        {
            Recipe recipe = new Recipe();
            Console.WriteLine("\nEnter details for the recipe:");
            Console.Write("Enter name of the recipe: ");
            recipe.Name = Console.ReadLine();

            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());
            recipe.Ingredients = new List<Ingredient>();
            recipe.OriginalIngredients = new List<Ingredient>(); // Initialize the originalIngredients list

            double totalCalories = 0; // To calculate total calories

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter details for ingredient {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write("Unit: ");
                string unit = Console.ReadLine();
                Console.Write("Calories: ");
                double calories = double.Parse(Console.ReadLine());
                Console.Write("Food Group: ");
                string foodGroup = Console.ReadLine();

                // Calculate total calories
                totalCalories += calories;

                // Add the ingredient to both Ingredients and originalIngredients
                recipe.Ingredients.Add(new Ingredient { Name = name, Quantity = quantity, Unit = unit, Calories = calories, FoodGroup = foodGroup });
                recipe.OriginalIngredients.Add(new Ingredient { Name = name, Quantity = quantity, Unit = unit, Calories = calories, FoodGroup = foodGroup });
            }

            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());
            recipe.Steps = new List<Step>();
            recipe.OriginalSteps = new List<Step>(); // Initialize the originalSteps list

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter details for step {i + 1}:");
                Console.Write("Description: ");
                string description = Console.ReadLine();

                // Add the step to both Steps and originalSteps
                recipe.Steps.Add(new Step { Description = description });
                recipe.OriginalSteps.Add(new Step { Description = description });
            }

            // Confirm successful entry of recipe
            Console.WriteLine("Recipe entered successfully.");

            // Check if total calories exceed 300 and display a warning if necessary
            if (totalCalories > 300)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning: This recipe exceeds 300 calories!");
                Console.ResetColor();
            }

            // Add the recipe to the list of recipes
            recipes.Add(recipe);
        }

        static void DisplayAllRecipes()
        {
            Console.WriteLine("\nAll Recipes:");
            recipes.Sort((r1, r2) => string.Compare(r1.Name, r2.Name));
            foreach (var recipe in recipes)
            {
                Console.WriteLine($"- {recipe.Name}");
            }
        }

        static void SelectRecipe()
        {
            Console.WriteLine("\nSelect a recipe:");
            DisplayAllRecipes();
            Console.Write("\nEnter the name of the recipe: ");
            string recipeName = Console.ReadLine();
            Recipe selectedRecipe = recipes.Find(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (selectedRecipe != null)
            {
                DisplayRecipe(selectedRecipe);
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        static void ScaleRecipe()
        {
            Console.WriteLine("\nSelect a recipe to scale:");
            DisplayAllRecipes();
            Console.Write("\nEnter the name of the recipe: ");
            string recipeName = Console.ReadLine();
            Recipe selectedRecipe = recipes.Find(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (selectedRecipe != null)
            {
                Console.WriteLine("\nSelect scaling factor:");
                Console.WriteLine("1. 0.5x");
                Console.WriteLine("2. 2x");
                Console.WriteLine("3. 3x");
                Console.Write("\nEnter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                double factor = 1.0;
                switch (choice)
                {
                    case 1:
                        factor = 0.5;
                        break;
                    case 2:
                        factor = 2.0;
                        break;
                    case 3:
                        factor = 3.0;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Recipe will not be scaled.");
                        return;
                }

                // Update ingredients with scaled quantities
                foreach (var ingredient in selectedRecipe.Ingredients)
                {
                    ingredient.Quantity *= factor;
                }

                // Update the original ingredients with scaled quantities
                foreach (var ingredient in selectedRecipe.OriginalIngredients)
                {
                    ingredient.Quantity *= factor;
                }

                

                // Display the scaled recipe
                Console.WriteLine("\nScaled Recipe:");
                DisplayRecipe(selectedRecipe);
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        static void ResetRecipe()
        {
            // Prompt the user to select a recipe to reset
            Console.WriteLine("\nSelect a recipe to reset:");
            DisplayAllRecipes(); // Display all available recipes
            Console.Write("\nEnter the name of the recipe: ");
            string recipeName = Console.ReadLine(); // Get the name of the recipe from the user

            // Find the selected recipe by name
            Recipe selectedRecipe = recipes.Find(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (selectedRecipe != null)
            {
                // Get a copy of the original inputted recipe
                Recipe originalRecipe = GetOriginalRecipe(selectedRecipe);

                // Reset the ingredients and steps of the selected recipe to the original input values
                selectedRecipe.ResetToOriginalInput();
                Console.WriteLine("Recipe has been reset to its original input.");

                // Display the original inputted recipe
                Console.WriteLine("\nOriginal Inputted Recipe:");
                DisplayRecipe(originalRecipe);
            }
            else
            {
                // Display a message if the selected recipe is not found
                Console.WriteLine("Recipe not found.");
            }
        }

        // Helper method to retrieve the original inputted recipe
        static Recipe GetOriginalRecipe(Recipe selectedRecipe)
        {
            // Create a new Recipe object with the same properties as the selected recipe
            // but with original ingredients and steps
            return new Recipe
            {
                Name = selectedRecipe.Name,
                Ingredients = new List<Ingredient>(selectedRecipe.OriginalIngredients),
                Steps = new List<Step>(selectedRecipe.OriginalSteps)
            };
        }

        static void DisplayRecipe(Recipe recipe)
        {
            Console.WriteLine($"\nRecipe Name: {recipe.Name}");

            Console.WriteLine("Ingredients:");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < recipe.Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipe.Steps[i].Description}");
            }
        }

        static void NotifyIfCaloriesExceed(Recipe recipe)
        {
            if (recipe.CalculateTotalCalories() > 300)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning: This recipe exceeds 300 calories!");
                Console.ResetColor();
            }
        }
    }
}