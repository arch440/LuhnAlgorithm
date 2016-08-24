using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunhMicro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter national identification number (XXXXXXyyyy): ");
            int[] input = Array.ConvertAll(Console.ReadLine().ToCharArray(), item => (int)(item - '0'));
            int[] test = Array.ConvertAll(new char[10] { '2', '1', '2', '1', '2', '1', '2', '1', '2', '1' }, item => (int)(item - '0'));
            string val = "";
            for (int i = 0; i < 10; i++) { 
                val += (input[i] * test[i]).ToString();
            }
            Console.WriteLine((Array.ConvertAll(val.ToCharArray(), item => (int)(item - '0')).Sum() % 10) == 0 ? "Number is correct" : "Number is incorrect");
            Console.ReadKey();
        }
    }
}
