using System;

namespace RPGGame
{
#if WINDOWS || LINUX
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new RPGGame())
                game.Run();
        }
    }
#endif
}
