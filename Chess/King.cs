using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class King : AObject
    {
        public King(ConsoleColor color) : base(color)
        {
            this.Symbol = 'K';
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
                new Coordinate(1,0),
                new Coordinate(1,-1),
                new Coordinate(0,1),
                new Coordinate(0,-1),
                new Coordinate(-1,1),
                new Coordinate(-1,0),
                new Coordinate(-1,-1)
            };
            
            
                foreach (Coordinate a in wayCoor)
                { 
                
                    if (keys.Contains(coor + a) == false) { way.Add(new Way(coor, coor + a, 0)); }
                    if (keys.Contains(coor + a) == true && database[coor + a ].color == color2) { way.Add(new Way(coor, coor + a, 1));   }
                    
                }
         

            return way;
        }
    }
}
