using System.Collections.Generic;
using System.Linq;


namespace SudokuSolver.Analyzers
{
    public class CompositeAnalyzer : IAnalyzer
    {
        public IAnalyzer[] Analyzers { get; private set; }
        
        public CompositeAnalyzer(IAnalyzer[] analyzers)
        {
            this.Analyzers = analyzers;
        }

        public bool Found(Board board, Position pos, int num)
        {            
            foreach (var analyzer in this.Analyzers)
            {
                if (analyzer.Found(board, pos, num))
                    return true;
            }

            return false;
        }
    }
}