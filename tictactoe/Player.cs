namespace TicTacToe
{
    /// <summary>
    /// Represents a player in the Tic Tac Toe game.
    /// </summary>
    internal class Player : IPlayer
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
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="symbol">The symbol representing the player.</param>
        /// <param name="name">The name of the player.</param>
        public Player(char symbol, string name)
        {
            Symbol = symbol;
            Name = name;
        }
    }
}
