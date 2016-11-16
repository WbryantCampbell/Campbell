using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip.UI
{
    public class GameInput
    {
        //private object view;

        /* 
         * The PromptForPlayerName method will prompt a user for a name and validate that it is between 1 and 20 characters long
         * Parameters: integer
         * Returns: string
         */
        public string PromptForPlayerName(int playerNum)
        {
            string rv;
            do
            {
                Sound prompt = new Sound();
                prompt.Prompt();
                Console.Clear();
                Console.Write($"Player {playerNum}, please enter your name: ");
                rv = Console.ReadLine();
                if (rv.Length > 0 && rv.Length <= 20) break;
                Sound play = new Sound();
                play.Error();
                Console.Write($"You must enter a name between 1 and 20 characters in length. Press ANY key to continue...");
                Console.ReadKey();
            } while (true);
            return rv;
        }

        /* The PromptForPlayerName method will prompt a user for a coordinate on the board to place the ship
         * Parameters: string
         * Returns: string
         */
        public string PromptForCoordinate(string playerName, ShipType ship, int length)
        {
            string rv = "";
            do
            {
                Sound prompt = new Sound();
                prompt.Prompt();
                Console.WriteLine($"");
                Console.Write($"{playerName}, enter a coordinate for your {ship}(Length={length}) Ex.B3: ");

                rv = Console.ReadLine().ToUpper();

                //Translate the coordinate into something we can use
                // Use cases where length == 3(substring(1, 1) == 1 and substring(2, 1) == 0)
                // and length = 2
                if (rv.Length == 3)
                {
                    if (rv[0] >= 'A' && rv[0] <= 'J' && rv[1] == '1' && rv[2] == '0')
                    {
                        break;
                    }
                    else
                    {
                        Sound play = new Sound();
                        play.Error();
                        Console.WriteLine($"{playerName}, {rv} is not a valid coordinate. Press ANY key to continue...");
                        Console.ReadKey();
                        Console.WriteLine();
                    }
                }

                else if (rv.Length == 2)
                {
                    if (rv[0] >= 'A' && rv[0] <= 'J' && rv[1] >= '1' && rv[1] <= '9')
                    {
                        break;
                    }

                    else
                    {
                        Sound play = new Sound();
                        play.Error();
                        Console.WriteLine($"{playerName}, {rv} is not a valid coordinate. Press ANY key to continue...");
                        Console.ReadKey();
                        Console.WriteLine();
                    }
                }

                else
                {
                    Sound play = new Sound();
                    play.Error();
                    Console.WriteLine($"{playerName}, {rv} is not a valid coordinate. Press ANY key to continue...");
                    Console.ReadKey();
                    Console.WriteLine();
                }
            } while (true);
            Console.WriteLine();
            return rv;
        }

        public string PromptForCoordinate(string playerName)
        {
            string rv = "";
            do
            {
                Sound prompt = new Sound();
                prompt.Prompt();
                Console.WriteLine($"");
                Console.Write($"{playerName}, enter a coordinate to fire at (Ex.B3): ");

                rv = Console.ReadLine().ToUpper();

                //Translate the coordinate into something we can use
                // Use cases where length == 3(substring(1, 1) == 1 and substring(2, 1) == 0)
                // and length = 2
                if (rv == null)
                {
                    Sound play = new Sound();
                    play.Error();
                    Console.WriteLine("Make sure to enter a coordinate and THEN press Enter");

                }
                if (rv.Length == 3)
                {
                    if (rv[0] >= 'A' && rv[0] <= 'J' && rv[1] == '1' && rv[2] == '0')
                    {
                        break;
                    }
                    else
                    {
                        Sound play = new Sound();
                        play.Error();
                        Console.WriteLine($"{playerName}, {rv} is not a valid coordinate. Press ANY key to continue...");
                        Console.ReadKey();
                        Console.WriteLine();
                    }
                }

                else if (rv.Length == 2)
                {
                    if (rv[0] >= 'A' && rv[0] <= 'J' && rv[1] >= '1' && rv[1] <= '9')
                    {
                        break;
                    }

                    else
                    {
                        Sound play = new Sound();
                        play.Error();
                        Console.WriteLine($"{playerName}, {rv} is not a valid coordinate. Press ANY key to continue...");
                        Console.ReadKey();
                        Console.WriteLine();
                    }
                }

                else if (rv == "ENABLE NUCLEAR OPTION")
                {
                    Sound play = new Sound();
                    play.NuclearOption();

                    Console.WriteLine($"WARNING!!! This will wipe all ships in the area including your own. Press any key to fire nuke...");
                    Console.ReadKey();
                    break;
                }

                else
                {
                    Sound play = new Sound();
                    play.Error();
                    Console.WriteLine($"{playerName}, {rv} is not a valid coordinate. Press ANY key to continue...");
                    Console.ReadKey();
                    Console.WriteLine();
                }
            } while (true);
            Console.WriteLine();
            return rv;
        }


        /* The PromptForPlayerName method will prompt a user for a direction to place the ship
         * Parameters: string
         * Returns: ShipDirection
         */
        public ShipDirection PromptForDirection(string name)
        {
            //string playerDirectionInput;
            //char dirChar;

            while (true)
            {
                //Sound play = new Sound();
                //play.Prompt();
                Console.Write($"{name}, enter a direction (U - Up, D - Down, L - Left, R - Right): ");
                switch (Console.ReadLine().ToUpper())
                {
                    case "U":
                        return ShipDirection.Up;

                    case "UP":
                        return ShipDirection.Up;

                    case "D":
                        return ShipDirection.Down;

                    case "DOWN":
                        return ShipDirection.Down;

                    case "L":
                        return ShipDirection.Left;

                    case "LEFT":
                        return ShipDirection.Left;

                    case "R":
                        return ShipDirection.Right;

                    case "RIGHT":
                        return ShipDirection.Right;

                    default:
                        Sound sound = new Sound();
                        sound.Error();
                        Console.WriteLine($"{name}, that was not a valid direction...Press any key to continue.");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                }
            }
        }

        //Hilarious Idea if you input something like "Give Up" you get rick-rolled.... 
        //prompt and validation
        //TODO fix this shit.... It works but isnt validated and it's pissing me off 
  
        public string PromptforPlayAgain()
        {
            //Console.WriteLine("Do you want to play again? Y or N ");
            //string rv = Console.ReadLine().ToUpper();
            string rv;
            do
            {
                Sound play = new Sound();
                play.Prompt();
                Console.WriteLine("Do you want to play again? Y or N?");
                rv = Console.ReadLine().ToUpper();

                //if (rv != "Y" || rv != "N")
                //{
                //    Console.WriteLine("Please Enter Y or N");
                //}

                if (rv == "Y")
                {
                   // Sound sound = new Sound();
                   // sound.Prompt();
                   // Console.Write("Do you want to keep the current usernames? Y or N: ");
                   //string NewChallenger = Console.ReadLine().ToString().ToUpper();

                   // if (NewChallenger == "N")
                   // {
                   //     Application.Restart();
                   // }
                    //if (NewChallenger == "Y")
                    
                        return rv;
                    
                }
                if (rv == "N")
                {
                    return rv;
                }
            } while (rv != "Y" || rv != "N");
            return rv;

        }
    }
}