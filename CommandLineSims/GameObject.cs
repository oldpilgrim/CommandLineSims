namespace CommandLineSims
{
    public interface IUpdateable
    {
        void Update();
    }
    
    /// <summary>
    /// Game objects are updated on a fixed interval 
    /// </summary>
    
    public class GameObject : IUpdateable
    {
        // TODO
        public bool markToRemove = false;
        
        public GameObject()
        {
            GameManager.Add(this);
        }
        
        public virtual void Update()
        {
            
        }
    }
}