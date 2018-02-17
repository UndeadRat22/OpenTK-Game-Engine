using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Engine.Core
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

            window.Width = width;
            window.Height = height;
            Center();
                
            window.TargetRenderFrequency = max_fps;
            if (window == null)
                initialized = false;
            initialized = true;
        }

        /// <summary>
        /// Set up the neccesary things AFTER the window has been opened
        /// </summary>
        public static void Start()
        {
            if (!initialized)
                return;
        
            window.Load += OnLoad;
            window.Closing += OnDisplayClose;
            window.FocusedChanged += OnFocusChange;
            window.Resize += OnResize;
            window.UpdateFrame += OnUpadteFrame;
            window.RenderFrame += OnRenderFrame;
            window.Run();
        }

        private static void Center()
        {
            DisplayDevice display = DisplayDevice.Default;
            int x = (display.Width - window.Width) / 2;
            int y = (display.Height - window.Height) / 2;
            window.Location = new System.Drawing.Point(x, y);
        }

        #region event_handlers
        private static void OnLoad(object sender, System.EventArgs e)
        {
        }

        private static void OnDisplayClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
        private static void OnFocusChange(object sender, System.EventArgs e)
        {
        }

        private static void OnResize(object sender, System.EventArgs e)
        {
        }

        private static void OnUpadteFrame(object sender, FrameEventArgs e)
        {
        }
        private static void OnRenderFrame(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color4.Aqua);
            window.SwapBuffers();
        }
        #endregion
    }
}
