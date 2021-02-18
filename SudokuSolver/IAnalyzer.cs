namespace SudokuSolver
{
    public interface IAnalyzer
    {
        bool Found(Board board, Position pos, int num);
    }
}