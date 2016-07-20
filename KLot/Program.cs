using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLot
{
    class Program
    {
        static void Main(string[] args)
        {
            //  START
            
            //  INITIALIZE an empty ARRAY to hold USER’s lottery numbers(userArray)
            int[] userArray = new int[6];

            //  INITIALIZE an ARRAY with 6 Numbers to hold USER’s lottery numbers(resultArray)

            //  INITIALIZE an empty ARRAY to store the the matching Numbers(winningArray)

            do
            {
                //  Prompt USER to enter Number
                Console.WriteLine("Please enter a number: ");

                //  Get Number
                int userInput = Convert.ToInt16(Console.ReadLine());
                //  IF Number IS NOT EQUAL TO( != ) an INTEGER, THEN,
                //  Display message "Please pick a numeric value"
                //  Prompt USER to enter Number
                //  ELSE IF Number IS LESS THAN( < ) 1 OR( | | ) IS GREATER THAN( > ) 49, THEN,
                if (userInput < 1 || userInput > 49)
                {
                    //  Display message "Please choose a number between 1 and 49"
                    Console.WriteLine("Please choose a number between 1 and 49");
                    //  Prompt USER to enter Number
                }


                //  ELSE place Number in userArray
                else
                {
                    Console.WriteLine("You entered: " + userInput);
                    userArray.SetValue(userInput, 0);
                    Console.WriteLine(string.Join(",", userArray));
                }
                //  ENDIF
            }
            //  WHILE total of userArray IS NOT EQUAL TO(!=) 6 numbers,
            while (userArray.Length <= 6);
            {
                Console.ReadLine();
            }
            //  ENDWHILE

            //  Display resultArray

            //  INITIALIZE COUNTER1 to FIRST INDEX (0)
            //  REPEAT

                //  INITIALIZE  COUNTER2 to FIRST INDEX(0)
                //  REPEAT

                    //  IF a Number in userArray IS EQUAL TO(==) a Number in resultArray, THEN,

                        //  PUSH that Number from userArray into winningArray

                    //  ENDIF

                //  UNTIL COUNTER2 is GREATER THAN resultArray total
            //  UNTIL COUNTER1 is GREATER THAN userArray total

            //  CASE total Numbers in winningArray is,
                //  0 : Display message “You Lose”,
                //  1 : Display message “You Lose”,
                //  2 : Display message “You Lose”,
                //  3 : Display message “You Win £10”,
                //  4 : Display message “You Win £1000”,
                //  5 : Display message “You Win £20,000”,
                //  6 : Display message “You Win £100,000”,
            //  ENDCASE

            //  STOP
            Console.ReadKey();
        }
    }
}
