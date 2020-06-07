using System;


namespace TextGameFramework
{
    public static class ScreenBuffer
    {
        // EIGENTSCHAFTEN

        private static byte[] screenBuffer;
        private static int _width;
        private static int _height;


        // METHODEN

        public static void Init(int width, int height)
        {
            _width = width;
            _height = height;
            screenBuffer = new byte[width * height];
        }

        public static int GetMaxWidth() => _width;
        public static int GetMaxHeight() => _height;

        public static byte[] GetBuffer() => screenBuffer;

        public static void Clear()
        {
            for (int x = 0; x < GetMaxWidth(); x++)
                for (int y = 0; y < GetMaxHeight(); y++)
                    screenBuffer[GetMaxWidth() * y + x] = (byte)' ';
        }

        public static void Print(char c, int x, int y)
        {
            if (!validate(x, y))
                return;
            else
                screenBuffer[GetMaxWidth() * (y - 1) + (x - 1)] = (byte)c;
        }


        private static bool validate(int x, int y)
        {
            return (x > 0 && x <= GetMaxWidth() && y > 0 && y <= GetMaxHeight());
        }


        public static void Display()
        {
            using (var stdout = Console.OpenStandardOutput(GetMaxWidth() * GetMaxHeight()))
            {
                stdout.Write(screenBuffer, 0, screenBuffer.Length);
            }
        }

    }
}
