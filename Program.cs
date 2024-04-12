// Define the namespace for the program
namespace RecipeBook
{
    // Define the main program class
    class Program
    {
        // Declare a static variable to hold the original recipe
        static Recipe recipe = new Recipe();
        // Declare a static variable to hold the scaled recipe
        static ScaledRecipe scaledRecipe; // Variable to hold scaled recipe

        // Main method, entry point of the program
        static void Main(string[] args)
