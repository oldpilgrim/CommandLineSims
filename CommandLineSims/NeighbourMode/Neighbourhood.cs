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
            // family names are unique for now
            foreach (Family family in _familyBin)
            {
                if (family.familyName.Equals(familyName))
                {
                    Game.PrintLn("Failed to create family: family name already exists");
                    return;
                }
            }

            _familyBin.Add(new Family(familyName));
            Game.PrintLn($"Creating new family {familyName}");
        }

        public void CreatePlot(string plotName, int plotSize)
        {
            // plot names must be unique
            foreach (Plot plot in _plots)
            {
                if (plot.name.Equals(plotName))
                {
                    Game.PrintLn("Failed to create plot: plot name already exists");
                    return;
                }
            }

            _plots.Add(new Plot(plotName, plotSize));
            Game.PrintLn($"Creating new plot {plotName}");
        }

        public bool Move(string familyName, string plotName)
        {
            if (!_FindPlot(plotName, out Plot plot)) return false;
            if (!_FindFamily(familyName, out Family family)) return false;
            
            if (plot.MoveFamily(family))
            {
                Game.PrintLn($"{familyName} has moved into {plotName}.");
                _familyBin.Remove(family);
                return true;
            }

            return false;
        }

        public void QueryPlot(string plotName)
        {
            if (!_FindPlot(plotName, out Plot plot)) return;
            
            Game.PrintLn($"{plotName} is of size {plot.size}. Plot value is {plot.value}. " + (plot.family != null ? 
                $"{plot.family.familyName} is currently living here. " : "No family is currently living here."));
        }
        
        public void QueryFamily(string familyName)
        {
            if (!_FindFamily(familyName, out Family family)) return;
            
            Game.PrintLn("TODO.");        
        }

        private bool _FindPlot(string plotName, out Plot plot)
        {
            plot = _plots.Find(p => p.name.Equals(plotName));
            if (plot == null)
            {
                Game.PrintLn($"No plot with name {plotName} found.");
                return false;
            }

            return true;
        }

        private bool _FindFamily(string familyName, out Family family)
        {
            family = _familyBin.Find(f => f.familyName.Equals(familyName));
            if (family == null)
            {
                Game.PrintLn($"No family with name {familyName} found in the family bin.");
                return false;
            }

            return true;
        }

    }
}