// See https://aka.ms/new-console-template for more information

// 1. Write a C# program that reverses a given string (your name).
using System;

class Name
{
    public static string Reverse(string Input)
    {
        // Converting string to character array
        char[] charArray = Input.ToCharArray();

        // Declaring an empty string
        string reversedString = String.Empty;

        // Iterating the each character from right to left
        for (int i = charArray.Length - 1; i > -1; i--)
        {
            // Append each character to the reversedstring.
            reversedString += charArray[i];
        }
        // Return the reversed string.
        return reversedString;
    }
    // Driver code
    static void Main(string[] args)
    {
        Console.WriteLine(Reverse("AnestisKountourgiannis"));
    }
}

// 3. Write a C# program that asks the user for an integer (n) and finds all the prime numbers from 1 to n.
 
  public class PrimeNumberExample
{
    public static void Main(string[] args)
    {
        int n, i, m = 0, flag = 0;
        Console.Write("Enter the Number to check Prime: ");
        n = int.Parse(Console.ReadLine());
        m = n / 2;
        for (i = 2; i <= m; i++)
        {
            if (n % i == 0)
            {
                Console.Write("Number is not Prime.");
                flag = 1;
                break;
            }
        }
        if (flag == 0)
            Console.Write("Number is Prime.");
    }
}

//5. Write a C# program to sort the given array of integers from the lowest to the highest number.

namespace SortArrayExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = new int[] { 0, -2, 1, 20, -31, 50, -4, 17, 89, 100 };
            int temp = 0;

            for (int i = 0; i <= intArray.Length - 1; i++)
            {
                for (int j = i + 1; j < intArray.Length; j++)
                {
                    if (intArray[i] > intArray[j])
                    {
                        temp = intArray[i];
                        intArray[i] = intArray[j];
                        intArray[j] = temp;
                    }
                }
            }
            Console.WriteLine("Array sort in asscending order");
            foreach (var item in intArray)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}

// 2. Write a C# program that asks the user for an integer (n) and gives them the possibility to choose between computing the sum and computing the product of 1,…, n.

public class PrintNumbers
{
    public static void Main()
    {
        System.Int32 n = 0;
        for (string num = System.Console.ReadLine();
          !(string.IsNullOrEmpty(num) || null == num); num = num.Substring(1))
        {
            n = (n << 4) + (n << 2) - '0' + num[0];
        }

        int N = n;
        while (0 < N)
        {
            System.Console.WriteLine(~(N-- - n) + (1 << 1));
        }
    }
}
