using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLotTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.set amount of tickets a user wants to buy
            //2.configure the ticket prices and depending on how much money a user has depends how many ticket that user can buy
            //3.configure a lucky dip function so that a use can either manually enter all lottery ticket numbers or let the computer randomly choose.

        }
    }

    public static class GlobalVar
    {
        public static int setTicketSize; // set the size of the amount of lottery numbers to use
        //public static int setMinValue; // set the min number range of lottery numbers
        //public static int setMaxValue; // set the max number range of lottery numbers
        public static int[][] ticketNoArray;
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
            GetUserDetails();
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
            Console.WriteLine("\nPlease enter the amount of lottery ticket you want to buy");
            UserInput(out GlobalVar.setTicketSize);
            Console.WriteLine("\nPlease enter the min number range");
            //UserInput(out GlobalVar.setMinValue);
            Console.WriteLine("\nPlease enter the max number range");
            //UserInput(out GlobalVar.setMaxValue);
        }

        public void SetUserDetails()
        {
            GlobalVar.ticketNoArray = new int[GlobalVar.setTicketSize][];
            //for (int i = 0; i < GlobalVar.ticketNoArray.Length; i++)
            //{
            //    GlobalVar.userArray[i] = new int[6];
            //}
            //GlobalVar.userArray = new int[GlobalVar.setArraySize];
            //GlobalVar.resultArray = new int[GlobalVar.setArraySize];
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
}
