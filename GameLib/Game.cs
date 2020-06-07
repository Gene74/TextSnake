using System;
using System.Collections.Generic;
using System.Threading;
using TextGameFramework;
using GameLib.Templates;
using GameLib.GameObjects;


namespace GameLib
{
    public class Game : IDisposable
    {
        // KONSTANTEN

        private const int SCREEN_WIDTH = 80;
        private const int SCREEN_HEIGHT = 30;
        private const int WORLD_WIDTH = 50;
        private const int WORLD_HEIGHT = 20;
        private const int OFFSET_LEFT = 1;
        private const int OFFSET_TOP = 2;

        // EIGENSCHAFTEN

        private FIFO<GameObject> newGameObjects;
        private List<GameObject> existingGameObjects;
        private int _targetMS;

        // KONSTRUKTOR

        public Game(int targetFPS = 30) : base()
        {
            initConsole();
            newGameObjects = new FIFO<GameObject>();
            existingGameObjects = new List<GameObject>();
            SetTargetFPS(targetFPS);
            createNewGame();
        }

        public void Dispose()
        {
            newGameObjects = null;
            existingGameObjects = null;
        }

        // METHODEN

        public void SetTargetFPS(int fps) => _targetMS = (int)(1000f / fps);

        private void initConsole()
        {
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(SCREEN_WIDTH, SCREEN_HEIGHT);
            Console.SetWindowSize(SCREEN_WIDTH, SCREEN_HEIGHT);
            Console.CursorVisible = false;
            ScreenBuffer.Init(SCREEN_WIDTH, SCREEN_HEIGHT);
        }

        private void createNewGame()
        {
            // Add World
            Spawn(new World(WORLD_WIDTH, WORLD_HEIGHT, OFFSET_LEFT, OFFSET_TOP));

            // create Player
            // create Apples

            // FPS Counter
            Spawn(new FPSCounter());
        }

        public void Spawn(GameObject go) => newGameObjects.Push(go);

        public void Run()
        {
            Time.Init();
            while (true)
            {
                // Initialize new Gameobjects
                callStartFunctions();

                // Update existing Gameobjects
                callUpdateFunctions();

                // Draw Gameobjects
                callDrawFunctions();

                // Check Frame Time
                while (Time.Elapsed() < _targetMS)
                    Thread.Sleep(1);

                // Update Framte Time
                Time.NewFrame();
            }
        }

        private void callStartFunctions()
        {
            // Call Start Functions
            while (newGameObjects.Count > 0)
            {
                var go = newGameObjects.Pull();
                go.Start();
                existingGameObjects.Add(go);
            }
        }

        private void callUpdateFunctions()
        {
            // Call Update Functions
            foreach (var go in existingGameObjects)
                if (go.Active) go.Update();
        }

        private void callDrawFunctions()
        {
            // clear Buffer
            ScreenBuffer.Clear();

            // Call Draw Functions
            foreach (var go in existingGameObjects)
                if (go.Active) go.Draw();

            // print buffer
            ScreenBuffer.Display();
        }

    }
}
