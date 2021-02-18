using System.Collections.Generic;
using System.Linq;


namespace SudokuSolver.Analyzers
{
    public class TakenInGridAnalyzer : IAnalyzer
    {

        public bool Found(Board board, Position pos, int num)
        {
            
            // Get taken values for the other cells

            var others = board.GetGrid(pos).Where(c => c.HasFinal && c.Final == num);

            return others.Count() > 0;
        }
    }
}