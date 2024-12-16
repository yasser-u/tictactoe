using TicTacToe;

internal class Game
{
    private const char PlayerOne = 'O';
    private const char PlayerTwo = 'X';
    private List<Cell> grid;
    private char currentPlayer;

    public Game()
    {
        grid = new List<Cell>()
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
        currentPlayer = PlayerOne;
    }

    public void Start()
    {
        GameBoardDisplay.DisplayGameBoard(grid);
        while (true)
        {
            if (!TryGetUserInput(out int targetRow, out int targetColumn))
                continue;

            if (!PlayOnGameBoard(targetRow, targetColumn))
            {
                Console.WriteLine("Invalid move");
                continue;
            }

            Console.Clear();
            GameBoardDisplay.DisplayGameBoard(grid);

            if (IsGameBoardWin())
            {
                Console.WriteLine($"Player {currentPlayer} has won the game !!!!");
                break;
            }
            if (IsGameBoardFull())
            {
                Console.WriteLine($"It's a draw");
                break;
            }

            currentPlayer = currentPlayer == PlayerOne ? PlayerTwo : PlayerOne;
        }
    }

    private bool TryGetUserInput(out int targetRow, out int targetColumn)
    {
        targetRow = 0;
        targetColumn = 0;

        Console.WriteLine($"Player {currentPlayer} - Enter row (1-3) and column (1-3), separated by a space, or 'q' to quit...");
        string? input = Console.ReadLine();

        if (string.Compare(input, "q", StringComparison.OrdinalIgnoreCase) == 0)
            Environment.Exit(0);

        string[]? splittedInput = input?.Split(' ');

        if (int.TryParse(splittedInput?[0], out targetRow) is false ||
            targetRow < 1 || targetRow > 3)
        {
            Console.WriteLine("Invalid target cell row must be betwen 1 and 3");
            return false;
        }

        if (int.TryParse(splittedInput?[1], out targetColumn) is false ||
            targetColumn < 1 || targetColumn > 3)
        {
            Console.WriteLine("Invalid target cell column must be betwen 1 and 3");
            return false;
        }

        return true;
    }

    private bool PlayOnGameBoard(int targetRow, int targetColumn)
    {
        Cell? cell = GetCell(targetRow, targetColumn);

        if (cell == null || cell.Value == PlayerOne || cell.Value == PlayerTwo)
            return false;

        cell.UpdateValue(currentPlayer);
        return true;
    }

    private Cell? GetCell(int row, int column)
        => grid
            .Where(cell => cell.Row == row)
            .Where(cell => cell.Column == column)
            .FirstOrDefault();

    private bool IsGameBoardWin()
    {
        IEnumerable<IGrouping<int, Cell>> rows = grid
            .GroupBy(cell => cell.Row);

        if (rows.Any(row =>
            row.All(cell => cell.Value == PlayerOne) ||
            row.All(cell => cell.Value == PlayerTwo)))
        {
            return true;
        }

        IEnumerable<IGrouping<int, Cell>> columns = grid
            .GroupBy(cell => cell.Column);

        if (columns.Any(column =>
            column.All(cell => cell.Value == PlayerOne) ||
            column.All(cell => cell.Value == PlayerTwo)))
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
            diagonal.All(cell => cell.Value == PlayerOne) ||
            diagonal.All(cell => cell.Value == PlayerTwo)))
        {
            return true;
        }

        return false;
    }

    private bool IsGameBoardFull()
        => grid.All(cell => cell.Value.HasValue);
}
