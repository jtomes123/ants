using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct2D1;
using SharpDX;
using WeightAI;

namespace AntsEngine.Actors
{
    class Ant : Actor
    {
        public Anthill myAnthill = null;
        Ants.Vector2 target = new Ants.Vector2();
        public List<Ants.Vector2> myPath = new List<Ants.Vector2>();
        public List<Actor> sensoryInput = new List<Actor>();

        Brain brain = new Brain();

        public Ant(Anthill parent)
        {
            myAnthill = parent;
            position = parent.position;

            brain.AddAction(new Forage(this, (MyWorld)world));
            brain.AddAction(new ReturnToAnthill(this, (MyWorld)world));
            brain.AddAction(new FetchFood(this, (MyWorld)world));
        }
        public override void Render()
        {
            Renderer.SetColor(Color.DarkKhaki);
            Renderer.FillCircle(position, 10);

            if (Variables.showPaths)
            {
                for (int i = 0; i < myPath.Count; i++)
                {
                    Renderer.SetColor(Color.DarkBlue);
                    Renderer.FillCircle(myPath[i], 5);

                    if (i > 0)
                        Renderer.DrawLine(myPath[i - 1], myPath[i]);
                }
            }
            if (Variables.showSensingRadius)
            {
                Renderer.SetColor(new Color(Color.Green.R, Color.Green.G, Color.Green.B, (byte)128));
                Renderer.FillCircle(position, (float)Variables.sensingRadius);
            }
            if (Variables.showSenseLines)
            {
                foreach (var s in sensoryInput)
                {
                    Renderer.SetColor(Color.DarkOrange);
                    Renderer.DrawLine(position, s.position);
                }
            }
        }

        public override void Update()
        {
            move();

            if (Ants.Vector2.Distance(position, target) < 1)
            {
                sense();
                assignNewTarget();
            }
            

            
        }
        public void MoveTo(Ants.Vector2 pos)
        {
            target = pos;
        }
        //Handles selection of new target
        void assignNewTarget(bool goHome = false)
        {
            /*moveLerpBeginTime = Time.time;
            if (goHome || Ants.Vector2.Distance(myAnthill.position, position) > Variables.maximumDistanceFromAnthill)
            {
                myPath.Clear();
                target = myAnthill.position;
                return;
            }

            if (HasFood)
            {
                myPath.Clear();
                //TODO: Post path to food
                //Anthills will most likely manage paths to food and then dedicate workers to retrieve it

                target = myAnthill.position;
                return;
            }

            //Look for food
            Random r = new Random();
            double d1 = r.NextDouble(0, Variables.maximumDistanceToNewTarget);
            double d2 = Variables.maximumDistanceToNewTarget - d1;
            if (r.Next(2) > 0)
                d2 *= -1;
            if (r.Next(2) > 0)
                d1 *= -1;
            target = position + new Ants.Vector2(d1, d2);
            myPath.Add(target);*/
            Status s = Status.Default;
            brain.Update(s);
        }
        //Handles movement to new target
        void move()
        {
            position = Ants.Vector2.Lerp(position, target, (float)(Variables.pixelsPerSecond * Time.delta));
        }
        //Handles sensory input of the ant
        void sense()
        {
            sensoryInput.Clear();
            Parallel.ForEach<Actor>(world.actors, (a) =>
            {
                //TODO: Cleaner implementation
                if (a.GetType() == typeof(Food))
                    if (Ants.Vector2.Distance(position, a.position) < Variables.sensingRadius)
                        sensoryInput.Add(a);
            });
        }

        public override void Initialize()
        {
            assignNewTarget();
        }

        public bool HasFood
        {
            get
            {
                return false;
            }
        }
    }
}
