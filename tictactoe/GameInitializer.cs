namespace TicTacToe
{
    /// <summary>
    /// Provides methods to initialize the game board.
    /// </summary>
    internal static class GameInitializer
    {
        /// <summary>
        /// Initializes the game board grid with empty cells.
        /// </summary>
        /// <returns>A list of empty cells representing the game board grid.</returns>
        public static List<Cell> InitializeGrid()
        {
            return new List<Cell>
            {
                Cell.EmptyCell(1, 1),
                Cell.EmptyCell(1, 2),
                Cell.EmptyCell(1, 3),
                Cell.EmptyCell(2, 1),
                Cell.EmptyCell(2, 2),
                Cell.EmptyCell(2, 3),
                Cell.EmptyCell(3, 1),
                Cell.EmptyCell(3, 2),
                Cell.EmptyCell(3, 3),
            };
        }
    }
}
