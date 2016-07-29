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
            Console.Clear();
            Console.WriteLine("Welcome to K-Lot \nPress Return to play");
            Console.ReadLine();
        }
        
        // TODO a funtion for inputing intgers
        //public int ConsoleInput(int input)
        //{
        //    input = int.Parse(Console.ReadLine());
        //    return input;
        //}

        public void GameSetUp()
        {          
            Console.WriteLine("\nPlease enter the amount of lottery numbers you want to choose");
            setArraySize = int.Parse(Console.ReadLine());
            Console.WriteLine("\nPlease enter the min number range");
            setMinValue = int.Parse(Console.ReadLine());
            Console.WriteLine("\nPlease enter the max number range");
            setMaxValue = int.Parse(Console.ReadLine());
            InitialiseGame();
            Console.WriteLine("\nYou have set the following: \nAmount of Lottery Number: " + setArraySize + "\nMin number range: " + setMinValue + "\nMax number range: " + setMaxValue);
            Console.WriteLine("\nPress Return to play");
            Console.ReadLine();
            Console.Clear();
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
            Array.Sort(arr);
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
            if (input < setMinValue || input > setMaxValue)
            {
                Console.Write("\nPlease pick a number between " + setMinValue + " and " + setMaxValue + "\n");
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
                resultArrayNumber = randomNumbers.Next(setMinValue, setMaxValue);
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
            Console.WriteLine("\nYou matched: " + arr.Count + " (" + GetPercentage((double)arr.Count / userArray.Length) + ") numbers:");

            foreach (int item in arr)
            {
                Console.Write(item + "\t");
            }
        }

        public string GetPercentage(double ratio)
        {
            return ratio.ToString("0%");
        }

        public double Percentage(int value, int total)
        {
            double percent = (double)value / total * 100;
            return Math.Ceiling(percent);
        }

        public void WinningMessage(List<int> arr)
        {
            double num = Percentage(winningArray.Count, userArray.Length);

            if ( num == 0 || num < 33)
            {
                Console.WriteLine("\nYou Lose!!! ");
            }
            else if (num > 34 && num < 50)
            {
                Console.WriteLine("\nYou Win £10!!! ");
            }
            else if (num > 51 && num < 67)
            {
                Console.WriteLine("\nYou Win £1000!!! ");
            }
            else if (num > 68 && num < 83)
            {
                Console.WriteLine("\nYou Win £20,000!!! ");
            }
            else
            {
                Console.WriteLine("\nYou Win £100,000!!! ");
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
