using Ants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsEngine
{
    public abstract class Actor
    {
        protected World world;
        public Vector2 position = new Vector2();

        public abstract void Update();
        public abstract void Render();
        public abstract void Initialize();

        public void Register(World w) { world = w; }
        protected Renderer Renderer
        {
            get
            {
                return world.Renderer;
            }
        }
        protected Time Time
        {
            get
            {
                return world.Time;
            }
        }
    }
}
