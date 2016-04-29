using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Bishop : AObject
    {
        public Bishop(ConsoleColor color) : base(color)
        {
            this.Symbol = 'B';
        }

        public override List<Way> Move(Coordinate coor, Dictionary<Coordinate, AObject> database)
        {
            ConsoleColor color2;
            if (this.color == ConsoleColor.Yellow) color2 = ConsoleColor.DarkGreen;
            else color2 = ConsoleColor.Yellow;
            List<Way> way = new List<Way>();
            ICollection<Coordinate> keys = database.Keys;
            Coordinate[] wayCoor = new Coordinate[]
            {
                new Coordinate(1,1),
               
                new Coordinate(1,-1),
                
               
                new Coordinate(-1,1),
                
                new Coordinate(-1,-1)
            };

            for (int i = 1; ; ++i)
            {
                if (keys.Contains(coor + wayCoor[0] * i) == false) { way.Add(new Way(coor, coor + wayCoor[0] * i, 0)); }
                if (keys.Contains(coor + wayCoor[0] * i) == true && database[coor + wayCoor[0] * i].color == color2) { way.Add(new Way(coor, coor + wayCoor[0] * i, 1)); break; }
                if (keys.Contains(coor + wayCoor[0] * i) == true && database[coor + wayCoor[0] * i].color != color2) { break; }
            }
            for (int i = 1; ; ++i)
            {
                if (keys.Contains(coor + wayCoor[1] * i) == false) { way.Add(new Way(coor, coor + wayCoor[1] * i, 0)); }
                if (keys.Contains(coor + wayCoor[1] * i) == true && database[coor + wayCoor[1] * i].color == color2) { way.Add(new Way(coor, coor + wayCoor[1] * i, 1)); break; }
                if (keys.Contains(coor + wayCoor[1] * i) == true && database[coor + wayCoor[1] * i].color != color2) { break; }
            }
            for (int i = 1; ; ++i)
            {
                if (keys.Contains(coor + wayCoor[2] * i) == false) { way.Add(new Way(coor, coor + wayCoor[2] * i, 0)); }
                if (keys.Contains(coor + wayCoor[2] * i) == true && database[coor + wayCoor[2] * i].color == color2) { way.Add(new Way(coor, coor + wayCoor[2] * i, 1)); break; }
                if (keys.Contains(coor + wayCoor[2] * i) == true && database[coor + wayCoor[2] * i].color != color2) { break; }
            }
            for (int i = 1; ; ++i)
            {
                if (keys.Contains(coor + wayCoor[3] * i) == false) { way.Add(new Way(coor, coor + wayCoor[3] * i, 0)); }
                if (keys.Contains(coor + wayCoor[3] * i) == true && database[coor + wayCoor[3] * i].color == color2) { way.Add(new Way(coor, coor + wayCoor[3] * i, 1)); break; }
                if (keys.Contains(coor + wayCoor[3] * i) == true && database[coor + wayCoor[3] * i].color != color2) { break; }
            }
            

            return way;
        }
    }
}
