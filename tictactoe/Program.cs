class Program
{
    static void Main()
    {
        string mode = Game.SelectGameMode();
        Game game = new Game(mode);
        game.Start();
    }
}
