using System;
using System.Threading;
using WeightAI;

namespace WeightAIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Brain b = new Brain();
            b.AddAction(new Forage());
            b.AddAction(new ReturnToAnthill());
            b.AddAction(new FetchFood());
            while (true)
            {
                Status s = Status.Default;
                s.isHealthy = true;
                Thread.Sleep(1000);
                b.Update(s);
            }
        }
    }
    public class Forage : IAction
    {
        public void EndAction()
        {

        }

        public float GetWeight(Status s)
        {
            if (!s.hasFoodSource)
            {
                if (s.hasFood)
                {
                    return 2.5f;
                }
                return 5;
            }
            return 1;
        }

        public bool IsActionFinished()
        {
            return true;
        }

        public void PerformAction()
        {
            Console.WriteLine("Foraging...");
        }

        public void StartAction()
        {

        }
    }
    public class ReturnToAnthill : IAction
    {
        public void EndAction()
        {

        }

        public float GetWeight(Status s)
        {
            if (s.isCarrying || s.isInjured || s.isLost)
                return 7.5f;
            return 0;
        }

        public bool IsActionFinished()
        {
            return true;
        }

        public void PerformAction()
        {
            Console.WriteLine("Returning home...");
        }

        public void StartAction()
        {

        }
    }
    public class FetchFood : IAction
    {
        public void EndAction()
        {

        }

        public float GetWeight(Status s)
        {
            if (s.hasFoodSource)
                return 4;

            return 0;
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
