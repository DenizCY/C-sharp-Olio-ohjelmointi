float playerHealth = 15f;
float enemyHealth = 15f;
bool playerWin = false;

// Pelin prologi
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Olet urhea ritari ja sinut on lähetetty kukistamaankylää kiusaavaa örkki.");
Console.WriteLine("Löydät örkin metsästä ja tämä hyökkää sinut kohti. Taistelu alkakoot!");
Console.ResetColor();
Console.WriteLine("-----------------------------------------------------------");

// Pyörii loputtomasti, kunnes peli ei lopu
while (!GameOver())
{
    Console.WriteLine($"Ritari(sinä): {playerHealth}/15  Örkki: {enemyHealth}/15");

    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("1 - Hyökkää miekalla");
    Console.WriteLine("2 - Puolustaudu kilvellä");
    Console.ResetColor();

    CombatManager();

    Console.WriteLine("-----------------------------------------------------------");
}

// Pelin epilogi
if (playerWin)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Urhea ritari sai örkkiä pakenemaan laaksosta, jossa kylä sijaitsi.");
    Console.WriteLine("Kylän asukkaat olivat todella kiitollisia ritarille ja valmistivat hänelle reilun ansion!");
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\t\t\t\tThe End");
    Console.ResetColor();
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Urhea ritari hävisi ja ei saanyt örkkiä poistumaan laaksosta, jossa kylä sijaitsi.");
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\t\t\t\tThe End");
    Console.ResetColor();
}

// Metodit //

// Pelin taistelu mekaniikka
void CombatManager()
{
    while (true)
    {
        // Tarkistaa, että pelaajan syöte olisi "1" tai "2" 
        Console.Write("Mitä haluat tehdä? ");
        string playerActionInput = Console.ReadLine();
        if (playerActionInput == string.Empty || !Char.IsDigit(playerActionInput, 0))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Päätä nopeammin!");
            Console.ResetColor();
            continue;
        }
        else
        {
            int playerActualAction = Convert.ToInt32(playerActionInput);
            float damageModifier;
            float actualDamage;

            // Päättää pelaajan syötteestä pelin suuntaa
            switch (playerActualAction)
            {
                case 1:
                    damageModifier = 1.0f;
                    actualDamage = PlayerDamageNumber(damageModifier);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Hyökkäät miekallasi!");
                    Console.WriteLine($"Sivallat örkkiä miekallasi. Teet örkkiin {actualDamage} pistettä vahinkoa!");
                    DamageDealPlayer(actualDamage);

                    actualDamage = EnemyDamageNumber(damageModifier);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Örkki hyökkää sinua kohti nuijallaan!");
                    Console.WriteLine($"Nuija osuu sinuun, tehden {actualDamage} vahinkoa.");
                    DamageDealEnemy(actualDamage);

                    Console.ResetColor();
                    break;
                case 2:
                    damageModifier = 0.5f;
                    actualDamage = EnemyDamageNumber(damageModifier);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Nostat kilpesi puolustuksesi!");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Örkki hyökkää sinua kohti nuijallaan!");
                    Console.WriteLine($"Nuija osuu sinuun, tehden {actualDamage} vahinkoa.");
                    DamageDealEnemy(actualDamage);

                    Console.ResetColor();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Päätä nopeammin!");
                    Console.ResetColor();
                    continue;
            }

            break;
        }
    }
}

// Nämä kaksi metodia vähentävät pelaajan ja örkin terveyspisteitä
void DamageDealEnemy(float damageNumber)
{
    playerHealth -= damageNumber;
}

void DamageDealPlayer(float damageNumber)
{
    enemyHealth -= damageNumber;
}

// Laskee pelaajan tekemän vahingon numeron
float PlayerDamageNumber(float damageModifier)
{
    Random random = new Random();

    int bruttoDamage = random.Next(1, 6);

    return (float)bruttoDamage * damageModifier;
}

// Laskee örkin tekemän vahingon numeron
float EnemyDamageNumber(float damageModifier)
{
    Random random = new Random();

    int bruttoDamage = random.Next(1, 4);

    return (float)bruttoDamage * damageModifier;
}

// Tarkistaa pelin tilannetta.
bool GameOver()
{
    if (playerHealth <= 0)
    {
        playerHealth = 0;
        return true;
    }
    else if (enemyHealth <= 0)
    {
        enemyHealth = 0;
        playerWin = true;
        return true;
    }
    else
    {
        return false;
    }
}

