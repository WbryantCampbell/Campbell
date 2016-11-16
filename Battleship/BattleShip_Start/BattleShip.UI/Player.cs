using BattleShip.BLL.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class Player
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public Board board = new Board();
        char[,] shipBoard = new char[10,10];
    }
}

