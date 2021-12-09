using System;

namespace OzowGameOfLife
{
    public class Cell
    {
        public Cell()
        {

        }

        public Cell(int x, int y, bool isAlive)
        {
            X = x;
            Y = y;
            IsAlive = isAlive;
        }

        //Constructor randomizes isAlive bool
        public Cell(int x, int y)
        {
            X = x;
            Y = y;

            Random random = new Random();
            int flip = random.Next(2);
            IsAlive = flip == 1;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public bool IsAlive { get; set; }
    }
}
