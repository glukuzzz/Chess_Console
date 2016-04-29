using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Wall : AObject
    {
        
        public Wall(ConsoleColor color) : base (color)
        {
            Symbol = 'W';
        }

        public override List<Way> Move(Coordinate coor, Dictionary<Coordinate, AObject> database)
        {
            List<Way> way = new List<Way>();
            return way;
        }
    }
}
