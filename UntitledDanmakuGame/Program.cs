using System;

namespace UntitledDanmakuGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new UntitledDanmakuGame())
                game.Run();
        }
    }
}
