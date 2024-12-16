using TicTacToe;

internal static class GameBoardDisplay
{
    /// <summary>
    /// Displays the game board.
    /// </summary>
    /// <param name="grid">The game board grid.</param>
    public static void DisplayGameBoard(List<Cell> grid)
    {
        Console.WriteLine(new string('=', Console.WindowWidth));
        Console.WriteLine(".NET MAUI".PadLeft(Console.WindowWidth / 2));
        Console.WriteLine(new string('=', Console.WindowWidth));

        Console.WriteLine($"|-----------------|");
        DisplayGameBoardLine(GetCellContent(grid, 1, 1), GetCellContent(grid, 1, 2), GetCellContent(grid, 1, 3));
        Console.WriteLine($"|-----|-----|-----|");
        DisplayGameBoardLine(GetCellContent(grid, 2, 1), GetCellContent(grid, 2, 2), GetCellContent(grid, 2, 3));
        Console.WriteLine($"|-----|-----|-----|");
        DisplayGameBoardLine(GetCellContent(grid, 3, 1), GetCellContent(grid, 3, 2), GetCellContent(grid, 3, 3));
        Console.WriteLine($"|-----------------|");
    }

    /// <summary>
    /// Gets the content of a cell.
    /// </summary>
    /// <param name="grid">The game board grid.</param>
    /// <param name="row">The row of the cell.</param>
    /// <param name="column">The column of the cell.</param>
    /// <returns>The content of the cell.</returns>
    private static char GetCellContent(List<Cell> grid, int row, int column)
        => grid
            .Where(cell => cell.Row == row)
            .Where(cell => cell.Column == column)
            .Select(cell => cell.Value ?? ' ')
            .FirstOrDefault();

    /// <summary>
    /// Displays a line of the game board.
    /// </summary>
    /// <param name="leftCell">The content of the left cell.</param>
    /// <param name="middleCell">The content of the middle cell.</param>
    /// <param name="rightCell">The content of the right cell.</param>
    private static void DisplayGameBoardLine(char leftCell, char middleCell, char rightCell)
    {
        Console.WriteLine($"|  {leftCell}  |  {middleCell}  |  {rightCell}  |");
    }
}
