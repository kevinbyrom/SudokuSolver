using System;
using System.Collections.Generic;
using System.Text;


namespace SudokuSolver
{
    public class Board 
    {
        public static int GridWidth = 3;
        public static int GridHeight = 3;
        public static int NumGridsX = 3;
        public static int NumGridsY = 3;
        public static int Width = GridWidth * NumGridsX;
        public static int Height = GridHeight * NumGridsY;

        public Cell[,] Cells;

        public Board()
        {
            this.Cells = new Cell[Width, Height];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    this.Cells[x, y] = new Cell(new Position(x, y));
                }
            }
        }

        public Cell[] GetGrid(Position pos)
        {
            int offsetX = (pos.X / GridWidth) * GridWidth; 
            int offsetY = (pos.Y / GridHeight) * GridHeight;

            var cells = new List<Cell>();

            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    cells.Add(this.Cells[offsetX + x, offsetY + y]);
                }
            }
            
            return cells.ToArray();   
        }


        public Cell[] GetRow(Position pos)
        {
            var cells = new List<Cell>();

            for (int x = 0; x < Width; x++)
            {
                cells.Add(this.Cells[x, pos.Y]);
            }

            return cells.ToArray();
        }


        public Cell[] GetColumn(Position pos)
        {
            var cells = new List<Cell>();

            for (int y = 0; y < Height; y++)
            {
                cells.Add(this.Cells[pos.X, y]);
            }

            return cells.ToArray();
        }
    
        public bool IsSolved()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (!this.Cells[x, y].HasFinal)
                        return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            for (int y = 0; y < Board.Height; y++)
            {
                for (int x = 0; x < Board.Width; x++)
                {
                    if (this.Cells[x, y].HasFinal)
                        builder.Append(this.Cells[x, y].Final.ToString());
                    else    
                        builder.Append("?");
                }
                builder.AppendLine("");
            }

            return builder.ToString();
        }

        public static Board FromArray(int[] cells)
        {
            Board board = new Board();
            
            for (int y = 0; y < Board.Height; y++)
            {
                for (int x = 0; x < Board.Width; x++)
                {
                    int val = cells[x + (y * Board.Width)];
                    
                    if (val != 0)
                        board.Cells[x, y].Final = val;
                }
            }

            return board;
        }
    }
}