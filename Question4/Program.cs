using System;
using System.Collections.Generic;
using System.Linq;

namespace MathFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            HeaderMenu();
            List<int> numbers =[];
            List<int> squares = [];
            List<int> cubes = [];
            List<double> squareRoots = [];

            while (true)
            {
                Console.Write("Saisir un nombre entier positif (0 pour arrêter) : ");
                string input = Console.ReadLine() ?? string.Empty;

                if (input == "0") break;

                if (int.TryParse(input, out int number) && number > 0)
                {
                    numbers.Add(number);
                    squares.Add(number * number);
                    cubes.Add(number * number * number);
                    squareRoots.Add(Math.Round(Math.Sqrt(number), 1));

                    DisplayResults(number, number * number, number * number * number, Math.Round(Math.Sqrt(number), 1));
                }
                else
                {
                    DisplayErrorMessage();
                }
            }

            DisplayAverages(numbers, squares, cubes, squareRoots);
        }

        static void HeaderMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("******************************************************");
            Console.WriteLine("\t\tFONCTIONS MATHÉMATIQUES");
            Console.WriteLine("******************************************************");
            Console.ResetColor();
            Console.WriteLine("Saisir des nombres entiers positifs (0 pour arrêter) :\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10}", "Nombre", "Carré", "Cube", "Racine carrée");
            Console.ResetColor();
        }

        static void DisplayResults(int number, int square, int cube, double squareRoot)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10}", number, square, cube, squareRoot);
            Console.ResetColor();
        }

        static void DisplayErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("La valeur saisie n'est pas un nombre entier positif.");
            Console.ResetColor();
        }

        static void DisplayAverages(List<int> numbers, List<int> squares, List<int> cubes, List<double> squareRoots)
        {
            double avgNumber = numbers.Average();
            double avgSquare = squares.Average();
            double avgCube = cubes.Average();
            double avgSquareRoot = squareRoots.Average();

            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MOYENNES :\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10}", "Nombre", "Carré", "Cube", "Racine carrée");
            Console.WriteLine("{0,-10:F1} {1,-10:F1} {2,-10:F1} {3,-10:F1}", avgNumber, avgSquare, avgCube, avgSquareRoot);
            Console.ResetColor();
        }
    }
}
