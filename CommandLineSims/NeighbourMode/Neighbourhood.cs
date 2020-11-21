using System.Collections.Generic;

namespace CommandLineSims.NeighbourMode
{
    public class Neighbourhood : Scene
    {
        private List<Plot> _plots;
        private List<Family> _familyBin;

        public Neighbourhood(List<Plot> plots, List<Family> families)
        {
            _plots = plots;
            _familyBin = families;
        }

        public void CreateFamily(string familyName)
        {
            _familyBin.Add(new Family(familyName));
        }

        public void CreatePlot(string plotName, int plotSize)
        {
            _plots.Add(new Plot(plotName, plotSize));
        }
    }
}