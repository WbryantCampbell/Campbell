using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using System.Media;

namespace BattleShip.UI
{
    public class GameDisplay
    {
        public Sound sound;
        /* The DisplayBoard method will display the game board to the user.
         * Parameters: string, Board
         * Returns: Nothing
         */
        public void DisplayBoard(string name, Board board)
        {
            Console.Clear();
            Console.WriteLine($"{name}'s Game Board");
            Console.WriteLine();
            //Console.WriteLine($"╔═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╗");
            //Console.WriteLine($"║   ║ 1 ║ 2 ║ 3 ║ 4 ║ 5 ║ 6 ║ 7 ║ 8 ║ 9 ║ 10║ ");
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine($"║ {(char)('A'+i)} ║   ║   ║   ║   ║   ║   ║   ║   ║   ║   ║ ");
            //    if(i != 9)
            //    {
            //        Console.WriteLine($"╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            //    }

            //}
            //Console.WriteLine($"╚═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╝");
            Console.WriteLine("  1  2  3  4  5  6  7  8  9  10");

            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"{(char)('A' + i- 1)}");
                for (int j = 1; j <= 10; j++)
                {   
                    Coordinate coor = new Coordinate(i, j);
                    if (board.ShotHistory.ContainsKey(coor))
                    {
                        ShotHistory history = board.ShotHistory[coor];

                        switch (history)
                        {
                            case ShotHistory.Hit:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(" H ");
                                Console.ResetColor();
                                break;

                            case ShotHistory.Miss:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" M ");
                                Console.ResetColor();
                                break;
                        }
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void Credits()
        {
            Console.Clear();
            Sound play = new Sound();
            play.Victory();
            Console.WriteLine(@"
_________          _______    _______  _        ______  
\__   __/|\     /|(  ____ \  (  ____ \( (    /|(  __  \ 
   ) (   | )   ( || (    \/  | (    \/|  \  ( || (  \  )
   | |   | (___) || (__      | (__    |   \ | || |   ) |
   | |   |  ___  ||  __)     |  __)   | (\ \) || |   | |
   | |   | (   ) || (        | (      | | \   || |   ) |
   | |   | )   ( || (____/\  | (____/\| )  \  || (__/  )
   )_(   |/     \|(_______/  (_______/|/    )_)(______/ 

Programmer..............Bryant Campbell
Programmer..............Zachary Mehl
Executive Producer......Victor Pudelski
Art.....................ascii-code.com");
            Console.WriteLine();
            Console.WriteLine("Press any key to Continue");
            Console.ReadLine();
            
        }

        public void StartScreen()
        {
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Bryant and Zach\'s");
            Console.WriteLine(@"
 ______   _______ __________________ _        _______  _______          _________ _______ 
(  ___ \ (  ___  )\__   __/\__   __/( \      (  ____ \(  ____ \|\     /|\__   __/(  ____ )
| (   ) )| (   ) |   ) (      ) (   | (      | (    \/| (    \/| )   ( |   ) (   | (    )|
| (__/ / | (___) |   | |      | |   | |      | (__    | (_____ | (___) |   | |   | (____)|
|  __ (  |  ___  |   | |      | |   | |      |  __)   (_____  )|  ___  |   | |   |  _____)
| (  \ \ | (   ) |   | |      | |   | |      | (            ) || (   ) |   | |   | (      
| )___) )| )   ( |   | |      | |   | (____/\| (____/\/\____) || )   ( |___) (___| )      
|/ \___/ |/     \|   )_(      )_(   (_______/(_______/\_______)|/     \|\_______/|/       
                                                                                          ");
            Console.WriteLine();
            Console.WriteLine(@"
                                     | __
                                     |\/
                                     ---
                                     / | [
                              !      | |||
                            _/|     _/|-++'
                        +  +--|    |--|--|_ |-
                     { /|__|  |/\__|  |--- |||__/
                    +---------------___[}-_===_.'____                 /\
                ____`-' ||___-{]_| _[}-  |     |_[___\==--            \/   _
 __..._____--==/___]_|__|_____________________________[___\==--____,------' .7
|                                                                     BB-61/
 \_________________________________________________________________________|");

            Console.WriteLine();
            Console.WriteLine($"Press enter to start....");
            Console.ReadLine();
            Console.ResetColor();
        }

        public void ShipBoard(Board GameBoard)
        {
            char[,] shipBoard = new char[10, 10];
            for (int i = 0; i < GameBoard.Ships.Length; i++)
            {
                if (GameBoard.Ships[i] != null)
                {
                    foreach (var ship in GameBoard.Ships[i].BoardPositions)
                    {
                        switch (GameBoard.Ships[i].ShipType)
                        {
                            case BLL.Ships.ShipType.Battleship:
                                shipBoard[ship.XCoordinate - 1, ship.YCoordinate - 1] = 'B';
                                break;

                            case BLL.Ships.ShipType.Carrier:
                                shipBoard[ship.XCoordinate - 1, ship.YCoordinate - 1] = 'C';
                                break;

                            case BLL.Ships.ShipType.Cruiser:
                                shipBoard[ship.XCoordinate - 1, ship.YCoordinate - 1] = 'C';
                                break;

                            case BLL.Ships.ShipType.Destroyer:
                                shipBoard[ship.XCoordinate - 1, ship.YCoordinate - 1] = 'D';
                                break;

                            case BLL.Ships.ShipType.Submarine:
                                shipBoard[ship.XCoordinate - 1, ship.YCoordinate - 1] = 'S';
                                break;
                        }

                        //shipBoard[ship.XCoordinate - 1, ship.YCoordinate - 1] = 'S';
                    }
                }
            }
            //Console.WriteLine($"╔═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╗");
            //Console.WriteLine($"║   ║ 1 ║ 2 ║ 3 ║ 4 ║ 5 ║ 6 ║ 7 ║ 8 ║ 9 ║ 10║ ");
            //Console.WriteLine($"╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine("    1  2  3  4  5  6  7  8  9  10");

            for (int i = 0; i < 10; i++)
            {
                //Console.Write($"\n║ {(char)('A' + i)} ║");
                Console.Write($"\n {(char)('A' + i)} ");

                for (int j = 0; j < 10; j++)
                {
                    //Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    //Console.Write($" {shipBoard[i, j]} ║");
                    Console.Write($" {shipBoard[i, j]} ");
                    Console.Write($"");
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
            //Console.WriteLine($"╚═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╝");
        }

        public void AlternateEndingPage(string name)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{name}, you have won, but at what cost?????");
            Console.WriteLine(@"
     _.-^^---....,,--       
 _--                  --_  
<                        >)
|                         | 
 \._                   _./  
    ```--. . , ; .--'''       
          | |   |             
       .-=||  | |=-.   
       `-=#$%&%$#=-'   
          | ;  :|     
 _____.,-#%&$@%#&#~,._____
            ");
            Console.WriteLine($"Press any key to continue...");
            Console.ResetColor();
        }

    }
}
