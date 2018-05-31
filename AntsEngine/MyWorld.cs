using Ants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsEngine
{
    class MyWorld : World
    {
        public MyWorld() : base()
        {
            //AddActor(new Actors.Anthill() { position = new Vector2(300, 300) });
        }
        protected override void Render()
        {
            //Here half of the magic happens, don't delet this or you will break all the things
            base.Render();
        }
        protected override void Update()
        {
            //Here the second half of the magic happens, don't delet this or you will break all the things
            base.Update();
        }
    }
}
