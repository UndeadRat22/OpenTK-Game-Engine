using System.Diagnostics;

namespace Core
{
    public static class Time
    {
        private static Stopwatch stopwatch = null;

        private static long prev_elapsedMilliseconds = 0;
        private static long deltaTimeMilliseconds = 0;
        private static double deltaTime = 0;
        private static long elapsedTime = 0;

        public static float DeltaTime => (float)deltaTime;

        public static float ElapsedTime => elapsedTime;

        public static void Start()
        {
            if (stopwatch != null)
                return;
            stopwatch = Stopwatch.StartNew();
        }

        public static void UpdateTime()
        {
            elapsedTime = stopwatch.ElapsedMilliseconds;
            deltaTimeMilliseconds = elapsedTime - prev_elapsedMilliseconds;
            deltaTime = deltaTimeMilliseconds / 1000;
            prev_elapsedMilliseconds = elapsedTime;
        }
    }
}
