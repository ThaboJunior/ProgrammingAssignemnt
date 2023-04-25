using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Part1
{
    internal class Program
    {
        class Recipe //This is my class recipe
        {
            private string[] ingredients;
            private double[] quantities;
            private string[] unitOfMeasuremnt;
            private string[] steps;


            public Recipe()
            {
                 ingredients = new string[0];
                 quantities = new double[0];
                 unitOfMeasuremnt = new string[0];
                 steps = new string[0];
            }

            public void CaptureDetails() //this method captures all the details of the recipe
            {
                
                Console.WriteLine("Enter the number of ingredients");
                int numberOfIngredients = int.Parse(Console.ReadLine());//prompts the user for the number of ingredients they want to enter

                 ingredients = new string[numberOfIngredients]; //array declared and sized according to user input
                 quantities = new double[numberOfIngredients]; //array declared and sized according to user input
                 unitOfMeasuremnt = new string[numberOfIngredients]; //array declared and sized according to user input

                if (numberOfIngredients > 15) //this limits the number of ingredients that can be entered into the recipe as any number is accepted
                {
                    Console.WriteLine("Unfortunately this program does not allow more than 15 ingredients");
                }
                else if (numberOfIngredients <= 15)
                {
                    for (int i = 0; i < numberOfIngredients; i++)
                    {
                        Console.WriteLine("Ingredient {0} name: ", i + 1);
                        ingredients[i] = Console.ReadLine(); //this line captures the ingredient name

                        Console.WriteLine("Quantity:");
                        quantities[i] = double.Parse(Console.ReadLine());//this line captures the quantity

                        Console.WriteLine("Unit of Measurement(What are you using to measure? e.g teaspoon/tablespoon/cup)");
                        unitOfMeasuremnt[i] = Console.ReadLine();//this line captures the unit of measurement

                    }
                    Console.WriteLine("");
                    Console.WriteLine("Enter the number of Steps");
                    int numOfSteps = int.Parse(Console.ReadLine()); //prompts the user for number of steps they want to enter for thier recipe

                    steps = new string[numOfSteps]; //array sized according to user choice

                    for (int i = 0; i < numOfSteps; i++)
                    {
                        Console.WriteLine("Step {0}: ", i + 1); //user will be prompted to enter steps until array size
                        steps[i] = Console.ReadLine();
                    }

                }

              
                Console.WriteLine("");


            }

            public void DisplayRecipe() //This method will display all the captured data from ingredients to steps
            {

                Console.WriteLine("   RECIPE CAPTURED");
                Console.WriteLine("----------------------");

                for (int i = 0; i < ingredients.Length; i++)
                {
                    Console.WriteLine($"{quantities[i]} {unitOfMeasuremnt[i]} of {ingredients[i]}");
                    // quantity, unit of measure and name of ingredient will be displayed
                }

                Console.WriteLine("");
                Console.WriteLine("STEPS:");

                for (int i = 0; i < steps.Length; i ++)
                {
                   Console.WriteLine(" {0}. " + $"{steps[i]}" , i + 1);
                    //this line will print all the step captured in a numbered list
                }

                Console.WriteLine("");
            }

            public void ScaleRecipe(double scale) //This method scales the quantity 
            {
                
                for (int i = 0; i < quantities.Length;i++)
                {
                    quantities[i] *= scale; //multiplies the quantity the user entered by the scale chosen

                    if (quantities[i] == 16 && unitOfMeasuremnt[i] == "tablespoon")
                    {
                        quantities[i] = 1;
                        unitOfMeasuremnt[i] = "Cup";
                        //if the scaled recipe is equal to 16 tablespoons it will be changed to 1 cup

                    } else if(quantities[i] == 3 && unitOfMeasuremnt[i] == "teaspoon")
                    {
                        quantities[i] = 1;
                        unitOfMeasuremnt[i] = "Tablespoon";
                        //if the scaled recipe is equal to e teaspoons it will be changed to 1 Tablespoon

                    }
                    else
                    {
                        break;
                    }

                }
            }

            public void ResetQuantites() //this method resets the quantities back to original
            {
                for (int i = 0; i < quantities.Length; i++)
                {
                    quantities[i] /=2;

                }
            }

            public void ClearRecipe() //This method clears all the captured data in arrays
            {
                 ingredients = new string[0];
                 quantities = new double[0];
                 unitOfMeasuremnt = new string[0];
                 steps = new string[0];

                Console.WriteLine("RECIPE SUCCESSFULLY CLEARED!!");
                
                
            }

            public void Menu() //this the menu users will choose what to do from,consists of 6 options.
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("1 - Enter Ingredients");
                Console.WriteLine("2 - Display Recipe");
                Console.WriteLine("3 - Scale Recipe");
                Console.WriteLine("4 - Reset Quantities");
                Console.WriteLine("5 - Clear Recipe");
                Console.WriteLine("6 - Exit Program");
                Console.WriteLine("--------------------------");
                Console.WriteLine("----Enter choice----");
                Console.WriteLine("");

            }


            }
        


        static void Main(string[] args)
        {
            Recipe recipe = new Recipe(); //delcaration of an object

            bool running = true;

            Console.WriteLine("Welcome the Recipe Scaler Application");
            Console.WriteLine("");

            while(running) //program will keep running as long as running is true
            {
                recipe.Menu(); //Calls Main menu which users will choose from will be called
                int choice = int.Parse(Console.ReadLine()); //prompts the user to enter choice from menu

                switch(choice)
                {
                    case 1:
                         recipe.CaptureDetails(); // if user choice is 1, they will be prompted to enter ingredients(recipe)
                    break;

                    case 2: 
                        recipe.DisplayRecipe();// if user choice is 2, ingredients(recipe) captured will be displayed
                    break;

                    case 3:
                        Console.WriteLine("Choose one of the options - 0.5(half), 2(double), 3(triple)");
                        double scale = double.Parse(Console.ReadLine());
                        
                       recipe.ScaleRecipe(scale); //method that scales the recipe will be called
                    break;

                    case 4:
                         recipe.ResetQuantites();//this method will reset the quantities back to original value
                    break;

                    case 5:
                        Console.WriteLine("Are you sure you want to Clear the Recipe?" + "\n" + 
                                          "Enter yes to confirm or click Enter to return to Menu");

                        string clear = Console.ReadLine(); //if user enters yes the recipe will be cleared and prompted to enter a new one
                        Console.WriteLine("");

                        if (clear == "yes")
                        {
                            recipe.ClearRecipe();
                             Console.WriteLine("-------------------------------");
                             Console.WriteLine("Enter details for NEW Recipe");
                             Console.WriteLine("-------------------------------");
                             Console.WriteLine("");

                             recipe.CaptureDetails(); // this calls the method that prompts the user to enter ingredients(recipe)
                             
                        }

                        break;

                    case 6: //if user chooses 6 as an option the program will end 
                        Console.WriteLine("Exiting program");
                        running = false;
                        break;

                    default: // if users enter an option that is not one of the 6, they will be prompted to try again
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.WriteLine("");
                        break;

                        Console.ReadKey();
                }



            }

        }
    }
}

