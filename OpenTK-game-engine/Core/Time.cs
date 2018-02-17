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

        public static double DeltaTime => deltaTime;

        public static long ElapsedTime => elapsedTime;

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
            deltaTime = deltaTimeMilliseconds;
            deltaTime /= 1000;
            prev_elapsedMilliseconds = elapsedTime;
        }
    }
}
