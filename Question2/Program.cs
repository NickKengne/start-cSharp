using System;

namespace Question2
{
    class Program
    {
        static void Main(string[] args)
        {
            int nombreCalculs = 0;
            char refaireCalcul;

            do
            {
                Console.Clear();

                Console.Write("Entrez votre poids en kg:");
                double poids = double.Parse(Console.ReadLine());

                Console.Write("Entrez votre taille en mètres:");
                double taille = double.Parse(Console.ReadLine());

                double imc = poids / (taille * taille);
                Console.WriteLine($"Votre IMC est: {imc:F2}");

                if (imc < 18.5)
                {
                    Console.WriteLine("Catégorie: Insuffisance pondérale (maigreur)");
                }
                else if (imc < 24.9)
                {
                    Console.WriteLine("Catégorie: Corpulence normale");
                }
                else if (imc < 29.9)
                {
                    Console.WriteLine("Catégorie: Surpoids");
                }
                else
                {
                    Console.WriteLine("Catégorie: Obésité");
                }

                nombreCalculs++;

                Console.WriteLine("Voulez-vous refaire un calcul? (o/n)");
                refaireCalcul = Console.ReadKey().KeyChar;

            } while (refaireCalcul == 'o' || refaireCalcul == 'O');

            Console.WriteLine($"\nNombre de calculs effectués: {nombreCalculs}");
        }
    }
}
