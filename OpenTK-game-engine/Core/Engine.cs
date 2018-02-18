using OpenTK;

namespace Core
{
    public static class Engine
    {

        public static void Init(int w_width = 1920, int w_height = 1080, string w_title = "Engine")
        {
            Display.Init(w_width, w_height, w_title + " " + w_width.ToString() + "x" + w_height.ToString());
        }

        /// <summary>
        /// Starts all of the Components
        /// </summary>
        public static void Start()
        {
            Time.Start();
            Input.Start();
            Display.Window.UpdateFrame += Update;
        }

        /// <summary>
        /// One Frame worth of updates
        /// </summary>
        private static void Update(object sender, FrameEventArgs args)
        {
            Time.UpdateTime();
            Input.UpdateInput();
            System.Console.WriteLine(Input.GetKeyDown('a'));
            //System.Console.WriteLine("Elapsed Time: {0}, Delta time :{1:0.00}.", Time.ElapsedTime, Time.DeltaTime.ToString());
        }

        /// <summary>
        /// Should be used to dispose of resources
        /// </summary>
        public static void Dispose()
        {

        }
    }
}
