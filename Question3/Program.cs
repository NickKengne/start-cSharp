using System;
using System.Collections.Generic;

namespace Question3
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName;
            List<int> scores = new List<int>();
            string input;
            int score;

            Console.WriteLine("************************************************************");
            Console.WriteLine("PARTIES DE QUILLES");
            Console.WriteLine("************************************************************");

            // Demander le nom du joueur
                Console.Write("Saisir le nom du joueur : ");
            do
            {
                playerName = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(playerName))
                {
                    Console.WriteLine("Le nom est obligatoire, recommencez.");
                }
            } while (string.IsNullOrEmpty(playerName));
            playerName = playerName.ToUpper();

            // Demander les scores des parties
            int partieNumber = 1;
            do
            {
                Console.Write($"Partie #{partieNumber} : ");
                input = Console.ReadLine().Trim();

                if (input.ToLower().Equals("fin"))
                {
                    break;
                }

                if (!int.TryParse(input, out score))
                {
                    Console.WriteLine("Score invalide, recommencez.");
                    continue;
                }

                if (score < 0)
                {
                    Console.WriteLine("Le score ne doit pas être inférieur à 0, recommencez.");
                    continue;
                }

                if (score > 300)
                {
                    Console.WriteLine("Le score ne doit pas dépasser 300, recommencez.");
                    continue;
                }

                // Ajouter le score à la liste
                scores.Add(score);
                // Afficher le niveau et le message correspondant
                string niveau;
                string message;
                if (score == 300)
                {
                    niveau = "A+";
                    message = "Partie parfaite !";
                }
                else if (score >= 250)
                {
                    niveau = "A";
                    message = "Excellent !";
                }
                else if (score >= 200)
                {
                    niveau = "B";
                    message = "Très bon !";
                }
                else if (score >= 150)
                {
                    niveau = "C";
                    message = "Bon !";
                }
                else if (score >= 100)
                {
                    niveau = "D";
                    message = "Correct";
                }
                else
                {
                    niveau = "E";
                    message = "Oups :-)";
                }

                Console.WriteLine($"Niveau {niveau} : {message}");
                partieNumber++;

            } while (true);

            // Calculer la moyenne des scores
            double moyenne = 0;
            if (scores.Count > 0)
            {
                moyenne = scores.Average();
            }

            // Afficher les résultats
            Console.WriteLine($"{playerName} : Moyenne de {moyenne:F1} en {scores.Count} partie(s)");
        }
    }
}
