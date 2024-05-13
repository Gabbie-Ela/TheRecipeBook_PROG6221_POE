using System;
using System.Collections.Generic;

namespace RecipeBookPOE
{
    class Program
    {
        static List<Recipe> recipes = new List<Recipe>(); // Collection to store recipes

        static void Main(string[] args)
        {
            bool exit = false; // Declare and initialize a boolean variable to control program exit
            while (!exit) // Start a loop until exit flag is true
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow; // Set text color to dark yellow
                Console.WriteLine("\nTHE RECIPE BOOK"); // Display program title
                Console.ResetColor(); // Reset text color to default
                Console.WriteLine("\nMenu:"); // Display menu options
                Console.WriteLine("1. Enter a recipe"); // Option to enter a recipe
                Console.WriteLine("2. Display all recipes"); // Option to display all recipes
                Console.WriteLine("3. Select a recipe"); // Option to select a specific recipe
                Console.WriteLine("4. Scale a recipe"); // Option to scale a recipe
                Console.WriteLine("5. Reset a recipe"); // Option to reset a recipe
                Console.ForegroundColor = ConsoleColor.DarkRed; // Set text color to dark red
                Console.WriteLine("6. Exit"); // Option to exit the program
                Console.ResetColor(); // Reset text color to default

                Console.Write("\nEnter your choice: "); // Prompt user for choice
                int choice = int.Parse(Console.ReadLine()); // Read user input and parse it as an integer

                switch (choice) // Switch statement to handle user's choice
                {
                    case 1: // If user chooses option 1
                        EnterRecipe(); // Call method to enter a recipe
                        break;
                    case 2: // If user chooses option 2
                        DisplayAllRecipes(); // Call method to display all recipes
                        break;
                    case 3: // If user chooses option 3
                        SelectRecipe(); // Call method to select a recipe
                        break;
                    case 4: // If user chooses option 4
                        ScaleRecipe(); // Call method to scale a recipe
                        break;
                    case 5: // If user chooses option 5
                        ResetRecipe(); // Call method to reset a recipe
                        break;
                    case 6: // If user chooses option 6
                        exit = true; // Set exit flag to true to exit the loop
                        break;
                    default: // If user enters an invalid choice
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6."); // Display error message
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
            // Prompt the user to select a recipe to scale
            Console.WriteLine("\nSelect a recipe to scale:");
            // Display all available recipes
            DisplayAllRecipes();
            // Prompt the user to enter the name of the recipe to scale
            Console.Write("\nEnter the name of the recipe: ");
            // Read the name of the recipe from the user input
            string recipeName = Console.ReadLine();
            // Find the recipe with the specified name in the recipes list
            Recipe selectedRecipe = recipes.Find(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            // Check if the selected recipe is found
            if (selectedRecipe != null)
            {
                // Display options for scaling factors
                Console.WriteLine("\nSelect scaling factor:");
                Console.WriteLine("1. 0.5x");
                Console.WriteLine("2. 2x");
                Console.WriteLine("3. 3x");
                // Prompt the user to enter the choice of scaling factor
                Console.Write("\nEnter your choice: ");
                // Read the choice of scaling factor from the user input
                int choice = int.Parse(Console.ReadLine());
                // Initialize a variable to hold the scaling factor, default value is 1.0
                double factor = 1.0;
                // Switch statement to handle different choices of scaling factors
                switch (choice)
                {
                    // If choice is 1, set the scaling factor to 0.5
                    case 1:
                        factor = 0.5;
                        break;
                    // If choice is 2, set the scaling factor to 2.0
                    case 2:
                        factor = 2.0;
                        break;
                    // If choice is 3, set the scaling factor to 3.0
                    case 3:
                        factor = 3.0;
                        break;
                    // If choice is not valid, display a message and return from the method
                    default:
                        Console.WriteLine("Invalid choice. Recipe will not be scaled.");
                        return;
                }

                // Update ingredients with scaled quantities
                foreach (var ingredient in selectedRecipe.Ingredients)
                {
                    ingredient.Quantity *= factor;
                    ingredient.Calories *= factor;
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
                DisplayRecipe(selectedRecipe);
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
                Ingredients = selectedRecipe.OriginalIngredients,
                Steps = selectedRecipe.OriginalSteps
            };
        }

        static void DisplayRecipe(Recipe recipe)
        {
            // Print the name of the recipe
            Console.WriteLine($"\nRecipe Name: {recipe.Name}");

            // Print the heading for the ingredients section
            Console.WriteLine("Ingredients:");

            // Iterate over each ingredient in the recipe's Ingredients list
            foreach (var ingredient in recipe.Ingredients)
            {
                // Print details of each ingredient, including quantity, unit, name, calories, and food group
                Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
            }

            // Print the heading for the steps section
            Console.WriteLine("\nSteps:");

            // Iterate over each step in the recipe's Steps list
            for (int i = 0; i < recipe.Steps.Count; i++)
            {
                // Print the step number and description of each step
                Console.WriteLine($"{i + 1}. {recipe.Steps[i].Description}");
            }
        }

        static void NotifyIfCaloriesExceed(Recipe recipe)
        {
            // Check if the total calories of the recipe exceed 300
            if (recipe.CalculateTotalCalories() > 300)
            {
                // Set the console text color to red to indicate a warning
                Console.ForegroundColor = ConsoleColor.Red;

                // Display a warning message indicating that the recipe exceeds 300 calories
                Console.WriteLine("Warning: This recipe exceeds 300 calories!");

                // Reset the console text color to its default value
                Console.ResetColor();
            }
        }
    }
    }
