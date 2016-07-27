using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLotVersion3
{

    class Program
    {
        int userInput;
        int[] userArray = new int[6];

        public void InputLotteryNumbers()
        {
            for (int i = 0; i < 6; i++)
            {
                Console.Write("\nPlease enter lottery number " + (i + 1) + " : ");
                userArray[i] = int.Parse(Console.ReadLine());
            }

            //userInput = int.Parse(Console.ReadLine());
        }

        public void ShowUserNumbers()
        {
            Console.Write("\nThe number you inputed was: {0}, {1}, {2}, {3}, {4}, {5}", userArray[0], userArray[1], userArray[2], userArray[3], userArray[4], userArray[5]);
            //Console.Write("\nThe number you inputed was: " + userInput);
        }

        public void UserLotteryTicket()
        {

        }

        static void Main(string[] args)
        {
            Program kLot = new Program();
            kLot.InputLotteryNumbers();
            Console.WriteLine("\n\n");
            kLot.ShowUserNumbers();
            Console.ReadLine();
        }
    }
}
