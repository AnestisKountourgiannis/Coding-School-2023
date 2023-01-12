using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_04
{
    //Write a C# program to print the sum of two numbers and the division of those two numbers.
    public class SumAndDivision {
        int NumberA = 8;
        int NumberB = 2;
        public void printNumbers()
        {
            int NumberA = 8;
            int NumberB = 2;
            Console.WriteLine("The Numbers are: " + NumberA + " " + NumberB);
        }
        public int CalculateSum()
        {
            int sum = NumberA + NumberB;
            return sum;
        }
        
        public int CalculateDivision()
        {
            int division = NumberA / NumberB;
            return division;
        }

    }
}
