namespace TicTacToe
{
    /// <summary>
    /// Represents a player in the Tic Tac Toe game.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Gets the symbol of the player.
        /// </summary>
        char Symbol { get; }

        /// <summary>
        /// Gets the name of the player.
        /// </summary>
        string Name { get; }
    }
}
