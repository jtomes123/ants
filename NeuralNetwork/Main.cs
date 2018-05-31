using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Brain
    {
        const int maximumOfConnections = 10;
        List<MindNode> nodes = new List<MindNode>();
        public MindNode[] GetMindMap(MindNode.Anthillstats desiredResult, MindNode.Anthillstats[] availablePrerequisites)
        {
            List<MindNode> temp = new List<MindNode>();
            foreach (var node in nodes)
            {
                if (node.GetResults() == desiredResult)
                {
                    temp.Add(node);
                }
            }
            List<MindNode[]> maps = new List<MindNode[]>();
            foreach (var node in temp)
            {
                maps.Add(ConstructMindMap(node, availablePrerequisites));
            }

            return maps.OrderBy(o => o.Length).First();
        }
        public Brain()
        {
            var r = new RetrieveFood();
            nodes.Add(new Forage());
            nodes.Add(r);

            var v = GetMindMap(MindNode.Anthillstats.FoodInAnthill, new MindNode.Anthillstats[] { MindNode.Anthillstats.Ants });
        }
        MindNode[] ConstructMindMap(MindNode m, MindNode.Anthillstats[] available)
        {
            MindNode[] mindNodeMap;
            MindMapNode temp = new MindMapNode(m);
            temp.PopulateChildren(nodes, available, out mindNodeMap);
            return mindNodeMap;
        }
    }
    public class MindMapNode
    {
        public bool done;
        public List<MindMapNode> children = new List<MindMapNode>();
        public MindNode myNode;
        public MindMapNode parent = null;
        public MindNode[] tree;
        public MindMapNode(MindNode m)
        {
            myNode = m;
        }
        public MindMapNode(MindNode m, MindMapNode parent)
        {
            myNode = m;
            this.parent = parent;
        }
        public void PopulateChildren(List<MindNode> mn, MindNode.Anthillstats[] available, out MindNode[] map)
        {
            map = null;
            foreach (var p in available)
            {
                if (myNode.GetPrerequisites() == p)
                    done = true;
            }
            if (done)
            {
                map = BuildTree();
            }
            else
            {
                foreach (var n in mn)
                {
                    if (myNode.GetPrerequisites() == n.GetResults())
                    {
                        MindMapNode mindMapNode = new MindMapNode(n, this);
                        children.Add(mindMapNode);
                        mindMapNode.PopulateChildren(mn, available, out map);
                    }
                }
            }
        }
        public MindNode[] BuildTree()
        {
            List<MindMapNode> temp = new List<MindMapNode>();
            temp.Add(this);
            while (temp.Last().parent != null)
            {
                temp.Add(temp.Last().parent);
            }
            List<MindNode> temp2 = new List<MindNode>();
            foreach (var i in temp)
            {
                temp2.Add(i.myNode);
            }
            //temp2.Reverse();
            return temp2.ToArray();
        }
    }
    public abstract class MindNode
    {
        public abstract string GetIdentifier();
        public abstract Anthillstats GetResults();
        public abstract Anthillstats GetPrerequisites();
        public abstract Result PerformAction();
        public enum Anthillstats
        {
            FoodSource, WaterSource, FoodInAnthill, WaterInAnthill, Ants
        }
    }
    public struct Result
    {
        public bool success;
        public string errorMessage;
        public static Result Success
        {
            get
            {
                return new Result() { success = true, errorMessage = "" };
            }
        }
        public static Result Fail
        {
            get { return new Result() { success = false }; }
        }
    }
}
