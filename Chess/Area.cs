using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Chess
{
    class Area
    {
        Dictionary<Coordinate, AObject> database = new Dictionary<Coordinate, AObject>();
        List<Way> ways = new List<Way>();

        public void Init()
        {

            int[] j = new int[] { 0, 1, 10, 11 };
            foreach (int y in j)
            {
                for (int i = 0; i < 12; ++i)
                {
                    Coordinate coor = new Coordinate(i, y);

                    Wall wall = new Wall(ConsoleColor.Red);
                    database.Add(coor, wall);
                }
            }
            int[] j1 = new int[] { 0, 1, 10, 11 };
            foreach (int x in j1)
            {
                for (int i = 2; i < 10; ++i)
                {
                    Coordinate coor = new Coordinate(x, i);

                    Wall wall = new Wall(ConsoleColor.Red);
                    database.Add(coor, wall);
                }
            }
            
            for (int i = 2; i<10; ++i)
            {
                Coordinate coor = new Coordinate(i, 3);
                Pawn pawn = new Pawn(ConsoleColor.DarkGreen);
                database.Add(coor, pawn);
            }

            for (int i = 2; i < 10; ++i)
            {
                Coordinate coor = new Coordinate(i, 8);
                Pawn pawn = new Pawn(ConsoleColor.Yellow);
                database.Add(coor, pawn);
            }
            
            database.Add(new Coordinate(5, 9), new Queen(ConsoleColor.Yellow));
            database.Add(new Coordinate(5, 2), new Queen(ConsoleColor.DarkGreen));
            database.Add(new Coordinate(6, 9), new King(ConsoleColor.Yellow));
            database.Add(new Coordinate(6, 2), new King(ConsoleColor.DarkGreen));
            database.Add(new Coordinate(9, 9), new Rook(ConsoleColor.Yellow));
            database.Add(new Coordinate(2, 2), new Rook(ConsoleColor.DarkGreen));
            database.Add(new Coordinate(2, 9), new Rook(ConsoleColor.Yellow));
            database.Add(new Coordinate(9, 2), new Rook(ConsoleColor.DarkGreen));
            database.Add(new Coordinate(7, 9), new Bishop(ConsoleColor.Yellow));
            database.Add(new Coordinate(4, 2), new Bishop(ConsoleColor.DarkGreen));
            database.Add(new Coordinate(4, 9), new Bishop(ConsoleColor.Yellow));
            database.Add(new Coordinate(7, 2), new Bishop(ConsoleColor.DarkGreen));
            database.Add(new Coordinate(8, 9), new Knight(ConsoleColor.Yellow));
            database.Add(new Coordinate(3, 2), new Knight(ConsoleColor.DarkGreen));
            database.Add(new Coordinate(3, 9), new Knight(ConsoleColor.Yellow));
            database.Add(new Coordinate(8, 2), new Knight(ConsoleColor.DarkGreen));



            ICollection<Coordinate> keys = database.Keys;
            foreach(Coordinate coor in keys)
            {
               
                database[coor].Draw(coor, database[coor].color);
            }
            
        }

        public void Go()
        {
            int i = 0;
            while (true)
            {
                Move(ConsoleColor.Yellow);
                Console.ReadKey();
                Move(ConsoleColor.DarkGreen);
                Console.ReadKey();
                ++i;
                if(i == 1)
                {
                    i = 0;
                    Console.Clear();
                    ICollection<Coordinate> keys = database.Keys;
                    foreach (Coordinate coor in keys)
                    {
                        database[coor].Draw(coor, database[coor].color);
                    }
                }
            }
        }

        public void Move(ConsoleColor color) 
        {
           

            ICollection<Coordinate> keys = database.Keys;
            foreach (Coordinate coor in keys)
            {
                if (database[coor].color == color)
                {
                    ways.AddRange(database[coor].Move(coor, database));
                }
            }
           
            for (int i = 0; ; ++i)
            {
                try
                {
                    if (ways[i].eat == 1)
                    {
                        Way way1 = ways[i];
                        ways.Clear();
                        ways.Add(way1);
                        break;
                    }
                }

                catch
                {
                    break;
                }
                                    
            }
            
            if (ways.Count == 0)

            {
                Thread.Sleep(3000);
                Environment.Exit(0);
            }


            int waysCount = ways.Count();
            int chooseWay = MyRandom.GenerateRandom(0, waysCount - 1);
            if (ways[chooseWay].eat == 1)
            {
                database[ways[chooseWay].coor2].UnDraw(ways[chooseWay].coor2);
                database.Remove(ways[chooseWay].coor2);

                database.Add(ways[chooseWay].coor2, database[ways[chooseWay].coor1]);
                database[ways[chooseWay].coor2].Draw(ways[chooseWay].coor2, color);
                database[ways[chooseWay].coor2].UnDraw(ways[chooseWay].coor1);
                database.Remove(ways[chooseWay].coor1);

            }
            else
            {
                database.Add(ways[chooseWay].coor2, database[ways[chooseWay].coor1]);
                database[ways[chooseWay].coor2].Draw(ways[chooseWay].coor2, color);
                database[ways[chooseWay].coor2].UnDraw(ways[chooseWay].coor1);
                database.Remove(ways[chooseWay].coor1);
            }

            ways.Clear();
            int z=0;
            foreach (Coordinate key in keys)
            {
                if (database[key].GetType() == typeof(King)) z++;
            }
            if (z<2)
            {
                Console.Clear();
                Console.WriteLine("Somebody ate King, press key to finish game!");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

    }
}
