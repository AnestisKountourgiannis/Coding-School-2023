using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_04
{
    //Write a C# program to print the sum of two numbers and the division of those two numbers.
    public class SumAndDivision
    {
        double NumberA = 8.8;
        double NumberB = 2.2;

        public void printNumbers()
        {
            Console.WriteLine("The Numbers are: " + NumberA + " " + NumberB);
        }
        public double CalculateSum()
        {
            double sum = NumberA + NumberB;
            return sum;
        }
        
        public double CalculateDivision()
        {
            double division = NumberA / NumberB;
            return division;
        }

    }
}
