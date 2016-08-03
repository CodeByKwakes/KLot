using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

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
            //ConfirmUserDetails();
        }

        public void GameWelcome()
        {
            Console.Clear();
            Console.WriteLine("Welcome to K-Lot \nPress Return to play");
            Console.ReadLine();
        }

        //public void GetUserDetails()
        //{
        //    Console.WriteLine("\nPlease enter the amount of lottery numbers you want to choose");
        //    UserInput(out GlobalVar.setArraySize);
        //    Console.WriteLine("\nPlease enter the min number range");
        //    UserInput(out GlobalVar.setMinValue);
        //    Console.WriteLine("\nPlease enter the max number range");
        //    UserInput(out GlobalVar.setMaxValue);
        //}

        public void SetUserDetails()
        {
            GlobalVar.userArray = new int[6];
            GlobalVar.resultArray = new int[6];
            GlobalVar.winningArray = new List<int>();
        }

        public void ConfirmUserDetails()
        {
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
        Scrapper web = new Scrapper();

        public void LotteryGamePlay()
        {
            InputLotteryNumbers(GlobalVar.userArray);
            ShowNumbers(GlobalVar.userArray, "\nThe numbers you entered were: \n");
            web.GetLotteryWebNumbers(GlobalVar.resultArray);
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
            foreach (int item in arr)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
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

    public class Scrapper
    {
        public void GetLotteryWebNumbers(int[] arr)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://www.national-lottery.co.uk/results/lotto/draw-history/draw-details/2150");
            HtmlNode[] nodes = doc.DocumentNode.SelectNodes("//*[@id='winning_numbers_lotto']/div/div/ol/li[position()<7]").ToArray();

            for (int i = 0; i < nodes.Length; i++)
            {
                int webNumber = int.Parse(nodes[i].InnerText);
                arr[i] = webNumber;
            }
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
