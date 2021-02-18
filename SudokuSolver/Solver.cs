using System;
using System.Collections.Generic;
using SudokuSolver.Analyzers;


namespace SudokuSolver
{
    public class Solver
    {
        public IAnalyzer Analyzer { get; set; }

        public Solver()
        {
            this.Analyzer = new CompositeAnalyzer(new IAnalyzer[] { new TakenInColumnAnalyzer(), new TakenInRowAnalyzer(), new TakenInGridAnalyzer() });
        }

        public Solution Solve(Board board)
        {
            int passes = 0;

            /* 
            Approach: 
            - Iterate through each cell which isnt already complete
            - Remove values which are no longer possible for the cell
            - Continue until board is complete
             */ 

            while (!board.IsSolved())
            {
                for (int y = 0; y < Board.Height; y++)
                {
                    for (int x = 0; x < Board.Width; x++)
                    {
                        if (!board.Cells[x, y].HasFinal)
                        {   
                            foreach (var possible in board.Cells[x, y].Possible)
                            {
                                if (this.Analyzer.Found(board, new Position(x, y), possible))
                                    board.Cells[x, y].RemovePossible(possible);
                            }
                        }
                    }
                }

                Console.WriteLine("Pass: {0}", passes);
                Console.WriteLine(board);
                Console.WriteLine("------------------------");

                passes++;
            }
            
            return new Solution() { Passes = passes, Board = board };
        }
    }
}