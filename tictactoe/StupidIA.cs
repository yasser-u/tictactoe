namespace TicTacToe
{
    /// <summary>
    /// Represents a simple AI player in the Tic Tac Toe game.
    /// </summary>
    internal class StupidIA : IPlayer
    {
        /// <summary>
        /// Gets the symbol of the player.
        /// </summary>
        public char Symbol { get; }

        /// <summary>
        /// Gets the name of the player.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StupidIA"/> class.
        /// </summary>
        /// <param name="symbol">The symbol representing the player.</param>
        /// <param name="name">The name of the player.</param>
        public StupidIA(char symbol, string name = "StupidIA")
        {
            Symbol = symbol;
            Name = name;
        }

        /// <summary>
        /// Gets the next move for the AI player.
        /// </summary>
        /// <param name="grid">The game board grid.</param>
        /// <param name="targetRow">The target row for the next move.</param>
        /// <param name="targetColumn">The target column for the next move.</param>
        /// <returns><c>true</c> if a valid move is found; otherwise, <c>false</c>.</returns>
        public bool GetNextMove(List<Cell> grid, out int targetRow, out int targetColumn)
        {
            targetRow = 0;
            targetColumn = 0;

            foreach (var cell in grid)
            {
                if (!cell.Value.HasValue)
                {
                    targetRow = cell.Row;
                    targetColumn = cell.Column;
                    return true;
                }
            }

            return false;
        }
    }
}
