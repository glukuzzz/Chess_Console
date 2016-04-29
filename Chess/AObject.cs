using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    abstract class AObject
    {
        protected char Symbol { get; set; }

       

        public ConsoleColor color { get; set; }

        public AObject(ConsoleColor color)
        {
            this.color = color;
        }

        public abstract List<Way> Move(Coordinate coor, Dictionary<Coordinate, AObject> database);
        
        public void Draw(Coordinate coor, ConsoleColor color)
        {
            Console.SetCursorPosition(coor.X, coor.Y);
            Console.ForegroundColor = color;
            Console.Write(this.Symbol);
            Console.ResetColor();
        }

        public  void UnDraw(Coordinate coor)
        {
            Console.SetCursorPosition(coor.X, coor.Y);
            Console.Write(' ');
        }
    }
}
