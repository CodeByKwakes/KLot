using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLotConfig
{
    class Program
    {
        int setArraySize;
        int setMinValue;
        int setMaxValue;
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
                kLot.GameSetUp();
                kLot.InitialiseGame();
                kLot.InputLotteryNumbers(kLot.userArray);
                kLot.ShowNumbers(kLot.userArray, "\nThe numbers you entered were: \n");
                //kLot.GenerateRandomNumbers(kLot.resultArray);
                //kLot.ShowNumbers(kLot.resultArray, "\nTonights winning numbers are : \n");
                //kLot.DisplayWinningResults(kLot.winningArray);
                //kLot.WinningMessage(kLot.winningArray);
            } while (kLot.WouldYouLikeToRestart());
            kLot.Exit();
        }

        public void PlayGame()
        {

            Console.Clear();
            Console.WriteLine("Welcome to K-Lot \nPress Return to play");
            Console.ReadLine();
        }

        public void GameSetUp()
        {
           
           
            
            Console.WriteLine("\nPlease enter the amount of lottey numbers you want to choose");
            setArraySize = int.Parse(Console.ReadLine());
            Console.WriteLine("\nPlease enter the min range");
            setMinValue = int.Parse(Console.ReadLine());
            Console.WriteLine("\nPlease enter the max range");
            setMaxValue = int.Parse(Console.ReadLine());
           
        }

        public void InitialiseGame()
        {
            userArray = new int[setArraySize];
            resultArray = new int[setArraySize];
            winningArray = new List<int>();

        }

        public void InputLotteryNumbers(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("\nPlease enter lottery number " + (i + 1) + " : ");
                try
                {
                    numberInput = int.Parse(Console.ReadLine());
                    arr[i] = IsValidationFailed() ? i-- : numberInput;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
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

        public bool IsNotValidNumber(int input)
        {
            bool status = false;
            if (input < 1 || input > 49)
            {
                Console.Write("\nPlease pick a number between 1 and 49\n");
                status = true;
            }
            return status;
        }

        public bool IsDuplicate(int[] arr, int input)
        {
            bool status = false;
            if (arr.Contains(input))
            {
                Console.WriteLine("\nYou have already chosen number " + input);
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

                arr[x] = arr.Contains(resultArrayNumber) ? x-- : resultArrayNumber;
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
            Console.WriteLine("\nYou matched: " + arr.Count + " numbers:");

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
