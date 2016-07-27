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
               
                if (check.IsDupliate(userArray, numberInput) || check.IsNotVaildNumber(numberInput))
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
            Console.Write("\nThe number you inputed was: {0}, {1}, {2}, {3}, {4}, {5} \n\n", userArray[0], userArray[1], userArray[2], userArray[3], userArray[4], userArray[5]);
            //Console.Write("\nThe number you inputed was: " + userInput);
        }

        public void GenerateRandomNumbers()
        {
            Random randomNumbers = new Random();
            int[] resultArray = new int[6];
            int resultArrayNumber;

            for (int x = 0; x < resultArray.Length; x++)
            {
                resultArrayNumber = randomNumbers.Next(0, 50);
                if (resultArray.Contains(resultArrayNumber))
                {
                    x--;
                }
                else
                {
                    resultArray[x] = resultArrayNumber;
                }
            }
            Array.Sort(resultArray);
            Console.WriteLine("Tonights winnig numbers are : {0}, {1}, {2}, {3}, {4}, {5} \n\n", resultArray[0], resultArray[1], resultArray[2], resultArray[3], resultArray[4], resultArray[5]);
        }
    }



    class ValidateUserNumbers
    {
        //public bool IsNotNumber(int input)
        //{
        //    bool status = false;
        //    try
        //    {
        //        input = int.Parse(Console.ReadLine());
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(input + " is not a vaild number. Could you please enter a numeric value - " + ex.Message);
        //        status = true;
        //    }
        //    return status;
        //}
        
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

        public bool IsNotVaildNumber(int input)
        {
            bool status = false;
            if (input < 1 || input > 49)
            {
                Console.Write("\nPlease picked a number between 1 and 49");
                status = true;
            }

            return status;
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
            kLot.GenerateRandomNumbers();
            Console.ReadLine();
        }
    }
}
