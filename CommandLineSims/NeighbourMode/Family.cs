using System.Collections.Generic;

namespace CommandLineSims.NeighbourMode
{
    public class Family
    {
        public string familyName { get; }
        public int funds;
        // public List<Sim> sims { get; }
        
        public Family(string familyName)
        {
            this.familyName = familyName;
            this.funds = 20000;
        }
    }
}