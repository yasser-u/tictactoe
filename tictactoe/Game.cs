using TicTacToe;

/// <summary>
/// Manages the main logic of the Tic Tac Toe game.
/// </summary>
internal class Game
{
    private List<Cell> grid;
    private Player currentPlayer;
    private readonly Player playerOne;
    private readonly Player playerTwo;

    /// <summary>
    /// Initializes a new instance of the <see cref="Game"/> class.
    /// </summary>
    public Game()
    {
        grid = GameInitializer.InitializeGrid();
        playerOne = new Player('O', "Player One");
        playerTwo = new Player('X', "Player Two");
        currentPlayer = playerOne;
    }

    /// <summary>
    /// Starts the game loop.
    /// </summary>
    public void Start()
    {
        GameBoardDisplay.DisplayGameBoard(grid);
        while (true)
        {
            if (!ProcessTurn())
                continue;

            Console.Clear();
            GameBoardDisplay.DisplayGameBoard(grid);

            if (GameStateChecker.CheckGameEnd(grid, currentPlayer, playerOne, playerTwo))
                break;

            SwitchPlayer();
        }
    }

    /// <summary>
    /// Processes the current player's turn.
    /// </summary>
    /// <returns><c>true</c> if the turn was processed successfully; otherwise, <c>false</c>.</returns>
    private bool ProcessTurn()
    {
        if (!UserInputHandler.TryGetUserInput(currentPlayer, out int targetRow, out int targetColumn))
            return false;

        if (!PlayOnGameBoard(targetRow, targetColumn))
        {
            Console.WriteLine("Invalid move");
            return false;
        }

        return true;
    }

    /// <summary>
    /// Plays the current player's move on the game board.
    /// </summary>
    /// <param name="targetRow">The target row for the move.</param>
    /// <param name="targetColumn">The target column for the move.</param>
    /// <returns><c>true</c> if the move was played successfully; otherwise, <c>false</c>.</returns>
    private bool PlayOnGameBoard(int targetRow, int targetColumn)
    {
        Cell? cell = GetCell(targetRow, targetColumn);

        if (cell == null || cell.Value == playerOne.Symbol || cell.Value == playerTwo.Symbol)
            return false;

        cell.UpdateValue(currentPlayer.Symbol);
        return true;
    }

    /// <summary>
    /// Gets the cell at the specified row and column.
    /// </summary>
    /// <param name="row">The row of the cell.</param>
    /// <param name="column">The column of the cell.</param>
    /// <returns>The cell at the specified row and column, or <c>null</c> if no such cell exists.</returns>
    private Cell? GetCell(int row, int column)
        => grid.FirstOrDefault(cell => cell.Row == row && cell.Column == column);

    /// <summary>
    /// Switches the current player to the next player.
    /// </summary>
    private void SwitchPlayer()
    {
        currentPlayer = currentPlayer == playerOne ? playerTwo : playerOne;
    }
}
