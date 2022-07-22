using System;
using static System.Console;
namespace P0
{
    class Program
    {
        static void Main()
        {
            Clear();
            Pizzaz.Titlecard();
            int round = 1;
            Shooter player = new Shooter();
            Shooter rival = new Shooter();
            while (player.alive == true && rival.alive == true)
            {
                Clear();
                WriteLine("\n---------- ROUND: " + round++ + " ----------\n");
                choices(player);
                rivalBot(rival);
                Pizzaz.Typing("\nPress the 'SPACEBAR' to see your fate...");
                while (Console.ReadKey().Key != ConsoleKey.Spacebar) { }
                WriteLine();
                winConditions(player, rival);
                ReadKey();
            }
            if (player.alive == true && rival.alive == false)
            {
                Pizzaz.finalMessage(1);
                // WriteLine("\nYou Won!");
            }
            else if (player.alive == false && rival.alive == true)
            {
                Pizzaz.finalMessage(2);
                // WriteLine("\nYou Died!");
            }
            else
            {
                Pizzaz.finalMessage(3);
                // WriteLine("\nThere are no victors... no survivors...");
            }
        }

        static void choices(Shooter gunman)
        {
            bool picked = false;
            while (picked != true)
            {
                Write("1. SHOOT\n2. RELOAD\n3. SHIELD\nPick an action: ");
                string? choice = ReadLine();
                WriteLine();
                switch (choice)
                {
                    case "1":
                        picked = true;
                        shooting(gunman);
                        break;
                    case "2":
                        picked = true;
                        reloading(gunman);
                        break;
                    case "3":
                        picked = true;
                        gunman.shield = true;
                        Pizzaz.Typing("You shield yourself from the inevitable.");
                        break;
                    default:
                        Pizzaz.Typing("Invalid choice\nPlease type in '1', '2', or '3'\n");
                        break;
                }
            }
        }

        static void shooting(Shooter gunman)
        {
            if (gunman.bullets > 0)
            {
                if (gunman.bullets < 3)
                {
                    gunman.bullets--;
                    Pizzaz.Typing("You take aim. Good luck.");
                }
                else
                {
                    Pizzaz.Typing("You pull out a BAZOOKA. Raise hell.");
                }
                gunman.shoot = true;

            }
            else
            {
                Pizzaz.Typing("*CLICK*\nNothing happened. You forgot to reload!!!");
            }
        }

        static void reloading(Shooter gunman)
        {
            if (gunman.bullets < 3)
            {
                gunman.bullets++;
                gunman.reload = true;
                if (gunman.bullets == 3)
                {
                    Pizzaz.Typing("Bazooka Unlocked!!!");
                }
                else
                {
                    Pizzaz.Typing("You chamber a round into your gun.");
                }
            }
            else
            {
                Pizzaz.Typing("Can't reload anymore.\nYou got a Bazooka! Use it!.");
            }

        }

        static void rivalBot(Shooter gunman)
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 4);
            switch (num) // set it to 3 if you want to play with a coward
            {
                case 1:
                    if (gunman.bullets > 0)
                    {
                        if (gunman.bullets < 3)
                            gunman.bullets--;
                        gunman.shoot = true;
                        Pizzaz.Typing("You see your rival raise their gun.");
                    } else{
                        Pizzaz.Typing("Your rivals points their gun at you but you hear a click.");
                    }
                    
                    break;
                case 2:
                    if (gunman.bullets < 3)
                    {
                        gunman.bullets++;
                        gunman.reload = true;
                    }
                    Pizzaz.Typing("You see your rival loading a round into their gun.");
                    break;
                case 3:
                    gunman.shield = true;
                    Pizzaz.Typing("You see your rival raising up their shield.");
                    break;
            }
        }

        static void winConditions(Shooter you, Shooter them)
        {
            if (you.shoot == true || them.shoot == true)
            {
                if (you.shoot == true && you.bullets == 3)
                {
                    them.alive = false;
                    Pizzaz.Typing("You blew up your rival with a Bazooka.");
                }
                else if (them.shoot == true && them.bullets == 3)
                {
                    you.alive = false;
                    Pizzaz.Typing("Your rival blew you up with a Bazooka.");
                }
                else if (you.shoot == true && them.shoot == true)
                {
                    you.alive = false;
                    them.alive = false;
                    Pizzaz.Typing("You both traded shots... and your lives.");
                }
                else if (you.shoot == true)
                {
                    if (them.reload == true)
                    {
                        them.alive = false;
                        Pizzaz.Typing("You shot them while they were reloading... Cold...");
                    }
                    else if (them.shield == false)
                    {
                        them.alive = false;
                        Pizzaz.Typing("You fire your shot. Your rival drops.");
                    }
                }
                else if (them.shoot == true)
                {
                    if (you.reload == true)
                    {
                        you.alive = false;
                        Pizzaz.Typing("They shot you while you were reloading.");
                    }
                    else if (you.shield == false)
                    {
                        you.alive = false;
                        Pizzaz.Typing("You hear a shot and everything goes black.");
                    }
                }
            }

            if (you.alive == true && them.alive == true)
                Pizzaz.Typing("You both survived.");
            you.shoot = false; you.reload = false; you.shield = false; them.shoot = false; them.reload = false; them.shield = false;
        }
    }
}