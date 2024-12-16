using TicTacToe;

/// <summary>
/// Manages the main logic of the Tic Tac Toe game.
/// </summary>
internal class Game
{
    private List<Cell> grid;
    private IPlayer currentPlayer;
    private readonly IPlayer playerOne;
    private readonly IPlayer playerTwo;

    /// <summary>
    /// Initializes a new instance of the <see cref="Game"/> class.
    /// </summary>
    /// <param name="mode">The game mode.</param>
    public Game(string mode = "1PvsIA")
    {
        grid = GameInitializer.InitializeGrid();
        playerOne = new Player('O', "Player One");

        switch (mode)
        {
            case "2P":
                playerTwo = new Player('X', "Player Two");
                break;
            case "IAvsIA":
                playerTwo = new StupidIA('X', "StupidIA 2");
                playerOne = new StupidIA('O', "StupidIA 1");
                break;
            case "1PvsIA":
            default:
                playerTwo = new StupidIA('X');
                break;
        }

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
        if (currentPlayer is StupidIA aiPlayer)
        {
            if (!aiPlayer.GetNextMove(grid, out int targetRow, out int targetColumn))
                return false;

            if (!PlayOnGameBoard(targetRow, targetColumn))
            {
                Console.WriteLine("Invalid move");
                return false;
            }
        }
        else
        {
            if (!UserInputHandler.TryGetUserInput(currentPlayer, out int targetRow, out int targetColumn))
                return false;

            if (!PlayOnGameBoard(targetRow, targetColumn))
            {
                Console.WriteLine("Invalid move");
                return false;
            }
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

    /// <summary>
    /// Prompts the user to select the game mode.
    /// </summary>
    /// <returns>The selected game mode.</returns>
    public static string SelectGameMode()
    {
        Console.WriteLine("Select game mode:");
        Console.WriteLine("1. 2P (Two Players)");
        Console.WriteLine("2. 1PvsIA (One Player vs AI)");
        Console.WriteLine("3. IAvsIA (AI vs AI)");
        Console.Write("Enter your choice (1-3): ");

        string? choice = Console.ReadLine();

        return choice switch
        {
            "1" => "2P",
            "2" => "1PvsIA",
            "3" => "IAvsIA",
            _ => "1PvsIA"
        };
    }
}
