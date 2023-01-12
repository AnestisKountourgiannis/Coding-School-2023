// See https://aka.ms/new-console-template for more information
// 1. Write a C# program to print Hello and your name in the same line.
using System.Globalization;
using System.Runtime.CompilerServices;

string hello = "Hello";
string name = " Anestis";

Console.WriteLine(hello + name);

//2.Write a C# program to print the sum of two numbers and the division of those two numbers.

int NumberA = 8;
int NumberB = 2;
int NumberC = NumberA + NumberB;
int NumberD = NumberA / NumberB;
Console.WriteLine(NumberC);
Console.WriteLine(NumberD);

//3.Write a C# program to print the result of the specified operations:

int Act1 = ((-1) + (5 * 6));
Console.WriteLine(Act1);
int Act2 = (38 + (5 % 7));
Console.WriteLine(Act2);
float Act3 = (14 + (((-3) * 6) / 7));
Console.WriteLine(Act3);
double Act4 = ((2 + (13 / 6)) * 6 + Math.Sqrt(7));
Console.WriteLine(Act4);
int Act5 = ((6 ^ 4) + (5 ^ 7) / ((9 % 4)));
Console.WriteLine(Act5);

//5.Write a C# program that takes an integer representing seconds (for example 45678) and converts it to :
int n = 129600;

int year = n / (365 * 86400);

n = n % (365 * 86400);
int day = n / (24 * 3600);

n = n % (24 * 3600);
int hour = n / 3600;

n %= 3600;
int minutes = n / 60;

n %= 60;
int seconds = n;

Console.WriteLine( year + " " + "years " + day + " " + "days " + hour + " " + "hours " + minutes + " " + "minutes " + seconds + " " + "seconds ");

//6.Rewrite Program #5 using .Net Libraries.
TimeSpan t = TimeSpan.FromSeconds(45678);
string answer = string.Format(
      CultureInfo.CurrentCulture,
      "{0} years, {1} days, {2} hours, {3} minutes", t.Days / 365,
      (t.Days - (t.Days / 365) * 365) - ((t.Days - (t.Days / 365) * 365) / 30) * 30, t.Hours, t.Minutes);
Console.WriteLine(" " + answer);

//7.Write a C# program to convert from celsius degrees to Kelvin and Fahrenheit
Console.Write("Enter the amount of Celsius: ");
int celsius = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Kelvin = {0}", celsius + 273);
Console.WriteLine("Fahrenheit = {0}", celsius * 18 / 10 + 32);

//4.Write a C# program that assigns an age (number) (for example 20) and a gender(string) (for example female) and displays something like: "You are female and look younger than 20."
string gen = "woman";
//Console.Write("Enter your gender ");
int age;
Console.Write("Enter your age ");
age = Convert.ToInt32(Console.ReadLine());
Console.Write("You are {0} and look younger than {1} ", gen,age);

