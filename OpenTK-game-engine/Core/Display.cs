using OpenTK;
using OpenTK.Graphics;

namespace Engine.Core
{
    static class Display
    {
        private static GameWindow window;
        private static bool initialized = false;

        public static bool Initialized { get { return initialized; } }

        public static void Init(int width, int height, string title)
        {
            if (initialized)
                return;
            window = new GameWindow(width, height, GraphicsMode.Default, title, 
                GameWindowFlags.Default, DisplayDevice.GetDisplay(DisplayIndex.Primary), 
                3, 2, GraphicsContextFlags.ForwardCompatible);
            if (window == null)
                initialized = false;
            initialized = true;
        }

        public static void Start()
        {
            if (!initialized)
                return;

            //Set up callbacks (delegates)
            window.
            Run();
        }

        private static void Run()
        {
        }
    }
}
