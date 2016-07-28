using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLotSingleClass
{
    class Program
    {
        
        int[] userArray = new int[6];
        int[] resultArray = new int[6];
        List<int> winningArray = new List<int>();
        int numberInput;

        static void Main(string[] args)
        {
            Program kLot = new Program();
            kLot.InputLotteryNumbers(kLot.userArray);
            Console.WriteLine("\n\n");
            kLot.ShowNumbers(kLot.userArray, "\nThe numbers you entered were: \n");
            kLot.GenerateRandomNumbers(kLot.resultArray);
            kLot.ShowNumbers(kLot.resultArray, "Tonights winning numbers are : \n");
            kLot.DisplayWinningResults(kLot.winningArray);
            kLot.WinningMessage();
            Console.ReadLine();
        }

        // 
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
        }
        public bool IsValidationFailed()
        {
            bool status = false;
            if (IsDuplicate(userArray, numberInput) || IsNotVaildNumber(numberInput))
            {
                status = true;
            }
            return status;
        }
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
}
