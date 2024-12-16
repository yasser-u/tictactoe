using TicTacToe;

internal static class GameBoardDisplay
{
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

    private static char GetCellContent(List<Cell> grid, int row, int column)
        => grid
            .Where(cell => cell.Row == row)
            .Where(cell => cell.Column == column)
            .Select(cell => cell.Value ?? ' ')
            .FirstOrDefault();

    private static void DisplayGameBoardLine(char leftCell, char middleCell, char rightCell)
    {
        Console.WriteLine($"|  {leftCell}  |  {middleCell}  |  {rightCell}  |");
    }
}
