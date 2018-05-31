using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Forage : MindNode
    {
        public override string GetIdentifier()
        {
            return "Forage";
        }

        public override Anthillstats GetPrerequisites()
        {
            return Anthillstats.Ants;
        }

        public override Anthillstats GetResults()
        {
            return Anthillstats.FoodSource;
        }

        public override Result PerformAction()
        {
            throw new NotImplementedException();
        }
    }
    public class RetrieveFood : MindNode
    {
        public override string GetIdentifier()
        {
            return "RetrieveFood";
        }

        public override Anthillstats GetPrerequisites()
        {
            return Anthillstats.FoodSource;
        }

        public override Anthillstats GetResults()
        {
            return Anthillstats.FoodInAnthill;
        }

        public override Result PerformAction()
        {
            throw new NotImplementedException();
        }
    }
}
