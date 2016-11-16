using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game(new GameDisplay(), new GameInput(), new Sound());
            game.start(); 
        }
    }
}
