using System;

namespace CalculateurIMC
{
    class Program
    {
        static void Main(string[] args)
        {
            int nombreDeCalculs = 0;
            string continuer;

            do
            {
                Console.Clear();
                HeaderMenu();

                double poids = DemanderPoids();
                double taille = DemanderTaille();

                double imc = CalculerIMC(poids, taille);
                string categorie = DeterminerCategorie(imc);
                string risque = DeterminerRisque(imc);

                AfficherResultat(imc, categorie, risque);

                nombreDeCalculs++;

                continuer = DemanderSiContinuer();

            } while (continuer == "oui");

            AfficherNombreCalculs(nombreDeCalculs);
        }

        static void HeaderMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("************************************************************");
            Console.WriteLine("\t\tCALCULATEUR D'IMC");
            Console.WriteLine("************************************************************");
            Console.ResetColor();
        }

        static double DemanderPoids()
        {
            double poids;
            do
            {
                Console.Write("Votre poids en kg : ");
                string input = Console.ReadLine() ?? string.Empty;

                if (!double.TryParse(input, out poids) || poids <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Poids invalide, recommencez.");
                    Console.ResetColor();

                }

            } while (poids <= 0);

            return poids;
        }

        static double DemanderTaille()
        {
            double taille;
            do
            {
                Console.Write("Votre taille en mètres : ");
                string input = Console.ReadLine() ?? string.Empty;

                if (!double.TryParse(input, out taille) || taille <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Taille invalide, recommencez.");
                    Console.ResetColor();
                }

            } while (taille <= 0);

            return taille;
        }

        static double CalculerIMC(double poids, double taille)
        {
            return poids / (taille * taille);
        }

        static string DeterminerCategorie(double imc)
        {
            if (imc <= 18.5)
            {
                return "un poids insuffisant";
            }
            else if (imc < 25)
            {
                return "un poids santé";
            }
            else if (imc < 30)
            {
                return "un léger excès de poids";
            }
            else if (imc < 35)
            {
                return "une obésité classe I";
            }
            else if (imc < 40)
            {
                return "une obésité classe II";
            }
            else
            {
                return "une obésité classe III";
            }
        }

        static string DeterminerRisque(double imc)
        {
            return imc switch
            {
                <= 18.5 => "accrus",
                < 25 => "moindres",
                < 30 => "accrus",
                < 35 => "élevés",
                < 40 => "très élevés",
                _ => "extrêmement élevés"
            };

            // if (imc <= 18.5)
            // {
            //     return "accrus";
            // }
            // else if (imc < 25)
            // {
            //     return "moindres";
            // }
            // else if (imc < 30)
            // {
            //     return "accrus";
            // }
            // else if (imc < 35)
            // {
            //     return "élevés";
            // }
            // else if (imc < 40)
            // {
            //     return "très élevés";
            // }
            // else
            // {
            //     return "extrêmement élevés";
            // }
        }

        static void AfficherResultat(double imc, string categorie, string risque)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Votre IMC est de {imc:F1}, soit {categorie} et des risques {risque} de maladies.");
            Console.ResetColor();

        }

        static string DemanderSiContinuer()
        {
            Console.Write("Voulez-vous effectuer un autre calcul? (oui/non) : ");
            return Console.ReadLine() ?? string.Empty;
        }

        static void AfficherNombreCalculs(int nombreDeCalculs)
        {
             Console.ForegroundColor = ConsoleColor.DarkMagenta;
             Console.WriteLine($"Vous avez effectué {nombreDeCalculs} calcul(s).");
             Console.ResetColor();
        }
    }
}
