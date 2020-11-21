namespace CommandLineSims.NeighbourMode
{
    public class Plot
    {
        public string name { get; }
        public int size { get; }
        public int value { get; private set; }
        public Family family { get; private set; }

        public Plot(string name, int size, Family family = null)
        {
            this.name = name;
            this.size = size;
            this.family = family;
            // TODO calculate value from size
        }

        public bool MoveFamily(Family f)
        {
            // TODO can only move if have enough funds
            if (family != null)
            {
                Game.PrintLn($"A family already lives at {name}!");
                return false;
            }
            
            family = f;
            return true;
        }
    }
}