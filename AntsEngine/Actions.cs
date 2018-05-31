using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using WeightAI;

namespace AntsEngine
{
    class Forage : IAction
    {
        Actors.Ant me;
        MyWorld world;
        //List<Ants.Vector2> myPath = new List<Ants.Vector2>();
        bool finished = false;
        public Forage(Actors.Ant me, MyWorld world)
        {
            this.me = me;
            this.world = world;
        }
        public void EndAction()
        {
            me.myPath.Clear();
            finished = false;
        }

        public float GetWeight(Status s)
        {
            if (Ants.Vector2.Distance(me.position, me.myAnthill.position) > 1)
                return 0;
            if (me.myAnthill.pathsToFood.Count < 1)
            {
                return 5;
            }
            return 1 / (float)Math.Sqrt(me.myAnthill.pathsToFood.Count);
        }

        public bool IsActionFinished()
        {
            return finished;
        }

        public void PerformAction()
        {
            //Console.WriteLine("Foraging...");
            if (me.sensoryInput.Count > 0)
            {
                //TODO: Code refactoring, access to pathsToFood
                List<Ants.Vector2> temp = new List<Ants.Vector2>();
                temp.AddRange(me.myPath);
                me.myAnthill.pathsToFood.Add(temp);
                finished = true;
            }
            if (Ants.Vector2.Distance(me.position, me.myAnthill.position) > Variables.maximumDistanceFromAnthill)
                finished = true;

            Random r = Program.globalRandom;
            double d1 = r.NextDouble(0, Variables.maximumDistanceToNewTarget);
            double d2 = Variables.maximumDistanceToNewTarget - d1;
            if (r.Next(2) > 0)
                d2 *= -1;
            if (r.Next(2) > 0)
                d1 *= -1;
            Ants.Vector2 target = me.position + new Ants.Vector2(d1, d2);
            me.MoveTo(target);
            me.myPath.Add(target);
        }

        public void StartAction()
        {
            
        }
    }
    class ReturnToAnthill : IAction
    {
        Actors.Ant me;
        MyWorld world;
        public ReturnToAnthill(Actors.Ant me, MyWorld world)
        {
            this.me = me;
            this.world = world;
        }
        public void EndAction()
        {

        }

        public float GetWeight(Status s)
        {
            if (s.isCarrying || s.isInjured || me.HasFood)
                return 7.5f;
            return 0.5f;
        }

        public bool IsActionFinished()
        {
            return true;
        }

        public void PerformAction()
        {
            Console.WriteLine("Returning home...");
            me.position = me.myAnthill.position;
        }

        public void StartAction()
        {

        }
    }
    class FetchFood : IAction
    {
        Actors.Ant me;
        MyWorld world;
        public FetchFood(Actors.Ant me, MyWorld world)
        {
            this.me = me;
            this.world = world;
        }
        public void EndAction()
        {

        }

        public float GetWeight(Status s)
        {
            if (!s.hasFoodSource)
                return 0;

            return 4;
        }

        public bool IsActionFinished()
        {
            return true;
        }

        public void PerformAction()
        {
            Console.WriteLine("Fetching food...");
        }

        public void StartAction()
        {

        }
    }
}
