using NUnit.Framework;
using RecipeBookPOE;
namespace RecipeBookPOE.UnitTests
{
    // Class to contain unit tests for the Ingredient class
    public class IngredientTests
    {
        // Test method to verify properties of an Ingredient object
        [Test]
        public void TestIngredientProperties()
        {
            // Arrange
            // Create a new Ingredient object with specific property values
            var ingredient = new Ingredient
            {
                Name = "Flour",
                Quantity = 2.5,
                Unit = "cups",
                Calories = 455,
                FoodGroup = "Grains"
            };

            // Act
            // There is no action needed for this test method.

            // Assert
            // Verify that each property of the ingredient matches the expected value
            Assert.AreEqual("Flour", ingredient.Name);        // Check Name property
            Assert.AreEqual(2.5, ingredient.Quantity);         // Check Quantity property
            Assert.AreEqual("cups", ingredient.Unit);          // Check Unit property
            Assert.AreEqual(455, ingredient.Calories);         // Check Calories property
            Assert.AreEqual("Grains", ingredient.FoodGroup);   // Check FoodGroup property
        }
    }
}