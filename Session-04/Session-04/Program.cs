﻿// See https://aka.ms/new-console-template for more information
// 1. Write a C# program to print Hello and your name in the same line.
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