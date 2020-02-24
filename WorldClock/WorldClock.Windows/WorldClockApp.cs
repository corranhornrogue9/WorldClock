using Xenko.Engine;

namespace WorldClock.Windows
{
    class WorldClockApp
    {
        static void Main(string[] args)
        {
            using (var game = new Game())
            {
                game.Run();
            }
        }
    }
}
