using Ants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AntsEngine
{
    class Program
    {
        public static Random globalRandom = new Random();
        static void Main(string[] args)
        {
            MyWorld w = new MyWorld();
            CommandProcessor c = new CommandProcessor();
            Thread mainThread = new Thread(new ParameterizedThreadStart(Run));
            mainThread.Start(w);
            //Game.Run(new MyWorld());
            while(true)
            {
                c.ProcessCommand(Console.ReadLine(), w);
            }
        }
        static void Run(object o)
        {
            Game.Run(o as MyWorld);
        }
    }
    public class World : WorldBase
    {
        public List<Actor> actors = new List<Actor>();
        public List<Actor> actorsToDestroy = new List<Actor>(), actorsToAdd = new List<Actor>();
        protected override void Render()
        {
            foreach (Actor a in actors)
            {
                a.Render();
            }
        }

        protected override void Update()
        {
            if(!Variables.paused)
            foreach (Actor a in actors)
            {
                a.Update();
            }
            foreach (Actor a in actorsToDestroy)
            {
                actors.Remove(a);
            }
            actorsToDestroy.Clear();
            foreach (Actor a in actorsToAdd)
            {
                addActor(a);
            }
            actorsToAdd.Clear();
        }

        public void AddActor(Actor a)
        {
            actorsToAdd.Add(a);

        }

        private void addActor(Actor a)
        {
            actors.Add(a);
            a.Register(this);
            a.Initialize();
        }
        public void DestroyActor(Actor a)
        {
            actorsToDestroy.Add(a);
        }
        public void ClearActors()
        {
            foreach (var a in actors)
            {
                DestroyActor(a);
            }
        }
    }
}

