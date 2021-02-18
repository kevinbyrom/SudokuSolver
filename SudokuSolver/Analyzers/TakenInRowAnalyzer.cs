using System.Collections.Generic;
using System.Linq;


namespace SudokuSolver.Analyzers
{
    public class TakenInRowAnalyzer : IAnalyzer 
    {
        public bool Found(Board board, Position pos, int num)
        {
            
            // Get taken values for the other cells

            var others = board.GetRow(pos).Where(c => c.HasFinal && c.Final == num);

            return others.Count() > 0;
        }
    }
}