using System.Collections.Generic;

namespace CommandLineSims.NeighbourMode
{
    public class Family
    {
        public string familyName { get; }
        // public List<Sim> sims { get; }
        
        public Family(string familyName)
        {
            this.familyName = familyName;
        }
    }
}