using NUnit.Framework;
using RecipeBookPOE;
using System.Collections.Generic;

namespace RecipeBookPOE.UnitTests
{
    public class RecipeTests
    {
        [Test]
        public void TestCalculateTotalCalories()
        {
            // Arrange
            var recipe = new Recipe
            {
                Name = "Test Recipe",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Flour", Quantity = 2.5, Unit = "cups", Calories = 455, FoodGroup = "Grains" },
                    new Ingredient { Name = "Sugar", Quantity = 1.5, Unit = "cups", Calories = 720, FoodGroup = "Sweets" },
                    new Ingredient { Name = "Eggs", Quantity = 4, Unit = "", Calories = 312, FoodGroup = "Protein" }
                }
            };

            // Act
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(4043, totalCalories);
        }

        [Test]
        public void TestResetToOriginalInput()
        {
            // Arrange
            var recipe = new Recipe
            {
                Name = "Test Recipe",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Flour", Quantity = 2.5, Unit = "cups", Calories = 455, FoodGroup = "Grains" },
                    new Ingredient { Name = "Sugar", Quantity = 1.5, Unit = "cups", Calories = 720, FoodGroup = "Sweets" },
                    new Ingredient { Name = "Eggs", Quantity = 4, Unit = "", Calories = 312, FoodGroup = "Protein" }
                },
                OriginalIngredients = new List<Ingredient> // Setting original ingredients
                {
                    new Ingredient { Name = "Flour", Quantity = 2.5, Unit = "cups", Calories = 455, FoodGroup = "Grains" },
                    new Ingredient { Name = "Sugar", Quantity = 1.5, Unit = "cups", Calories = 720, FoodGroup = "Sweets" },
                    new Ingredient { Name = "Eggs", Quantity = 4, Unit = "", Calories = 312, FoodGroup = "Protein" }
                }
            };

            // Act
            recipe.Ingredients[0].Quantity = 3; // Modify ingredient quantity
            recipe.ResetToOriginalInput();

            // Assert
            Assert.AreEqual(2.5, recipe.Ingredients[0].Quantity); // Quantity should be reset to original value
        }

        
    }
}