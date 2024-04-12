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

// Method to enter details for a new recipe
static void EnterRecipe()
{
    Console.WriteLine("\nEnter details for the recipe:");

    // Prompt user to enter recipe name
    Console.WriteLine("\nEnter name of the recipe:");
    recipe.Name = Console.ReadLine(); // Set the recipe name

    // Prompt user to enter number of ingredients
    Console.Write("Enter the number of ingredients: ");
    int numIngredients = int.Parse(Console.ReadLine());
    Ingredient[] ingredients = new Ingredient[numIngredients];

    // Loop to input details for each ingredient
    for (int i = 0; i < numIngredients; i++)
    {
        Console.WriteLine($"Enter details for ingredient {i + 1}:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Quantity: ");
        double quantity = double.Parse(Console.ReadLine());
        Console.Write("Unit: ");
        string unit = Console.ReadLine();

        ingredients[i] = new Ingredient { Name = name, Quantity = quantity, Unit = unit };
    }

    // Prompt user to enter number of steps
    Console.Write("Enter the number of steps: ");
    int numSteps = int.Parse(Console.ReadLine());
    Step[] steps = new Step[numSteps];

    // Loop to input details for each step
    for (int i = 0; i < numSteps; i++)
    {
        Console.WriteLine($"Enter details for step {i + 1}:");
        Console.Write("Description: ");
        string description = Console.ReadLine();

        steps[i] = new Step { Description = description };
    }

    // Set the ingredients and steps for the recipe
    recipe.Ingredients = ingredients;
    recipe.Steps = steps;

    // Confirm successful entry of recipe
    Console.WriteLine("Recipe entered successfully.");
}
