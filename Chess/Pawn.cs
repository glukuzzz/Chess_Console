using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Pawn : AObject
    {
        public Pawn(ConsoleColor color) : base(color)
        {
            this.Symbol = 'P';
        }

        public override List<Way> Move(Coordinate coor, Dictionary<Coordinate, AObject> database)
        {
            List<Way> way = new List<Way>();
            ICollection<Coordinate> keys = database.Keys;

            if (this.color == ConsoleColor.Yellow)
            {
                if (coor.Y == 8 && keys.Contains(coor + new Coordinate(0, -2)) == false && keys.Contains(coor + new Coordinate(0, -1)) == false) { way.Add(new Way(coor, coor + new Coordinate(0, -2), 0)); }
                if (keys.Contains(coor + new Coordinate(0, -1)) == false) { way.Add(new Way(coor, coor + new Coordinate(0, -1), 0)); }
                if (keys.Contains(coor + new Coordinate(1, -1)) == true && database[coor + new Coordinate(1, -1)].color == ConsoleColor.DarkGreen) { way.Add(new Way(coor, coor + new Coordinate(1, -1), 1)); }
                if (keys.Contains(coor + new Coordinate(-1, -1)) == true && database[coor + new Coordinate(-1, -1)].color == ConsoleColor.DarkGreen) { way.Add(new Way(coor, coor + new Coordinate(-1, -1), 1)); }
            }

            if (this.color == ConsoleColor.DarkGreen)
            {
                if (coor.Y == 3 && keys.Contains(coor + new Coordinate(0, 2)) == false && keys.Contains(coor + new Coordinate(0, 1))== false) { way.Add(new Way(coor, coor + new Coordinate(0, 2), 0)); }
                if (keys.Contains(coor + new Coordinate(0, 1)) == false) { way.Add(new Way(coor, coor + new Coordinate(0, 1), 0)); }
                if (keys.Contains(coor + new Coordinate(1,1)) == true && database[coor + new Coordinate(1, 1)].color == ConsoleColor.Yellow) { way.Add(new Way(coor, coor + new Coordinate(1, 1), 1)); }
                if (keys.Contains(coor + new Coordinate(-1, 1)) == true && database[coor + new Coordinate(-1, 1)].color == ConsoleColor.Yellow) { way.Add(new Way(coor, coor + new Coordinate(-1, 1), 1)); }
            }
            
            return way;
        }
    }
}
