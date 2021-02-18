using System;

namespace SudokuSolver
{
    public struct Position 
    {
        public static Position Zero = new Position(0, 0);

        public int X;
        public int Y;


        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }


        public override bool Equals(object obj) 
        {
            if (!(obj is Position))
                return false;

            Position pos = (Position)obj;
            return pos.X == this.X && pos.Y == this.Y;
        }


        public override int GetHashCode()
        {
            return String.Format("{0}-{1}", this.X, this.Y).GetHashCode();
        }


        public static bool operator!= (Position a, Position b) 
        {
            return !a.Equals(b);
        }


        public static bool operator== (Position a, Position b) 
        {
            return a.Equals(b);
        }

        public static Position At(int x, int y)
        {
            return new Position(x, y);
        }
    }
}