namespace CommandLineSims.NeighbourMode
{
    public class Plot
    {
        public string name { get; }
        public int size { get; }

        public Plot(string name, int size)
        {
            this.name = name;
            this.size = size;
        }
    }
}