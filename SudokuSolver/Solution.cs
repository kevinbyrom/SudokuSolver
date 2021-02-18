using System;
using System.Text;

namespace SudokuSolver
{
    public struct Solution
    {
        public int Passes;
        public Board Board;

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(String.Format("Passes: {0}", this.Passes));
            builder.AppendLine(this.Board.ToString());

            return builder.ToString();
        }
    }
}