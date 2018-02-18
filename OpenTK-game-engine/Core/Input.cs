using OpenTK;
using OpenTK.Input;

namespace Core
{
    public static class Input
    {
        private static char[] keypress = new char[256];
        private static char[] keydown = new char[256];
        private static char[] keyup = new char[256];

        public static bool GetKeyDown(char c)
        {
            if (keydown[c] != 0)
                return true;
            return false;
        }

        public static void Start()
        {
            GameWindow window = Display.Window;
            window.KeyPress += OnKeyPress;
            window.KeyDown += OnKeyDown;
            window.KeyUp += OnKeyUp;
            window.MouseMove += OnMouseMove;
            window.MouseDown += OnMouseDown;
            window.MouseUp += OnMouseUp;
        }

        public static void UpdateInput()
        {

        }

        #region display_events
        private static void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
        }

        private static void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private static void OnMouseMove(object sender, MouseMoveEventArgs e)
        {
        }

        private static void OnKeyUp(object sender, KeyboardKeyEventArgs e)
        {
        }

        private static void OnKeyDown(object sender, KeyboardKeyEventArgs e)
        {
            keypress[(char)e.Key] = (char)e.Key;
        }

        private static void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            keypress[e.KeyChar] = e.KeyChar;
        }
        #endregion
    }
}
