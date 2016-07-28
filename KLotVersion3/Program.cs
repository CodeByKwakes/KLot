using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLotVersion3
{
    class Program
    {
        static void Main(string[] args)
        {
            EnterUserNumbers kLot = new EnterUserNumbers();
            kLot.InputLotteryNumbers();
            Console.WriteLine("\n\n");
            kLot.ShowUserNumbers();
            kLot.GenerateRandomNumbers();
            kLot.DisplayWinningResults();
            kLot.WinningMessage();
            Console.ReadLine();
        }
    }

    class EnterUserNumbers
    {
        int[] userArray = new int[6];
        int[] resultArray = new int[6];
        List<int> winningArray = new List<int>();

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
        }

        public void ShowUserNumbers()
        {
            Console.Write("\nThe numbers you inputed was: \n");
            for (int i = 0; i < 6; i++)
            {
                Console.Write("{0}\t", userArray[i]);
            }
            Console.WriteLine();
        }

        public void GenerateRandomNumbers()
        {
            Random randomNumbers = new Random();
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
            Console.Write("Tonights winning numbers are : \n");
            for (int i = 0; i < 6; i++)
            {
                Console.Write("{0}\t", resultArray[i]);
            }
            Console.WriteLine();
        }

        public void DisplayWinningResults()
        {
            MatchBothArrays result = new MatchBothArrays();
            result.CalculateResults(userArray, resultArray, winningArray);
            Console.WriteLine("You matched: " + winningArray.Count + " numbers:");


            foreach (int item in winningArray)
            {
                Console.Write(item + "\t");
            }

        }

        public void WinningMessage()
        {
            switch (winningArray.Count)
            {
                case 0:
                case 1:
                case 2:
                    Console.WriteLine("You Lose!!! ");
                    break;
                case 3:
                    Console.WriteLine("You Win £10!!! ");
                    break;
                case 4:
                    Console.WriteLine("You Win £1000!!! ");
                    break;
                case 5:
                    Console.WriteLine("You Win £20,000!!! ");
                    break;
                case 6:
                    Console.WriteLine("You Win £100,000!!! ");
                    break;
                default:
                    Console.WriteLine("Unknown value");
                    break;
            }
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

    class MatchBothArrays
    {
        public void CalculateResults(int[] user, int[] random, List<int> win)
        {
            for (int i = 0; i < user.Length; i++)
            {
                for (int j = 0; j < random.Length; j++)
                {
                    if (user[i] == random[j])
                    {
                        //win[i] = user[i];
                        win.Add(user[i]);
                    }
                }
            }
        }
    }

}
