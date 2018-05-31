using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsEngine.Actors
{
    class Food : Actor
    {
        public override void Initialize()
        {

        }

        public override void Render()
        {
            Renderer.SetColor(SharpDX.Color.Crimson);
            Renderer.FillCircle(position, 8);
        }

        public override void Update()
        {

        }
    }
}
