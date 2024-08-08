

namespace BowlingScores
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = DemanderNomJoueur();
            List<int> scores = SaisirScores();

            AfficherResultats(playerName, scores);
        }

        static string DemanderNomJoueur()
        {
            string playerName;
            do
            {
                Console.Write("Saisir le nom du joueur : ");
                playerName = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrEmpty(playerName))
                {
                    Console.WriteLine("Le nom est obligatoire, recommencez.");
                }
            } while (string.IsNullOrEmpty(playerName));

            return playerName.ToUpper();
        }

        static List<int> SaisirScores()
        {
            List<int> scores = [];
            string input;
            int partieNumber = 1;

            Console.WriteLine("Saisir le score de chacune des parties (\"fin\" pour terminer) :");

            do
            {
                Console.Write($"Partie #{partieNumber} : ");
                input = Console.ReadLine() ?? string.Empty;

                if (input.Equals("fin", StringComparison.CurrentCultureIgnoreCase))
                {
                    break;
                }

                if (!int.TryParse(input, out int score) || score < 0 || score > 300)
                {
                    if (!int.TryParse(input, out score))
                    {
                        Console.WriteLine("Score invalide, recommencez.");
                    }
                    else if (score < 0)
                    {
                        Console.WriteLine("Le score ne doit pas être inférieur à 0, recommencez.\n");
                    }
                    else if (score > 300)
                    {
                        Console.WriteLine("Le score ne doit pas dépasser 300, recommencez.\n");
                    }
                    continue;
                }

                scores.Add(score);
                AfficherNiveauEtMessage(score);
                partieNumber++;

            } while (true);

            return scores;
        }

        static void AfficherNiveauEtMessage(int score)
        {
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

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Niveau {niveau} : {message}\n");
            Console.ResetColor();
        }

        static void AfficherResultats(string playerName, List<int> scores)
        {
            if (scores.Count > 0)
            {
                double moyenne = scores.Average();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{playerName} : Moyenne de {moyenne:F1} en {scores.Count} partie(s).\n");
                Console.ResetColor();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{playerName} : Aucune partie jouée.");
                Console.ResetColor();

            }
        }
    }
}
