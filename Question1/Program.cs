using System;

class Program
{
    static void Main()
    {
        HeaderMenu();

        int attackerType = GetPokemonType("attaquant");
        int defenderType = GetPokemonType("défendant");

        int attackPower = GetPowerOrDefense("puissance d'attaque");
        int defensePower = GetPowerOrDefense("capacité de défense");

        double effectivenessFactor = GetEffectivenessFactor(attackerType, defenderType);

        double damage = CalculateDamage(attackPower, defensePower, effectivenessFactor);

        //interpoler ici , et extraire la chaine 
        Console.WriteLine($"\nL'attaque {(effectivenessFactor == 2 ? "super efficace" : effectivenessFactor == 1)} a produit {damage} points de dommages.");
        if (damage >= 100)
        {
            Console.WriteLine("Le Pokémon défendant a été vaincu.");
        }
        else
        {
            Console.WriteLine($"Le Pokémon défendant a survécu avec {100-damage} points de vie restant.");
        }
    }

    static void HeaderMenu()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("**************************************");
        Console.WriteLine("\t\tCOMBAT DE POKEMONS");
        Console.WriteLine("**************************************");
        Console.ResetColor();
    }

    static int GetPokemonType(string role)
    {
        int type;
        do
        {
            Console.WriteLine($"\nSaisir le type du Pokémon {role} :");
            Console.WriteLine("1 - Feu\n2 - Terre\n3 - Eau\n4 - Électricité");
            if (!int.TryParse(Console.ReadLine(), out type) || type < 1 || type > 4)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Type invalide, recommencez.");
                Console.ResetColor();

            }
        } while (type < 1 || type > 4);

        return type;
    }

    static int GetPowerOrDefense(string type)
    {
        int value;
        do
        {
            Console.WriteLine($"\nSaisir la {type} du Pokémon (de 1 à 10) :");
            if (!int.TryParse(Console.ReadLine(), out value) || value < 1 || value > 10)
            {
                Console.WriteLine("Valeur invalide, recommencez.");
            }
        } while (value < 1 || value > 10);

        return value;
    }

    static double GetEffectivenessFactor(int attackerType, int defenderType)
    {
        if (attackerType == 1 && defenderType == 2) // Feu superieur a la  Terre
            return 2;
        else if (attackerType == 1 && defenderType == 3) // Feu superieur a la Eau
            return 0.5;
        else if (attackerType == 3 && defenderType == 2) // Eau superieur a la Terre
            return 0.5;
        else if (attackerType == 3 && defenderType == 4) // Eau superieur a la Électricité
            return 0.5;
        else if (attackerType == 2 && defenderType == 1) // Terre superieur a la Feu
            return 0.5;
        else if (attackerType == 2 && defenderType == 3) // Terre superieur a la Eau
            return 2;
        else
            return 1;
    }

    static double CalculateDamage(int attackPower, int defensePower, double effectivenessFactor)
    {
        return Math.Floor(25 * (attackPower / (double)defensePower) * effectivenessFactor);
    }
}
