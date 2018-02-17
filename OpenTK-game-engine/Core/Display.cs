using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Core
{
    static class Display
    {
        private static GameWindow window;
        private static bool initialized = false;

        public static bool Initialized => initialized;
        /// <summary>
        /// Creates A GameWindow given the parameters
        /// </summary>
        public static void Init(int width, int height, string title, double max_fps = 60.0)
        {
            if (initialized)
                  return;
            window = new GameWindow(width, height, GraphicsMode.Default, title, 
                GameWindowFlags.Default, DisplayDevice.Default, 
                3, 2, GraphicsContextFlags.ForwardCompatible);
            if (window == null)
            {
                System.Console.WriteLine("Failed to Initialize the Display!");
                System.Environment.Exit(-1);
            }
            window.Width = width;
            window.Height = height;
            Center();
                
            window.TargetRenderFrequency = max_fps;

            initialized = true;
            Start();
        }

        /// <summary>
        /// Set up the neccesary things AFTER the window has been opened
        /// </summary>
        private static void Start()
        {
            if (!initialized)
                return;
        
            window.Closing += OnDisplayClose;
            window.FocusedChanged += FocusChanged;
            window.Resize += Resize;
            window.UpdateFrame += Engine.Update;
            window.RenderFrame += PreRender;
            window.RenderFrame += Render;
            Engine.Start();
            window.Run();
        }

        /// <summary>
        /// Centers the main window on the main monitor
        /// </summary>
        private static void Center()
        {
            DisplayDevice display = DisplayDevice.Default;
            int x = (display.Width - window.Width) / 2;
            int y = (display.Height - window.Height) / 2;
            window.Location = new System.Drawing.Point(x, y);
        }

        #region event_handlers

        private static void OnDisplayClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Console.WriteLine("{0}, {1} Close", sender, e);
            Engine.Dispose();
        }

        private static void FocusChanged(object sender, System.EventArgs e)
        {
            System.Console.WriteLine("{0}, {1} Focus", sender, e);
        }

        private static void Resize(object sender, System.EventArgs e)
        {
            System.Console.WriteLine("{0}, {1} Resize", sender, e);
        }

        private static void PreRender(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color4.Aqua);
        }

        private static void Render(object sender, FrameEventArgs e)
        {
            window.SwapBuffers();
        }
        #endregion
    }
}
