using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLotTickets
{
    class Program
    {
        public int userMoney;
        public int ticketPrice;
        public int totalTicketAmount;
        public int[][] ticketNoArray;
        public int[] userArray;
        public int[] resultArray = new int[6];
        public List<int> winningArray;
        public int numberInput;
        public bool status = false;

        static void Main(string[] args)
        {
            Program tkts = new Program();
            Console.WriteLine("Please set the price of a lottery ticket:");
            tkts.UserInput(out tkts.ticketPrice);
            Console.WriteLine("How much money to you have:");
            tkts.UserInput(out tkts.userMoney);
            tkts.totalTicketAmount = tkts.AmountOfTickets();
            Console.WriteLine($"You can buy {tkts.totalTicketAmount} tickets");

            do
            {
                Console.WriteLine("\nPlease enter the amount of lottery ticket you want to buy");
                tkts.UserInput(out tkts.numberInput);
            } while (tkts.IsTicketsNotValid());

            Console.WriteLine($"\nYou Entered: {tkts.numberInput} "); // testing
            tkts.SetTicketAmount();
            tkts.SetLotteyTickets();
            tkts.UserChoice();
            //tkts.EnterTicketNumbers();
            tkts.ShowTicketNumbers();
            tkts.GenerateRandomNumbers(tkts.resultArray);
            Console.Write("\nTonights winning numbers are : \n");
            tkts.ShowNumbers(tkts.resultArray);
            Console.ReadLine();
        }

        public void UserInput(out int input)
        {
            input = int.Parse(Console.ReadLine());
        }

        public int AmountOfTickets()
        {
            totalTicketAmount = userMoney / ticketPrice;
            return totalTicketAmount;
        }

        public bool IsTicketsNotValid()
        {
            bool status = false;
            if (numberInput > totalTicketAmount)
            {
                Console.Write($"\nYou do not have enough money to buy {numberInput}\n");
                status = true;
            }
            return status;
        }

        public void SetTicketAmount()
        {
            ticketNoArray = new int[numberInput][];
        }

        public void SetLotteyTickets()
        {
            for (int i = 0; i < ticketNoArray.Length; i++)
            {
                ticketNoArray[i] = new int[6];
            }
        }

        public void UserChoice()
        {
            for (int i = 0; i < ticketNoArray.Length; i++)
            {
                Console.WriteLine($"Ticket No: { i + 1}");
                Console.Write($"\nPress 1 to choose your own numbers for ticket no. {i + 1} \nOr \nPress 2 for a lucky dip\n");
                userArray = ticketNoArray[i];
                UserInput(out numberInput);
                switch (numberInput)
                {
                    case 1:
                        InputLotteryNumbers();
                        break;
                    case 2:
                        GenerateRandomNumbers(userArray);
                        break;                        
                } 
            }
            
        }

        public void GenerateRandomNumbers(int[] arr)
        {
            Random randomNumbers = new Random();
            int resultArrayNumber;

            for (int x = 0; x < arr.Length; x++)
            {
                resultArrayNumber = randomNumbers.Next(0, 60);

                arr[x] = arr.Contains(resultArrayNumber) ? x-- : resultArrayNumber;
            }
            Array.Sort(arr);
        }

        //public void EnterTicketNumbers()
        //{
        //    for (int i = 0; i < ticketNoArray.Length; i++)
        //    {
        //        Console.Write("\nPlease enter the 6 numbers for ticket " + (i + 1) + " : ");
        //        userArray = ticketNoArray[i];

        //        //Input Number Function
        //        InputLotteryNumbers();
        //    }
        //}

        public void InputLotteryNumbers()
        {
            for (int j = 0; j < userArray.Length; j++)
            {
                Console.Write("\nPlease enter lottery number " + (j + 1) + " : ");
                try
                {
                    UserInput(out numberInput);
                    userArray[j] = IsValidationFailed() ? j-- : numberInput;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    j--;
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
            if (input < 1 || input > 59)
            {
                Console.Write("\nPlease pick a number between 1 and 59\n");
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




        public void ShowTicketNumbers()
        {
            for (int i = 0; i < ticketNoArray.Length; i++)
            {
                Console.Write($"Here are your numbers for Ticket No {i + 1} \n");
                userArray = ticketNoArray[i];
                ShowNumbers(userArray);
                Console.WriteLine();
            }
        }

        public void ShowNumbers(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0}\t", arr[i]);
            }
            Console.WriteLine();
        }


    }
}
