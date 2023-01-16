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
