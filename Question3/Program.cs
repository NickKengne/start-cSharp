

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

                if (!int.TryParse(input, out int score))
                {
                    Console.WriteLine("Score invalide, recommencez.");
                    continue;
                }
                else if (score < 0)
                {
                    Console.WriteLine("Le score ne doit pas être inférieur à 0, recommencez.\n");
                    continue;
                }
                else if (score > 300)
                {
                    Console.WriteLine("Le score ne doit pas dépasser 300, recommencez.\n");
                    continue;
                }

                scores.Add(score);
                AfficherNiveauEtMessage(score);
                partieNumber++;

            } while (true);

            return scores;
        }

        // TODO: Completer les règles
        private static readonly Dictionary<int, (string, string)> _regles = new()
        {
            { 300, ("A+", "Partie parfaite !") },
            { 200, ("A+", "Partie parfaite !") },
        };

        static void AfficherNiveauEtMessage(int score)
        {
            var (niveau, message) = _regles[score];
            // var (niveau, message) = score switch
            // {
            //     300 => ("A+", "Partie parfaite !"),
            //     250 => ("A", "Excellent !"),
            //     200 => ("B", "Très bon !"),
            //     150 => ("C", "Bon !"),
            //     100 => ("D", "Correct"),
            //     _ => ("E", "Oups :-)")
            // };

            // if (score == 300)
            // {
            //     niveau = "A+";
            //     message = "Partie parfaite !";
            // }
            // else if (score >= 250)
            // {
            //     niveau = "A";
            //     message = "Excellent !";
            // }
            // else if (score >= 200)
            // {
            //     niveau = "B";
            //     message = "Très bon !";
            // }
            // else if (score >= 150)
            // {
            //     niveau = "C";
            //     message = "Bon !";
            // }
            // else if (score >= 100)
            // {
            //     niveau = "D";
            //     message = "Correct";
            // }
            // else
            // {
            //     niveau = "E";
            //     message = "Oups :-)";
            // }

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
