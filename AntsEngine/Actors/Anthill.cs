using Ants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct2D1;

namespace AntsEngine.Actors
{
    class Anthill : Actor
    {
        double myAntSpawnTime = 0;

        List<Ant> myAnts = new List<Ant>();
        public List<List<Vector2>> pathsToFood = new List<List<Vector2>>();
        
        public override void Render()
        {
            Renderer.SetColor(SharpDX.Color.Gray);
            Renderer.FillCircle(position, 20);

            if(Variables.showPathsToFood)
            {
                Renderer.SetColor(SharpDX.Color.ForestGreen);
                foreach (var l in pathsToFood)
                {
                    for (int i = 0; i < l.Count; i++)
                    {
                        Renderer.FillCircle(l[i], 5);

                        if (i > 0)
                            Renderer.DrawLine(l[i - 1], l[i]);
                    }
                }
            }
        }

        public override void Update()
        {
            
            if (myAntSpawnTime <= Time.time && myAnts.Count < getDesiredAntCount())
            {
                spawnAnt();
                myAntSpawnTime = Variables.antSpawnDelay + Time.time;
            }
        }
        private int getDesiredAntCount()
        {
            return 1;
        }
        private void spawnAnt()
        {
            Ant a = new Ant(this);
            world.AddActor(a);
            myAnts.Add(a);
        }

        public override void Initialize()
        {
           
        }
    }
}
