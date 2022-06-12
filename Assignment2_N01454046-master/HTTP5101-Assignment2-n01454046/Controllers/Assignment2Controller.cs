using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Diagnostics;

namespace HTTP5101_Assignment2_n01454046.Controllers
{
    public class Assignment2Controller : ApiController
    {

        /// <summary>
        /// This method returns a string that has calculated to total number of calories of the meal selected
        /// </summary>
        /// <example>GET api/Assignment2/J1/Menu/4/4/4/4 </example>
        /// <param name="burger"> an INT value from 1-4 indicating burger selection </param>
        /// <param name="drink"> an INT value from 1-4 indicating drink selection </param>
        /// <param name="side"> an INT value from 1-4 indicating side selection </param>
        /// <param name="dessert"> an INT value from 1-4 indicating dessert selection </param>
        /// <returns> Your total calorie count is 0 </returns>
        [HttpGet]
        [Route("api/Assignment2/J1/Menu/{burger}/{drink}/{side}/{dessert}")]
        public string menu(int burger, int drink, int side, int dessert)
        {
            // Setting Variables to hold the calorie values of the food items
            int burgerCalories;
            int drinkCalories;
            int sideCalories;
            int dessertCalories;

            // Setting a variable to keep track of the total calories of all the food items combined
            int totalCalories = 0;

            // Setting a string value to be part of the final message that is returned
            string message = "Your total calorie count is ";

            // Setting a string variable to be the final message
            string finalMessage;


            // Checking to see what the input value of "burger" is
            if(burger == 1)
            {
                // Setting the burgerCalories variable to hold an int based on the users selection
                burgerCalories = 461;

                // Updating the totalCalories variable with the updated burgerCalories number
                totalCalories = totalCalories + burgerCalories;
         
            } 
            else if(burger == 2)
            {
                burgerCalories = 431;
                totalCalories = totalCalories + burgerCalories;
            }
            else if (burger == 3)
            {
                burgerCalories = 420;
                totalCalories = totalCalories + burgerCalories;
            }
            else
            {
                burgerCalories = 0;
                totalCalories = totalCalories + burgerCalories;
            }

            // Checking to see what the input value of "drink" is
            if (drink == 1)
            {
                // Setting the drinkCalories variable to hold an int based on the users selection
                drinkCalories = 130;

                // Updating the totalCalories variable with the updated drinkCalories number
                totalCalories = totalCalories + drinkCalories;
            }
            else if (drink == 2)
            {
                drinkCalories = 160;
                totalCalories = totalCalories + drinkCalories;
            }
            else if (drink == 3)
            {
                drinkCalories = 118;
                totalCalories = totalCalories + drinkCalories;
            }
            else
            {
                drinkCalories = 0;
                totalCalories = totalCalories + drinkCalories;
            }

            // Checking to see what the input value of "side" is
            if (side == 1)
            {
                // Setting the sideCalories variable to hold an int based on the users selection
                sideCalories = 100;

                // Updating the totalCalories variable with the updated sideCalories number
                totalCalories = totalCalories + sideCalories;
            }
            else if (side == 2)
            {
                sideCalories = 57;
                totalCalories = totalCalories + sideCalories;
            }
            else if (side == 3)
            {
                sideCalories = 70;
                totalCalories = totalCalories + sideCalories;
            }
            else
            {
                sideCalories = 0;
                totalCalories = totalCalories + sideCalories;
            }

            // Checking to see what the input value of "dessert" is
            if (dessert == 1)
            {
                // Setting the dessertCalories variable to hold an int based on the users selection
                dessertCalories = 167;

                // Updating the totalCalories variable with the updated dessertCalories number
                totalCalories = totalCalories + dessertCalories;
            }
            else if (dessert == 2)
            {
                dessertCalories = 266;
                totalCalories = totalCalories + dessertCalories;
            }
            else if (dessert == 3)
            {
                dessertCalories = 75;
                totalCalories = totalCalories + dessertCalories;
            }
            else
            {
                dessertCalories = 0;
                totalCalories = totalCalories + dessertCalories;
            }

            // Updating the finalMessage variable with the message initialized earlier + the int of totalCalories
            finalMessage = message + totalCalories;

            // Returning the final message
            return finalMessage;

        }


        /// <summary>
        /// This method returns a string that calculates how many ways 10 can be rolled based on the value of two die
        /// </summary>
        /// <example>GET api/Assignment2/J2/diceGame/6/8 </example>
        /// <param name="m"> an INT value representing the number of sides on die #1 </param>
        /// <param name="n"> an INT value representing the number of sides on die #2 </param>
        /// <returns> There are 5 total ways to get the sum 10. </returns>
        [HttpGet]
        [Route("api/Assignment2/J2/diceGame/{m}/{n}")]
        public string diceGame(int m, int n)
        {
            // Initializing a int variable to count the number of times 10 can be rolled
            int countOfSum = 0;

            // Initializing a string variable to be the final message
            string finalMessage;
            
            // Looping through all sides of the first dice
            for(int dice1 = 1; dice1 <= m; dice1++)
            {
                // Looping through each side of the second dice every 1 side of the first dice
                for(int dice2 = 1; dice2 <= n; dice2++)
                {
                    // adding the value of each dices side together
                    int sum = dice1 + dice2;     
                    
                    // if the sum of each dices side is 10 then add one to the count of the number of times 10 is rolled
                    if(sum == 10)
                    {
                        countOfSum++;
                    }
                }

            }

            // if 10 can be rolled once, update the final message variable with this string
            if(countOfSum == 1)
            {
                finalMessage = "There is " + countOfSum + " way to get the sum 10.";
            }
            // if 10 can be rolled 5 or more times, update the final message variable with this string
            else if (countOfSum >= 5)
            {
                finalMessage = "There are " + countOfSum + " total ways to get the sum 10.";
            }
            // all others options will update the final message with this string
            else
            {
                finalMessage = "There are " + countOfSum + " ways to get the sum 10.";
            }
            
            // Return the updated final message
            return finalMessage;
        }



        [HttpGet]
        [Route("api/Assignment2/J3/Punchy/{number1}/{letter1}/{value1}")]
        public string punchy(int number1, string letter1, char value1)
        {
             object[,] theArray = { 
                { 1, "a", 3 }, 
                { 1, "b", 4 }, 
                { 2, "b", 0 }, 
                { 2, "a", 0 }, 
                { 3, "a", "b" }, 
                { 2, "a", 0 }, 
                { 5, "a", "a" }, 
                { 2, "a", 0 }, 
                { 2, "b", 0 }, 
                { 7, 0, 0 } 
            };

            object v = theArray[2,1];
            Debug.WriteLine(v);

            // Problem J3 - Punchy - 2010
            // What I am attempting to do to solve the question
            // 1. Take in the desired input, To me a nested array seems to make the most sense as an input
            // 2. Loop through each array within the nested array. Each array will be formated like this [number, letter, value] following the format of the sample input.
            // 3. Each element of the array will then be inputed into the logic of the method/function
            // 4. The logic of the function will run based on the number of arrays there are updating the values of A & B each loop or outputting to the console.

            int x = 0;
            int y = 0;


           
             int function(int number, string letter, char value)
             {

                int A = 1;
                int B = 2;
                

                if (number == 1)
                {
                    if (letter == "A" | letter == "a")
                    {

                        string inBetween = Char.ToString(value);
                        A = int.Parse(inBetween);
                        x = A;
                        Debug.WriteLine(inBetween);
                        Debug.WriteLine(value);
                        Debug.WriteLine(A);
                        Debug.WriteLine(x);
                        
                        return A;
                    }
                    else
                    {
                        string inBetween = Char.ToString(value);
                        B = int.Parse(inBetween);
                        x = B;
                        return B;
                    }

                }
                else if (number == 2)
                {
                    if (letter == "A" | letter == "a")
                    {
                        Debug.WriteLine(A);
                        x = A;
                        return A;
                    } 
                    else
                    {

                        Debug.WriteLine(B);
                        y = B;
                        return B;
                    }
                }
                else
                {
                    string inBetween = Char.ToString(value);

                    if (number == 3)
                    {
                        // string inBetween = Char.ToString(value);
                        // A = int.Parse(inBetween);

                        if (letter == "A" | letter == "a" && inBetween == "b" | inBetween == "B")
                        {
                            A = A + B;
                            Debug.WriteLine(A);
                            x = A;
                            return A;
                        }
                        else if (letter == "B" | letter == "B" && inBetween == "a" | inBetween == "a")
                        {
                            B = A + B;
                            y = B;
                            Debug.WriteLine(B);
                            return B;
                        }
                        else if (letter == "A" | letter == "a" && inBetween == "a" | inBetween == "A")
                        {
                            A = A + A;
                            x = A;
                            Debug.WriteLine(A);
                            return A;
                        } 
                        else
                        {
                            B = B + B;
                            y = B;
                            Debug.WriteLine(B);
                            return B;
                        }
                    } 
                    else if (number == 4)
                    {
                        if (letter == "A" | letter == "a" && inBetween == "b" | inBetween == "B")
                        {
                            A = A * B;
                            Debug.WriteLine(A);
                            x = A;
                            return A;
                        }
                        else if (letter == "B" | letter == "B" && inBetween == "a" | inBetween == "a")
                        {
                            B = A * B;
                            y = B;
                            Debug.WriteLine(B);
                            return B;
                        }
                        else if (letter == "A" | letter == "a" && inBetween == "a" | inBetween == "A")
                        {
                            A = A * A;
                            x = A;
                            Debug.WriteLine(A);
                            return A;
                        }
                        else
                        {
                            B = B * B;
                            y = B;
                            Debug.WriteLine(B);
                            return B;
                        }
                    }
                    else if (number == 5)
                    {
                        if (letter == "A" | letter == "a" && inBetween == "b" | inBetween == "B")
                        {
                            A = A - B;
                            Debug.WriteLine(A);
                            x = A;
                            return A;
                        }
                        else if (letter == "B" | letter == "B" && inBetween == "a" | inBetween == "a")
                        {
                            B = A - B;
                            y = B;
                            Debug.WriteLine(B);
                            return B;
                        }
                        else if (letter == "A" | letter == "a" && inBetween == "a" | inBetween == "A")
                        {
                            A = A - A;
                            x = A;
                            Debug.WriteLine(A);
                            return A;
                        }
                        else
                        {
                            B = B - B;
                            y = B;
                            Debug.WriteLine(B);
                            return B;
                        }
                    }
                    else if (number == 6)
                    {
                        if (letter == "A" | letter == "a" && inBetween == "b" | inBetween == "B")
                        {
                            A = A / B;
                            Debug.WriteLine(A);
                            x = A;
                            return A;
                        }
                        else if (letter == "B" | letter == "B" && inBetween == "a" | inBetween == "a")
                        {
                            B = A / B;
                            y = B;
                            Debug.WriteLine(B);
                            return B;
                        }
                        else if (letter == "A" | letter == "a" && inBetween == "a" | inBetween == "A")
                        {
                            A = A / A;
                            x = A;
                            Debug.WriteLine(A);
                            return A;
                        }
                        else
                        {
                            B = B / B;
                            y = B;
                            Debug.WriteLine(B);
                            return B;
                        }
                    }
                    else
                    {
                        // Would like to return 7 to finish the loop in-case the loop doesn't stop as intended
                        return 7;
                    }
                }
                

                
             }

            // Ideally I would have a while/for each loop running and inputing each value from the nested array into the function parameters, and repeating until there is no more arrays to loop through
             function(number1, letter1, value1);

             return "This is the number: " + number1 + " this is the string: " + letter1 + " this is the char: " + value1 + " this is A: " + x + " This is B: " + y ;

        }
    }
}
    



