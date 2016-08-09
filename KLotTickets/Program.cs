using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLotTickets
{
    class Program
    {
        public int[][] ticketNoArray;
        public int[] userArray;
        public int numberInput;

        static void Main(string[] args)
        {
            Program tkts = new Program();
            Console.WriteLine("\nPlease enter the amount of lottery ticket you want to buy");
            tkts.UserInput(out tkts.numberInput);
            Console.WriteLine($"\nYou Entered: {tkts.numberInput} "); // testing
            tkts.SetTicketAmount();
            tkts.SetLotteyTickets();
            tkts.EnterTicketNumbers();
            tkts.ShowTicketNumbers();
            Console.ReadLine();
        }

        public void UserInput(out int input)
        {
            input = int.Parse(Console.ReadLine());
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

        public void EnterTicketNumbers()
        {
            for (int i = 0; i < ticketNoArray.Length; i++)
            {
                Console.Write("\nPlease enter the 6 numbers for ticket " + (i + 1) + " : ");
                userArray = ticketNoArray[i];

                //Input Number Function
                for (int j = 0; j < userArray.Length; j++)
                {
                    Console.Write("\nPlease enter lottery number " + (j + 1) + " : ");
                    UserInput(out numberInput);
                    userArray[j] = numberInput;
                }

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
