using TextGameFramework;
using GameLib.Templates;


namespace GameLib.GameObjects
{
    public class FPSCounter : GameObject
    {
        string display;

        public FPSCounter() : base() { }

        public override void Update()
        {
            display = $"{Time.FPS(), 0:D4} FPS";
        }

        public override void Draw()
        {
            for (int i = 0; i < display.Length; i++)
                ScreenBuffer.Print(display[i], Transform.X + i, Transform.Y);
        }


    }
}
