
namespace Question1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Entrez le type du Pokémon attaquant:");
            string typeAttaquant = Console.ReadLine();

            Console.Write("Entrez le type du Pokémon défendant:");
            string typeDefendant = Console.ReadLine();

            Console.Write("Entrez la puissance d'attaque (1-10):");
            int puissanceAttaque = int.Parse(Console.ReadLine());

            Console.Write("Entrez la capacité de défense (1-10):");
            int capaciteDefense = int.Parse(Console.ReadLine());

            double facteurEfficacite = ObtenirFacteurEfficacite(typeAttaquant, typeDefendant);

            double dommages = 25 * (puissanceAttaque / (double)capaciteDefense) * facteurEfficacite;
            Console.WriteLine($"Les dommages infligés sont de: {dommages}");

            if (dommages >= 50)
            {
                Console.WriteLine("L'adversaire n'a pas survécu.");
            }
            else
            {
                Console.WriteLine("L'adversaire a survécu.");
            }
        }

        static double ObtenirFacteurEfficacite(string attaquant, string defendant)
        {
            if (attaquant == "Feu" && defendant == "Herbe" ||
                attaquant == "Eau" && defendant == "Feu" ||
                attaquant == "Herbe" && defendant == "Eau")
            {
                return 2.0;
            }
            else if (attaquant == defendant)
            {
                return 0.5;
            }
            else
            {
                return 1.0;
            }
        }
    }
}
