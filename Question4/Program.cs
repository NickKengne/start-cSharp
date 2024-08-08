using System;
using System.Collections.Generic;

namespace Question4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            List<double> squares = new List<double>();
            List<double> cubes = new List<double>();
            List<double> squareRoots = new List<double>();

            Console.WriteLine("**********************************************************************");
            Console.WriteLine("FONCTIONS MATHÉMATIQUES");
            Console.WriteLine("**********************************************************************");
            Console.WriteLine("Saisir des nombres entiers positifs (0 pour arrêter) :");

            while (true)
            {
                Console.Write("Nombre : ");
                string input = Console.ReadLine().Trim();

                if (!int.TryParse(input, out int number) || number < 0)
                {
                    Console.CursorTop -= 1;
                    Console.WriteLine($"La valeur saisie n'est pas un nombre entier positif.");
                    continue;
                }

                if (number == 0)
                {
                    break;
                }

                double square = Math.Pow(number, 2);
                double cube = Math.Pow(number, 3);
                double squareRoot = Math.Sqrt(number);

                numbers.Add(number);
                squares.Add(square);
                cubes.Add(cube);
                squareRoots.Add(squareRoot);

                Console.CursorTop -= 1;
                Console.WriteLine($"Nombre : {number}\tCarré : {square}\tCube : {cube}\tRacine carrée : {squareRoot:F2}");
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine("Aucun nombre entier saisi.");
                return;
            }

            double averageNumber = CalculateAverage(numbers);
            double averageSquare = CalculateAverage(squares);
            double averageCube = CalculateAverage(cubes);
            double averageSquareRoot = CalculateAverage(squareRoots);

            Console.WriteLine("\nMOYENNES :");
            Console.WriteLine($"Nombre : {averageNumber:F1}");
            Console.WriteLine($"Carré : {averageSquare:F1}");
            Console.WriteLine($"Cube : {averageCube:F1}");
            Console.WriteLine($"Racine carrée : {averageSquareRoot:F1}");
        }

        static double CalculateAverage(List<double> values)
        {
            if (values.Count == 0)
                return 0;

            double sum = 0;
            foreach (var value in values)
            {
                sum += value;
            }
            return sum / values.Count;
        }

        static double CalculateAverage(List<int> values)
        {
            if (values.Count == 0)
                return 0;

            double sum = 0;
            foreach (var value in values)
            {
                sum += value;
            }
            return sum / values.Count;
        }
    }
}
