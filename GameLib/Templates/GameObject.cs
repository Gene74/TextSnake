using TextGameFramework;


namespace GameLib.Templates
{
    public abstract class GameObject
    {
        public bool Active;
        public Transform Transform;

        public GameObject()
        {
            Active = true;
            Transform = new Transform();
        }

        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void Draw() { }

    }
}
