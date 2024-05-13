using System;
using System.Collections.Generic;
using System.Linq;

class RecipeManager
{
    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        public void DisplayRecipe()
        {
            Console.WriteLine($"Recipe: {Name}\n");
            Console.WriteLine("Ingredients:");

            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} - {ingredient.Calories} calories, Food Group: {ingredient.FoodGroup}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
        }

        public int CalculateTotalCalories()
        {
            int totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }
    }

    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
    }

    static List<Recipe> recipes = new List<Recipe>();

    public static void Main()
    {
        while (true)
        {
            Recipe recipe = CreateRecipe();
            recipes.Add(recipe);
            DisplayRecipeList();

            Console.WriteLine("Do you want to add another recipe? (y/n): ");
            string addAnother = Console.ReadLine().ToLower();

            if (addAnother != "y" && addAnother != "yes")
            {
                break;
            }
        }

        Console.WriteLine("Task ended. Press any key to exit.");
        Console.ReadKey();
    }

    static Recipe CreateRecipe()
    {
        Recipe recipe = new Recipe();

        while (true)
        {
            Console.Write("Enter recipe name: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                recipe.Name = name;
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid recipe name.");
            }
        }

        while (true)
        {
            Console.Write("Enter the number of ingredients: ");
            string ingredientCountInput = Console.ReadLine();
            if (int.TryParse(ingredientCountInput, out int ingredientCount) && ingredientCount > 0)
            {
                for (int i = 0; i < ingredientCount; i++)
                {
                    Ingredient ingredient = new Ingredient();

                    Console.Write($"Enter name for ingredient {i + 1}: ");
                    ingredient.Name = Console.ReadLine();

                    double quantity;
                    Console.Write($"Enter quantity for {ingredient.Name}: ");
                    while (!double.TryParse(Console.ReadLine(), out quantity))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                    ingredient.Quantity = quantity;

                    Console.WriteLine("Enter unit of measurement for the ingredient (e.g., ea, doz, pk, lb, oz, g, kg, mL, L): ");
                    string unit;
                    while (true)
                    {
                        unit = Console.ReadLine().ToLower();
                        if (IsUnitValid(unit))
                        {
                            ingredient.Unit = unit;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid unit from the list.");
                        }
                    }

                    int calories;
                    Console.Write($"Enter calories for {ingredient.Name}: ");
                    while (!int.TryParse(Console.ReadLine(), out calories))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number for calories.");
                    }
                    ingredient.Calories = calories;

                    Console.WriteLine("Enter food group (fat, protein, veg, carbohydrates) please be mindful about your spelling - for the ingredient: ");


                    string foodGroup;
                    while (true)
                    {
                        foodGroup = Console.ReadLine().ToLower();
                        if (IsFoodGroupValid(foodGroup))
                        {
                            ingredient.FoodGroup = foodGroup;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid food group.");
                        }
                    }

                    recipe.Ingredients.Add(ingredient);
                }
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer greater than zero.");
            }
        }

        while (true)
        {
            Console.Write("Enter the number of steps: ");
            if (int.TryParse(Console.ReadLine(), out int stepCount) && stepCount > 0)
            {
                for (int i = 0; i < stepCount; i++)
                {
                    Console.Write($"Enter step {i + 1}: ");
                    recipe.Steps.Add(Console.ReadLine());
                }
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer greater than zero.");
            }
        }

        return recipe;
    }

    static void DisplayRecipeList()
    {
        Console.WriteLine("\nList of Recipes:");
        var sortedRecipes = recipes.OrderBy(r => r.Name);
        foreach (var recipe in sortedRecipes)
        {
            Console.WriteLine(recipe.Name);
        }

        Console.WriteLine("\nEnter the name of the recipe you want to display: ");
        string recipeName = Console.ReadLine();
        var selectedRecipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
        if (selectedRecipe != null)
        {
            selectedRecipe.DisplayRecipe();
            int totalCalories = selectedRecipe.CalculateTotalCalories();
            Console.WriteLine($"\nTotal Calories: {totalCalories}");

            if (totalCalories > 300)
            {
                Console.WriteLine("Warning: Total calories exceed 300!");
            }
        }
        else
        {
            Console.WriteLine("Recipe not found.");
        }
    }

    static bool IsUnitValid(string unit)
    {
        string[] validUnits = { "ea", "doz", "pk", "lb", "oz", "g", "kg", "ml", "l" };
        return validUnits.Contains(unit.ToLower());
    }

    static bool IsFoodGroupValid(string foodGroup)
    {
        string[] validFoodGroups = { "fat", "protein", "veg", "carbohydrates" };
        return validFoodGroups.Contains(foodGroup.ToLower());
    }
}