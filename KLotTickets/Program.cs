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
                resultArrayNumber = randomNumbers.Next(0, 50);

                arr[x] = arr.Contains(resultArrayNumber) ? x-- : resultArrayNumber;
            }
            Array.Sort(arr);
        }

        public void EnterTicketNumbers()
        {
            for (int i = 0; i < ticketNoArray.Length; i++)
            {
                Console.Write("\nPlease enter the 6 numbers for ticket " + (i + 1) + " : ");
                userArray = ticketNoArray[i];

                //Input Number Function
                InputLotteryNumbers();
            }
        }

        public void InputLotteryNumbers()
        {
            for (int j = 0; j < userArray.Length; j++)
            {
                Console.Write("\nPlease enter lottery number " + (j + 1) + " : ");
                UserInput(out numberInput);
                userArray[j] = numberInput;
            }
        }

        public void ShowTicketNumbers()
        {
            for (int i = 0; i < ticketNoArray.Length; i++)
            {
                Console.Write($"Here are your numbers for Ticket No {i + 1} \n");
                userArray = ticketNoArray[i];
                ShowNumbers();
            }
        }

        public void ShowNumbers()
        {
            //Console.Write("Here are your Ticket Numbers \n");
            for (int i = 0; i < userArray.Length; i++)
            {
                Console.Write("{0}\t", userArray[i]);
            }
            Console.WriteLine();
        }
    }
}
