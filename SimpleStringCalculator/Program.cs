using System;

namespace SimpleStringCalculator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var stringCalc = new StringCalculator();

            Console.WriteLine("String Calculator");

            Console.WriteLine("Enter numbers to calculate sum");
            var sum = Console.ReadLine();

            Console.WriteLine("The Sum is: " + stringCalc.Add(sum));

            Console.ReadLine();
        }
    }
}