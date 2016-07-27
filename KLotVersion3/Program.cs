using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLotVersion3
{
    //int userInput;

    class EnterUserNumbers
    {
        int[] userArray = new int[6];

        public void InputLotteryNumbers()
        {
            ValidateUserNumbers check = new ValidateUserNumbers();
            for (int i = 0; i < 6; i++)
            {
                Console.Write("\nPlease enter lottery number " + (i + 1) + " : ");
                int numberInput = int.Parse(Console.ReadLine());


              
                if (check.IsDupliate(userArray, numberInput) || !check.IsNumberVaild(numberInput))
                {
                    i--;
                }                    
                else
                {
                    userArray[i] = numberInput;
                }               
            }

            //userInput = int.Parse(Console.ReadLine());
        }

        public void ShowUserNumbers()
        {
            Console.Write("\nThe number you inputed was: {0}, {1}, {2}, {3}, {4}, {5}", userArray[0], userArray[1], userArray[2], userArray[3], userArray[4], userArray[5]);
            //Console.Write("\nThe number you inputed was: " + userInput);
        }
    }

    class ValidateUserNumbers
    {
        public bool IsDupliate(int[] arr, int input)
        {
            bool status = false;
            if (arr.Contains(input))
            {
                Console.WriteLine("You have already chosen number " + input);
                status = true;
            }

            return status;
        }

        public bool IsNumberVaild(int input)
        {
             if (input < 1 || input > 49)
            {
                Console.Write("\nPlease picked a number between 1 and 49");
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EnterUserNumbers kLot = new EnterUserNumbers();
            kLot.InputLotteryNumbers();
            Console.WriteLine("\n\n");
            kLot.ShowUserNumbers();
            Console.ReadLine();
        }
    }
}
