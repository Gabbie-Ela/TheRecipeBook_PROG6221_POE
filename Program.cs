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
            {
    // Declare and initialize a boolean variable to control program exit
    bool exit = false;

    // Start a loop for the menu until the user chooses to exit
    while (!exit)
    {
        // Display the main menu options
        Console.WriteLine("\nTHE RECIPE BOOK");
        Console.WriteLine("\nMenu:");
        Console.WriteLine("1. Enter a recipe");
        Console.WriteLine("2. Display the full recipe");
        Console.WriteLine("3. Scale the recipe");
        Console.WriteLine("4. Reset the recipe");
        Console.WriteLine("5. Delete recipe");
        Console.WriteLine("6. Exit");

        // Prompt user for choice
        Console.Write("\nEnter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        // Switch statement to handle user's choice
        switch (choice)
        {
            case 1:
                EnterRecipe(); // Call method to enter a recipe
                break;
            case 2:
                // Check if scaled recipe data is present, if yes, display it; otherwise, display the original recipe
                if (scaledRecipe != null)
                    DisplayRecipe(scaledRecipe);
                else
                    DisplayRecipe(recipe);
                break;
            case 3:
                ScaleRecipe(); // Call method to scale the recipe
                break;
            case 4:
                // Display the data saved in the recipe class
                DisplayRecipe(recipe);
                break;
            case 5:
                DeleteRecipeData(); // Call method to delete recipe data
                break;
            case 6:
                exit = true; // Set exit flag to true to exit the loop
                break;
            default:
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                break;
        }
    }
}

