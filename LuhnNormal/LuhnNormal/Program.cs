using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuhnNormal
{
    class Program
    {
        static void Main(string[] args)
        {
            bool programActive = true;

            Console.WriteLine("<<< Welcome to the personal indentification number verification tool >>>");

            while (programActive)
            {
                Console.WriteLine();
                Console.Write("Enter any personal indentification number (ctrl-c to quit): ");
                Console.WriteLine();

                IdentityNumber inputIdentity = null;
                bool isNumberValidLuhn = false;

                try
                {
                    string input = Console.ReadLine();
                    inputIdentity = new IdentityNumber(input);

                    isNumberValidLuhn = inputIdentity.ValidateUsingLuhn();
                }
                catch (ArgumentException)
                {

                    Console.WriteLine("\nThe identity number was incorrectly formatted!");
                    Console.WriteLine("\nValid Format: xxxxxxyyyy (Example: 4501011234)");
                    continue;
                }

                if (isNumberValidLuhn)
                {
                    Console.WriteLine("Number correct according to the Luhn algorith");
                }
                else
                {
                    Console.WriteLine("The number is NOT a valid personal identity number");
                }
            }
        }
    }
}
