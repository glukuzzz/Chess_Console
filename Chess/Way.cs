using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Way
    {
        public Coordinate coor1 { get; private set; }
        public Coordinate coor2 { get; private set; }

        public int eat { get; private set; }

        public Way(Coordinate start, Coordinate finish, int eat)
        {
            coor1 = start;
            coor2 = finish;
            this.eat = eat;
        }
    }
}
