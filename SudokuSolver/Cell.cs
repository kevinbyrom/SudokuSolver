using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace SudokuSolver
{
    public struct Cell : ICloneable
    {
        public static int[] AllValues = { 1, 2, 3, 4, 5, 6, 7, 8, 9};

        public Position Position;

        private ISet<int> possible;

        public int[] Possible
        {
            get
            {
                return this.possible.ToArray();
            }
        }

        public int Final 
        {
            get
            {
                if (!this.HasFinal)
                    throw new InvalidOperationException();
                    
                return this.possible.First();
            }
            set
            {
                this.possible = new HashSet<int>(new int[]{ value });
            }
        }

        public bool HasFinal
        {
            get
            {
                return this.possible.Count() == 1;
            }
        }
        
        public Cell(Position pos)
        {
            this.Position = pos;
            this.possible = new HashSet<int>(AllValues);
        }

        public void RemovePossible(int val)
        {
            if (this.possible.Contains(val))
                this.possible.Remove(val);
        }

        public override string ToString()
        {
            if (this.HasFinal)
                return this.Final.ToString();
            else    
                return "?";
        }

        public object Clone()
        {
            var cell = new Cell(this.Position);
            cell.possible = new HashSet<int>(this.Possible);

            return cell;
        }
    }
}