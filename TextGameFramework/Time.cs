using System.Diagnostics;


namespace TextGameFramework
{
    public static class Time
    {
        private static Stopwatch stopwatch;
        private static int _prevFrameAt;
        private static int _lastFrameAt;

        public static void Init()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            _prevFrameAt = 0;
            _lastFrameAt = 1;
        }

        public static void NewFrame()
        {
            _prevFrameAt = _lastFrameAt;
            _lastFrameAt = ElapsedTotal();
        }

        public static int ElapsedTotal()
        {
            return (int)stopwatch.ElapsedMilliseconds;
        }

        public static int Elapsed()
        {
            return ElapsedTotal() - _lastFrameAt;
        }

        public static int DeltaTime()
        {
            return _lastFrameAt - _prevFrameAt;
        }

        public static int FPS()
        {
            var d = DeltaTime();
            if (d > 0)
                return (int)(1000f / d);
            else
                return 999;
        }

        public static int currentFPS()
        {
            var e = Elapsed();
            if (e > 0)
                return (int)(1000f / e);
            else
                return 999;
        }

    }
}
