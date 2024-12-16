namespace TicTacToe
{
    /// <summary>
    /// Handles user input for the Tic Tac Toe game.
    /// </summary>
    internal static class UserInputHandler
    {
        /// <summary>
        /// Tries to get the user input for the next move.
        /// </summary>
        /// <param name="currentPlayer">The current player.</param>
        /// <param name="targetRow">The target row for the next move.</param>
        /// <param name="targetColumn">The target column for the next move.</param>
        /// <returns><c>true</c> if the input is valid; otherwise, <c>false</c>.</returns>
        public static bool TryGetUserInput(Player currentPlayer, out int targetRow, out int targetColumn)
        {
            targetRow = 0;
            targetColumn = 0;

            Console.WriteLine($"{currentPlayer.Name} ({currentPlayer.Symbol}) - Enter row (1-3) and column (1-3), separated by a space, or 'q' to quit...");
            string? input = Console.ReadLine();

            if (string.Compare(input, "q", StringComparison.OrdinalIgnoreCase) == 0)
                Environment.Exit(0);

            string[]? splittedInput = input?.Split(' ');

            if (int.TryParse(splittedInput?[0], out targetRow) is false ||
                targetRow < 1 || targetRow > 3)
            {
                Console.WriteLine("Invalid target cell row must be between 1 and 3");
                return false;
            }

            if (int.TryParse(splittedInput?[1], out targetColumn) is false ||
                targetColumn < 1 || targetColumn > 3)
            {
                Console.WriteLine("Invalid target cell column must be between 1 and 3");
                return false;
            }

            return true;
        }
    }
}
