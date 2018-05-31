using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ants;

namespace AntsEngineTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.Run(new TestWorld());
        }
    }
    public class TestWorld : WorldBase
    {
        protected override void Render()
        {
            Renderer.DrawCircle(new Vector2(640, 360), 20, 5);
        }

        protected override void Update()
        {

        }
    }
}
