using System;
using System.Collections.Generic;

namespace KLot
{
    class FirstVersion
    {
        static void Main(string[] args)
        {
            //  START
            //  INITIALIZE an empty ARRAY to hold USER’s lottery numbers(userArray)
            List<int> userArray = new List<int>();
            //  INITIALIZE an ARRAY with 6 Numbers to hold USER’s lottery numbers(resultArray)
            List<int> resultArray = new List<int>() { 14, 45, 34, 3, 26, 40 };
            //  INITIALIZE an empty ARRAY to store the the matching Numbers(winningArray)
            List<int> winningArray = new List<int>();
            //  WHILE total of userArray IS NOT EQUAL TO(!=) 6 numbers,
            while (userArray.Count < 6)
            {
                //  Prompt USER to enter Number
                Console.WriteLine($"Please enter your lottery number: ");
                try
                {
                    int userInput = int.Parse(Console.ReadLine());
                    //  IF Number IS NOT EQUAL TO( != ) an INTEGER, THEN,
                    bool userInputExists = userArray.Contains(userInput);
                    if (userInputExists)
                    {
                        Console.WriteLine("You have already picked this number");
                    }                 
                    //  ELSE IF Number IS LESS THAN( < ) 1 OR( | | ) IS GREATER THAN( > ) 49, THEN,
                    else if (userInput < 1 || userInput > 49)
                    {
                        //  Display message "Please choose a number between 1 and 49"
                        Console.WriteLine("Please choose a number between 1 and 49");
                        //  Prompt USER to enter Number
                    }
                    //  ELSE place Number in userArray
                    else
                    {
                        Console.WriteLine("You entered: " + userInput);
                        userArray.Add(userInput);
                        //Console.WriteLine(userArray.Count);
                    }
                    //  ENDIF
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"This is not vaild. Could you please enter a numeric value - {ex.Message}");
                }
                //  Get Number
            }
            // ENDWHILE

            Console.WriteLine("You have " + userArray.Count + " lottery numbers chosen");
            userArray.Sort();
            string displayUserArray = string.Join(",", userArray.ToArray());
            Console.WriteLine(displayUserArray);

            //  Display resultArray
            string displayResultArray = string.Join(",", resultArray.ToArray());
            Console.WriteLine($"Here are tonights winning lottery numbers - {displayResultArray}");

            //  INITIALIZE COUNTER1 to FIRST INDEX (0)
            //  REPEAT
            for (int userCount = 0; userCount < userArray.Count; userCount++)
            {
                //  INITIALIZE  COUNTER2 to FIRST INDEX(0)
                //  REPEAT
                for (int resultCount = 0; resultCount < resultArray.Count; resultCount++)
                {
                    //  IF a Number in userArray IS EQUAL TO(==) a Number in resultArray, THEN,
                    if (userArray[userCount] == resultArray[resultCount])
                    {
                        //  PUSH that Number from userArray into winningArray
                        winningArray.Add(userArray[userCount]);
                    }
                    //  ENDIF
                }
                //  UNTIL COUNTER2 is GREATER THAN resultArray total
            }
            //  UNTIL COUNTER1 is GREATER THAN userArray total
            string displayWinningArray = string.Join(",", winningArray.ToArray());

            //CASE total Numbers in winningArray is,
            //switch (displayWinningArray.Length)
            switch (winningArray.Count)
            {
                //  0 : Display message “You Lose”,               
                case 0:
                    Console.WriteLine($"You Lose!!! You matched {winningArray.Count}. Better luck next time");
                    break;
                //  1 : Display message “You Lose”,
                case 1:
                    Console.WriteLine($"You Lose!!! You only matched {winningArray.Count} number. The number was {displayWinningArray} ");
                    break;
                //  2 : Display message “You Lose”,
                case 2:
                    Console.WriteLine($"You Lose!!! You matched {winningArray.Count} numbers. The numbers were {displayWinningArray} ");
                    break;
                //  3 : Display message “You Win £10”,
                case 3:
                    Console.WriteLine($"You Win £10!!! - You matched {winningArray.Count} numbers. The numbers were {displayWinningArray} ");
                    break;
                //  4 : Display message “You Win £1000”,
                case 4:
                    Console.WriteLine($"You Win £1000!!! - You matched {winningArray.Count} numbers. The numbers were {displayWinningArray} ");
                    break;
                //  5 : Display message “You Win £20,000”,
                case 5:
                    Console.WriteLine($"You Win £20,000!!! - You matched {winningArray.Count} numbers. The numbers were {displayWinningArray} ");
                    break;
                //  6 : Display message “You Win £100,000”,
                case 6:
                    Console.WriteLine($"You Win £100,000 - You matched {winningArray.Count} numbers. The numbers were {displayWinningArray} ");
                    break;
                default:
                    Console.WriteLine("Unknown value");
                    break;
            }
            //  ENDCASE
            //  STOP
            Console.ReadLine();
        }
    }
}
