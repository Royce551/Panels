using System;

namespace Panels
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new PanelGame())
                game.Run();
        }
    }
}
