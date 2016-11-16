using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;


namespace BattleShip.UI
{
    public class Game
    {
        private GameDisplay display;
        private GameInput input;
        public Sound sound;
        Player p1 = new Player();
        Player p2 = new Player();

        public Game(GameDisplay display, GameInput input, Sound sound)
        {
            this.display = display;
            this.input = input;
            this.sound = sound;
        }

        // This is the true starting point of the program.
        public void start()
        {
            sound.Intro();
            display.StartScreen();
            GetAllPlayerNames();
            SetupBoards();
            PlayGame();
            DoWePlayAgain();
            
        }
        //public void ResetBoards()
        //{
        //    Player p1Reset = new Player();
        //    Player p2Reset = new Player();

        //    p1Reset.Name = $"{p1}";
        //    p2Reset.Name = $"{p2}";

        //    SetupBoards();
        //    PlayGame();
        //    DoWePlayAgain();
        //    display.Credits();

        //}
        // This method calls the GetPlayerName method for both players
        private void GetAllPlayerNames()
        {
            p1.Name = GetPlayerName(1);
            p2.Name = GetPlayerName(2);
        }

        // This will get the player name from the user and store it in the playerNames array
        private string GetPlayerName(int playerNum)
        {
            return input.PromptForPlayerName(playerNum);
        }

        // This method will call SetupBoard for both players
        private void SetupBoards()
        {
            SetupBoard(p1);
            SetupBoard(p2);
        }

        // SetupBoard displays the board to the player
        private void SetupBoard(Player player)
        {
            // Loop through the ShipTypes to place the ships
            foreach (ShipType ship in Enum.GetValues(typeof(ShipType)))
            {
                bool shipPlaced = false;
                do
                {
                    // Show board to player
                    Console.Clear();
                    //display.DisplayBoard(player.Name, player.board);
                    display.ShipBoard(player.board);
                    
                    // Create request to place a new ship
                    PlaceShipRequest request = new PlaceShipRequest()
                    {
                        Coordinate = GetCoordinate(ship, player.Name),
                        Direction = GetDirection(player.Name),
                        ShipType = ship
                    };

                    // Try to place ship on board
                    var response = player.board.PlaceShip(request);

                    // Break out of loop if the response is OK
                    switch (response)
                    {
                        case ShipPlacement.NotEnoughSpace:
                            sound.Error();
                            Console.WriteLine($"There is not enough space for your {ship} there...Press any key to continue");
                            Console.ReadKey();
                            break;

                        case ShipPlacement.Overlap:
                            sound.Error();
                            Console.WriteLine($"That coordinate overlaps with an existing ship...Press any key to continue");
                            Console.ReadKey();
                            break;

                        default:
                            shipPlaced = true;
                            break;
                    }
                } while (!shipPlaced);
            }
            Console.Clear();
            display.ShipBoard(player.board);
            Console.WriteLine($"{player.Name} you have finished placing all of the ships...Press any key to continue");
            Console.ReadKey();
        }

        private int GetShipLength(ShipType ship)
        {
            switch (ship)
            {
                case ShipType.Carrier:
                    return 5;

                case ShipType.Battleship:
                    return 4;

                case ShipType.Submarine:
                    return 3;

                case ShipType.Cruiser:
                    return 3;

                default:
                    return 2;
            }
                 
        }

        private Coordinate GetCoordinate(ShipType ship, string name)
        {
            // Return an int for the ship length
            int length = GetShipLength(ship);

            // Prompt the user for a Coordinate and validate it
            string userCoordinate = input.PromptForCoordinate(name, ship, length).ToUpper();

            // Split the coordinate into X and Y strings
            int userX = TranslateXCoordinate(userCoordinate[0]);
            int userY = int.Parse(userCoordinate.Substring(1));

            Coordinate coordinate = new Coordinate(userX, userY);
            return coordinate;
        }

        private Coordinate GetCoordinate(string name)
        {
            // Prompt the user for a Coordinate and validate it
            string userCoordinate = input.PromptForCoordinate(name).ToUpper();
            if (userCoordinate == "ENABLE NUCLEAR OPTION")
            {
                
                display.AlternateEndingPage(name);
                return null;
            }
    
            // Split the coordinate into X and Y strings
            int userX = TranslateXCoordinate(userCoordinate[0]);
            int userY = int.Parse(userCoordinate.Substring(1));

            Coordinate coordinate = new Coordinate(userX, userY);
            return coordinate;
        }

        // Take in a player name and return a ShipDirection
        private ShipDirection GetDirection(string name)
        {
            return input.PromptForDirection(name);
        }
        
        private void PlayGame()
        {
            // Call PlayerTurn and alternate players
            
            int turnCount = 0;
            ShotStatus status = new ShotStatus();
            do
            {
                if (turnCount % 2 == 0)
                {
                    status = PlayerTurn(p1.Name, p2.board);
                    turnCount++;
                }
                else if (turnCount % 2 == 1)
                {
                    status = PlayerTurn(p2.Name, p1.board);
                    turnCount++;
                }
            } while (status != ShotStatus.Victory);
            Console.ReadLine();
            
        }

        private ShotStatus PlayerTurn(String name, Board board)
        {
            ShotStatus status = new ShotStatus();
            bool EndTurn = false;
            do
            {
                Console.Clear();
                display.DisplayBoard(name, board);
                // Get coordinate from user 
                var coordinate = GetCoordinate(name);

                if (coordinate == null)
                {
                    return ShotStatus.Victory;
                }

                var response = board.FireShot(coordinate);

                switch (response.ShotStatus)
                {
                    case ShotStatus.Duplicate:
                        sound.Error();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"That coordinate has already been tried...Press any key to continue.");
                        Console.ResetColor();
                        Console.ReadKey();
                        status = response.ShotStatus;
                        break;

                    case ShotStatus.Invalid:
                        sound.Error();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"That coordinate is invalid...Press any key to continue.");
                        Console.ResetColor();
                        Console.ReadKey();
                        status = response.ShotStatus;
                        break;

                    case ShotStatus.Miss:

                        sound.FireMiss();
                        Console.Clear();
                        display.DisplayBoard(name, board);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Your shot MISSED...Press any key to continue");
                        Console.ResetColor();
                        Console.ReadKey();
                        status = response.ShotStatus;
                        EndTurn = true;
                        break;

                    case ShotStatus.Hit:
                        sound.FireHit();
                        Console.Clear();
                        display.DisplayBoard(name, board);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Your shot is a HIT...Press any key to continue");
                        Console.ResetColor();
                        Console.ReadKey();
                        status = response.ShotStatus;
                        EndTurn = true;
                        break;

                    case ShotStatus.HitAndSunk:
                        sound.FireHitandSink();
                        Console.Clear();
                        display.DisplayBoard(name, board);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"You hit and sunk a ship...Press any key to continue");
                        Console.ResetColor();
                        Console.ReadKey();
                        status = response.ShotStatus;
                        EndTurn = true;
                        break; 

                    case ShotStatus.Victory:
                    default:    // Victory case
                        sound.Victory();
                        Console.Clear();
                        display.DisplayBoard(name, board);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"CONGRATULATIONS {name.ToUpper()}, YOU HAVE WON THE GAME!!!!!!!!");
                        Console.WriteLine($"Press any key to continue...");
                        Console.ResetColor();
                        Console.ReadKey();
                        status = response.ShotStatus;
                        EndTurn = true;
                        break;
                }
            } while (!EndTurn);
            return status;
        }

        public void DoWePlayAgain()
        {
            string rv; 
            rv = input.PromptforPlayAgain();
           
            if(rv == "Y")
            {
                Application.Restart();
            }
            else if(rv == "N")
            {
                Console.Clear();
                display.Credits();
            }
            
        }

        // Convert a string coordinate from the user into a [x,y] positiony
        // Example: "B5" --> {2,5} on the board
        private int TranslateXCoordinate(char inputChar)
        {
            // Split the String into 1st character then the rest of the string
            // Use dictionary to translate the first character into a number
            // Parse the second part of the string to a number
            Dictionary<char, int> translator = new Dictionary<char, int>
            {
                {'A', 1 },
                {'B', 2 },
                {'C', 3 },
                {'D', 4 },
                {'E', 5 },
                {'F', 6 },
                {'G', 7 },
                {'H', 8 },
                {'I', 9 },
                {'J', 10 }
            };

            return translator[inputChar];
        }
    }
}
