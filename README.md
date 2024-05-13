# Part2
RecipeManager Class:

This class contains the main logic for managing recipes.
It has nested classes: Recipe and Ingredient for representing recipes and their ingredients, respectively.
It also includes a static list of recipes (recipes), where all created recipes are stored.
Recipe Class:

Represents a recipe with properties like Name, Ingredients (list of Ingredient objects), and Steps (list of strings).
Provides methods to display a recipe (DisplayRecipe) and calculate the total calories of the recipe (CalculateTotalCalories).
Ingredient Class:

Represents an ingredient with properties like Name, Quantity, Unit, Calories, and FoodGroup.
Main Method:

The entry point of the application.
It starts by prompting the user to create recipes.
It repeatedly calls CreateRecipe to allow the user to input recipe details and add them to the recipes list.
After adding a recipe, it displays the list of recipes using DisplayRecipeList.
CreateRecipe Method:

Prompts the user to input details for a new recipe.
Asks for the recipe name, number of ingredients, details for each ingredient (name, quantity, unit, calories, food group), and number of steps.
Validates user input and adds the created recipe to the recipes list.
DisplayRecipeList Method:

Displays the list of available recipes.
Prompts the user to enter the name of the recipe they want to display.
Displays the selected recipe details (ingredients, steps) using the DisplayRecipe method of the Recipe class.
Calculates and displays the total calories of the recipe, along with a warning if the calories exceed 300.
Utility Methods (IsUnitValid, IsFoodGroupValid):

These methods validate if the units and food groups entered by the user are valid.
