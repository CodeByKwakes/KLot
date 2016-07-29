using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLotSingleClass
{
    class Program
    {
        int[] userArray;
        int[] resultArray;
        List<int> winningArray;
        int numberInput;

        static void Main(string[] args)
        {
            Program kLot = new Program();
            do
            {
                kLot.PlayGame();
                kLot.InputLotteryNumbers(kLot.userArray);
                kLot.ShowNumbers(kLot.userArray, "\nThe numbers you entered were: \n");
                kLot.GenerateRandomNumbers(kLot.resultArray);
                kLot.ShowNumbers(kLot.resultArray, "\nTonights winning numbers are : \n");
                kLot.DisplayWinningResults(kLot.winningArray);
                kLot.WinningMessage(kLot.winningArray);
            } while (kLot.WouldYouLikeToRestart());
            kLot.Exit();
        }

        public void PlayGame()
        {
            userArray = new int[6];
            resultArray = new int[6];
            winningArray = new List<int>();
            Console.Clear();
            Console.WriteLine("Welcome to K-Lot \nPress Return to play");
            Console.ReadLine();
        }
        public void InputLotteryNumbers(int[] arr)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("\nPlease enter lottery number " + (i + 1) + " : ");

                numberInput = int.Parse(Console.ReadLine());

                if (IsValidationFailed())
                {
                    i--;
                }
                else
                {
                    arr[i] = numberInput;
                }
            }
            Console.WriteLine("\n\n");
        }

        public bool IsValidationFailed()
        {
            bool status = false;

            if (IsNotValidNumber(numberInput) || IsDuplicate(userArray, numberInput))
            {
                status = true;
            }
            return status;
        }

        //public bool IsWrongInput()
        //{
        //    bool status = false;
        //    try
        //    {
        //        numberInput = int.Parse(Console.ReadLine());
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine($"This is not vaild. Could you please enter a numeric value - {ex.Message}");
        //        status = true;
        //    }
        //    return status;
        //}

        public bool IsDuplicate(int[] arr, int input)
        {
            bool status = false;
            if (arr.Contains(input))
            {
                Console.WriteLine("You have already chosen number " + input);
                status = true;
            }
            return status;
        }

        public bool IsNotValidNumber(int input)
        {
            bool status = false;
            if (input < 1 || input > 49)
            {
                Console.Write("\nPlease pick a number between 1 and 49");
                status = true;
            }
            return status;
        }

        public void ShowNumbers(int[] arr, string message)
        {
            Console.Write(message);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0}\t", arr[i]);
            }
            Console.WriteLine();
        }

        public void GenerateRandomNumbers(int[] arr)
        {
            Random randomNumbers = new Random();
            int resultArrayNumber;

            for (int x = 0; x < arr.Length; x++)
            {
                resultArrayNumber = randomNumbers.Next(0, 50);
                if (arr.Contains(resultArrayNumber))
                {
                    x--;
                }
                else
                {
                    arr[x] = resultArrayNumber;
                }
            }
            Array.Sort(arr);
        }

        public void CalculateResults(int[] userArr, int[] resultArr, List<int> winningArr)
        {
            for (int i = 0; i < userArr.Length; i++)
            {
                for (int j = 0; j < resultArr.Length; j++)
                {
                    if (userArr[i] == resultArr[j])
                    {
                        winningArr.Add(userArr[i]);
                    }
                }
            }
        }

        public void DisplayWinningResults(List<int> arr)
        {
            CalculateResults(userArray, resultArray, winningArray);
            Console.WriteLine("You matched: " + arr.Count + " numbers:");

            foreach (int item in arr)
            {
                Console.Write(item + "\t");
            }
        }

        public void WinningMessage(List<int> arr)
        {
            switch (arr.Count)
            {
                case 0:
                case 1:
                case 2:
                    Console.WriteLine("\nYou Lose!!! ");
                    break;
                case 3:
                    Console.WriteLine("\nYou Win £10!!! ");
                    break;
                case 4:
                    Console.WriteLine("\nYou Win £1000!!! ");
                    break;
                case 5:
                    Console.WriteLine("\nYou Win £20,000!!! ");
                    break;
                case 6:
                    Console.WriteLine("\nYou Win £100,000!!! ");
                    break;
                default:
                    Console.WriteLine("\nUnknown value");
                    break;
            }
        }

        public bool WouldYouLikeToRestart()
        {
            bool playGame = false;
            Console.WriteLine("\nWould you like to play again. \nPress y for Yes \nOr any key to exit the game \n");
            ConsoleKeyInfo input = Console.ReadKey();

            if (input.KeyChar == 'y')
            {
                playGame = true;

            }
            return playGame;
        }

        public void Exit()
        {
            Console.Clear();
            Console.WriteLine("OK. Goodbye and have a great day \nPress Return to Exit");
            Console.ReadLine();
        }
    }
}
