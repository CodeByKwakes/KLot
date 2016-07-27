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

        public void InputLotteryNumbers()
        {
            Console.Write("\nPlease Enter a lottery number: ");
            userInput = int.Parse(Console.ReadLine());
        }

        public void ShowUserNumbers()
        {
            Console.Write("\nThe number you inputed was: " + userInput);
        }

        static void Main(string[] args)
        {
            Program kLot = new Program();
            kLot.InputLotteryNumbers();
            kLot.ShowUserNumbers();
            Console.ReadLine();
        }
    }
}
