using GameLib.Templates;
using TextGameFramework;


namespace GameLib.GameObjects
{
    public class World : GameObject
    {
        // EIGENSCHAFTEN

        private int _width;
        public int Width
        {
            get { return _width; }
            private set { _width = value; }
        }

        private int _height;
        public int Height
        {
            get { return _height; }
            private set { _height = value; }
        }

        private char[,] _world;


        // KONSTRUKTOR

        public World(int width, int height, int offset_left, int offset_top)
        {
            _width = width;
            _height = height;
            Transform.SetPosition(offset_left, offset_top);
        }


        // METHODEN

        public override void Start()
        {
            _world = new char[Width,Height];
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    _world[x, y] = (x == 0 || x == Width-1 || y == 0 || y == Height-1) ? '#' : ' ';
        }


        public override void Draw()
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    ScreenBuffer.Print(
                        _world[x, y], 
                        Transform.X + x + 1, 
                        Transform.Y + y + 1
                    );
        }


    }
}
