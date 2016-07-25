using System;
using System.Collections.Generic;
using System.Linq;

namespace KLotVersion2
{
    class Program
    {
        static void Main(string[] args)
        {            
            bool playGame = true;

            while (playGame)
            {
                List<int> userArray = new List<int>();
                Random randomNumbers = new Random();
                int[] resultArray = new int[6];
                int resultArrayNumber;

                for (int x = 0; x < resultArray.Length; x++)
                {
                    resultArrayNumber = randomNumbers.Next(0, 50);
                    //If the number not contains, add number to array;
                    if (!resultArray.Contains(resultArrayNumber))
                    {
                        resultArray[x] = resultArrayNumber;
                    }
                    //If it contains, restart random process
                    else
                    {  
                        x--;
                    }
                }
                Array.Sort(resultArray);

                List<int> winningArray = new List<int>();

                Console.WriteLine("Welcome to K-Lot \nPress Return to play");
                Console.ReadLine();
                while (userArray.Count < 6)
                {
                    switch (userArray.Count)
                    {
                        case 0:
                            Console.WriteLine($"Please enter your 1st lottery number: ");
                            break;
                        case 1:
                            Console.WriteLine($"Please enter your 2nd lottery number: ");
                            break;
                        case 2:
                            Console.WriteLine($"Please enter your 3rd lottery number: ");
                            break;
                        case 3:
                            Console.WriteLine($"Please enter your 4th lottery number: ");
                            break;
                        case 4:
                            Console.WriteLine($"Please enter your 5th lottery number: ");
                            break;
                        case 5:
                            Console.WriteLine($"Please enter your 6th lottery number: ");
                            break;

                        default: break;
                    }
                    try
                    {
                        int userInput = int.Parse(Console.ReadLine());
                        bool userInputExists = userArray.Contains(userInput);

                        if (userInputExists)
                        {
                            Console.WriteLine($"You have already chosen number {userInput}");
                        }
                        else if (userInput < 1 || userInput > 49)
                        {
                            Console.WriteLine("Please choose a number between 1 and 49");
                        }
                        else
                        {
                            Console.WriteLine("You entered: " + userInput);
                            userArray.Add(userInput);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"This is not vaild. Could you please enter a numeric value - {ex.Message}");
                    }
                }

                Console.WriteLine("You have " + userArray.Count + " lottery numbers chosen");
                userArray.Sort();
                string displayUserArray = string.Join(",", userArray.ToArray());
                Console.WriteLine(displayUserArray);

                //  Display resultArray
                string displayResultArray = string.Join(",", resultArray.ToArray());
                Console.WriteLine($"Here are tonights winning lottery numbers - {displayResultArray}");

                for (int userCount = 0; userCount < userArray.Count; userCount++)
                {
                    for (int resultCount = 0; resultCount < resultArray.Length; resultCount++)
                    {
                        if (userArray[userCount] == resultArray[resultCount])
                        {
                            winningArray.Add(userArray[userCount]);
                        }
                    }
                }

                string displayWinningArray = string.Join(",", winningArray.ToArray());

                switch (winningArray.Count)
                {
                    case 0:
                        Console.WriteLine($"You Lose!!! You matched {winningArray.Count}. Better luck next time");
                        break;
                    case 1:
                        Console.WriteLine($"You Lose!!! You only matched {winningArray.Count} number. The number was {displayWinningArray} ");
                        break;
                    case 2:
                        Console.WriteLine($"You Lose!!! You matched {winningArray.Count} numbers. The numbers were {displayWinningArray} ");
                        break;
                    case 3:
                        Console.WriteLine($"You Win £10!!! - You matched {winningArray.Count} numbers. The numbers were {displayWinningArray} ");
                        break;
                    case 4:
                        Console.WriteLine($"You Win £1000!!! - You matched {winningArray.Count} numbers. The numbers were {displayWinningArray} ");
                        break;
                    case 5:
                        Console.WriteLine($"You Win £20,000!!! - You matched {winningArray.Count} numbers. The numbers were {displayWinningArray} ");
                        break;
                    case 6:
                        Console.WriteLine($"You Win £100,000 - You matched {winningArray.Count} numbers. The numbers were {displayWinningArray} ");
                        break;
                    default:
                        Console.WriteLine("Unknown value");
                        break;
                }
                Console.WriteLine();

                
                Console.WriteLine("Would you like to play again. \nPress y for Yes \nOr any key to exit the game \n");

                
                ConsoleKeyInfo info = Console.ReadKey();

                if (info.KeyChar == 'y')
                {
                    Console.Clear();
                }
                //else if (info.KeyChar != 'n')
                //{
                //    Console.WriteLine();
                //    Console.WriteLine("I did not understand you answer. \nPress y if you would like to play again \nOr \nPress n if you would like to exist the game");
                //    Console.ReadKey();
                //}
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("OK. Goodbye and have a great day \nPress Return to Exit");
                    playGame = false;
                    Console.ReadLine();
                }
            }
        }
    }
}
