namespace CommandLineSims
{
    public interface IUpdateable
    {
        void Update();
    }
    
    /// <summary>
    /// Game objects are updated every frame
    /// </summary>
    
    public abstract class GameObject : IUpdateable
    {
        // TODO
        public bool markToRemove = false;
        
        public GameObject()
        {
            GameManager.Add(this);
        }

        public abstract void Update();
    }
}