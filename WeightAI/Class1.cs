using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightAI
{
    public class Brain
    {
        List<IAction> availableActions = new List<IAction>();
        IAction currentAction = null;

        public void Update(Status s)
        {
            if (currentAction == null)
            {
                findAction(s);
                currentAction.StartAction();
            }
            currentAction.PerformAction();
            if (currentAction.IsActionFinished())
            {
                currentAction.EndAction();
                currentAction = null;
            }
        }

        void findAction(Status s)
        {
            List<IAction> actions = new List<IAction>(availableActions);
            foreach (IAction a in actions)
            {
                if (currentAction == null)
                    currentAction = a;
                else
                {
                    if(a.GetWeight(s) > currentAction.GetWeight(s))
                    {
                        currentAction = a;
                    }
                }
            }
        }
        public void AddAction(IAction a)
        {
            availableActions.Add(a);
        }
    }
    public struct Status
    {
        public bool hasFoodSource, hasWaterSource, hasFood, hasWater;
        public bool isHealthy, isInjured, isLost, isCarrying;
        public static Status Default
        {
            get
            {
                return new Status { hasFood = false, hasFoodSource = false, hasWater = false, hasWaterSource = false, isCarrying = false, isHealthy = false, isInjured = false, isLost = false };
            }
        }
    }
    public enum Anthillstats
    {
        FoodSource, WaterSource, FoodInAnthill, WaterInAnthill, Ants
    }
    public enum AntStats
    {
        Injured, Healthy, Lost
    }
    public interface IAction
    {
        float GetWeight(Status s);
        void PerformAction();
        bool IsActionFinished();
        void StartAction();
        void EndAction();
    }
}
