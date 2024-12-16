namespace TicTacToe
{
    /// <summary>
    /// Provides methods to check the state of the game board.
    /// </summary>
    internal static class GameStateChecker
    {
        /// <summary>
        /// Determines whether the game board has a winning condition.
        /// </summary>
        /// <param name="grid">The game board grid.</param>
        /// <param name="playerOne">The first player.</param>
        /// <param name="playerTwo">The second player.</param>
        /// <returns><c>true</c> if there is a winning condition; otherwise, <c>false</c>.</returns>
        public static bool IsGameBoardWin(List<Cell> grid, IPlayer playerOne, IPlayer playerTwo)
        {
            IEnumerable<IGrouping<int, Cell>> rows = grid.GroupBy(cell => cell.Row);

            if (rows.Any(row =>
                row.All(cell => cell.Value == playerOne.Symbol) ||
                row.All(cell => cell.Value == playerTwo.Symbol)))
            {
                return true;
            }

            IEnumerable<IGrouping<int, Cell>> columns = grid.GroupBy(cell => cell.Column);

            if (columns.Any(column =>
                column.All(cell => cell.Value == playerOne.Symbol) ||
                column.All(cell => cell.Value == playerTwo.Symbol)))
            {
                return true;
            }

            IEnumerable<Cell> firstDiagonal = grid.Where(c => c.Row == c.Column);
            IEnumerable<Cell> secondDiagonal = grid.Where(c => (c.Row + c.Column) == 4);

            var diagonals = new List<IEnumerable<Cell>>
            {
                firstDiagonal,
                secondDiagonal
            };

            if (diagonals.Any(diagonal =>
                diagonal.All(cell => cell.Value == playerOne.Symbol) ||
                diagonal.All(cell => cell.Value == playerTwo.Symbol)))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether the game board is full.
        /// </summary>
        /// <param name="grid">The game board grid.</param>
        /// <returns><c>true</c> if the game board is full; otherwise, <c>false</c>.</returns>
        public static bool IsGameBoardFull(List<Cell> grid)
            => grid.All(cell => cell.Value.HasValue);

        /// <summary>
        /// Checks if the game has ended either by a win or a draw.
        /// </summary>
        /// <param name="grid">The game board grid.</param>
        /// <param name="currentPlayer">The current player.</param>
        /// <param name="playerOne">The first player.</param>
        /// <param name="playerTwo">The second player.</param>
        /// <returns><c>true</c> if the game has ended; otherwise, <c>false</c>.</returns>
        public static bool CheckGameEnd(List<Cell> grid, IPlayer currentPlayer, IPlayer playerOne, IPlayer playerTwo)
        {
            if (IsGameBoardWin(grid, playerOne, playerTwo))
            {
                Console.WriteLine($"{currentPlayer.Name} has won the game !!!!");
                return true;
            }
            if (IsGameBoardFull(grid))
            {
                Console.WriteLine("It's a draw");
                return true;
            }
            return false;
        }
    }
}
