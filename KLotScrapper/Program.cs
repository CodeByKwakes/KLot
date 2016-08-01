using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLotScrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            GameSetUp game = new GameSetUp();
            LotteryData lotto = new LotteryData();
            Results result = new Results();
            ResetGame reset = new ResetGame();
            do
            {
                game.GameIntro();
                lotto.LotteryGamePlay();
                result.GameResults();
            } while (reset.WouldYouLikeToRestart());
            reset.Exit();
        }
    }

    public static class GlobalVar
    {
        public static int setArraySize;
        public static int setMinValue;
        public static int setMaxValue;
        public static int[] userArray;
        public static int[] resultArray;
        public static List<int> winningArray;
        public static int numberInput;
    }

    public class GameSetUp
    {
        public void GameIntro()
        {
            GameWelcome();
            //GetUserDetails();
            SetUserDetails();
            ConfirmUserDetails();
        }

        public void GameWelcome()
        {
            Console.Clear();
            Console.WriteLine("Welcome to K-Lot \nPress Return to play");
            Console.ReadLine();
        }

        public void GetUserDetails()
        {
            Console.WriteLine("\nPlease enter the amount of lottery numbers you want to choose");
            UserInput(out GlobalVar.setArraySize);
            Console.WriteLine("\nPlease enter the min number range");
            UserInput(out GlobalVar.setMinValue);
            Console.WriteLine("\nPlease enter the max number range");
            UserInput(out GlobalVar.setMaxValue);
        }

        public void SetUserDetails()
        {
            GlobalVar.userArray = new int[6];
            GlobalVar.resultArray = new int[6];
            GlobalVar.winningArray = new List<int>();
        }

        public void ConfirmUserDetails()
        {
            //Console.WriteLine("\nYou have set the following: \nAmount of Lottery Number: " + GlobalVar.setArraySize + "\nMin number range: " + GlobalVar.setMinValue + "\nMax number range: " + GlobalVar.setMaxValue);
            Console.WriteLine("\nPress Return to play");
            Console.ReadLine();
        }

        public void UserInput(out int input)
        {
            input = int.Parse(Console.ReadLine());
        }

    }

    public class LotteryData
    {
        Validation valid = new Validation();
        GameSetUp game = new GameSetUp();

        public void LotteryGamePlay()
        {
            InputLotteryNumbers(GlobalVar.userArray);
            ShowNumbers(GlobalVar.userArray, "\nThe numbers you entered were: \n");
            GenerateRandomNumbers(GlobalVar.resultArray);
            ShowNumbers(GlobalVar.resultArray, "\nTonights winning numbers are : \n");
        }

        public void InputLotteryNumbers(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("\nPlease enter lottery number " + (i + 1) + " : ");
                try
                {
                    game.UserInput(out GlobalVar.numberInput);
                    arr[i] = valid.IsValidationFailed() ? i-- : GlobalVar.numberInput;
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
                resultArrayNumber = randomNumbers.Next(1, 59);
                arr[x] = arr.Contains(resultArrayNumber) ? x-- : resultArrayNumber;
            }
            Array.Sort(arr);
        }
    }

    public class Validation
    {
        public bool IsValidationFailed()
        {
            bool status = false;

            if (IsNotValidNumber(GlobalVar.numberInput, 1, 59) || IsDuplicate(GlobalVar.userArray, GlobalVar.numberInput))
            {
                status = true;
            }
            return status;
        }

        public bool IsNotValidNumber(int input, int min, int max)
        {
            bool status = false;
            if (input < min || input > max)
            {
                Console.Write("\nPlease pick a number between " + min + " and " + max + "\n");
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
    }

    public class Results
    {
        public void GameResults()
        {
            CalculateResults(GlobalVar.userArray, GlobalVar.resultArray, GlobalVar.winningArray);
            DisplayWinningResults(GlobalVar.winningArray);
            WinningMessage(GlobalVar.winningArray);
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
            string percent = GetPercentage((double)arr.Count / GlobalVar.userArray.Length);
            Console.WriteLine("\nYou matched: " + arr.Count + " (" + percent + ") numbers:");

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
            double num = Percentage(GlobalVar.winningArray.Count, GlobalVar.userArray.Length);

            if (num == 0 || num < 33)
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

    }

    public class ResetGame
    {
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
