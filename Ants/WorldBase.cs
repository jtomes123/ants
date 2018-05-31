using SharpDX;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ants
{
    public abstract class WorldBase
    {
        const double targetDelta = 1000 / 60;
        private Time time = new Time();
        private Renderer renderer;

        public Renderer Renderer
        {
            get { return renderer; }
        }
        public Time Time
        {
            get { return time; }
        }

        public void RenderLoop(Stopwatch s, RenderTarget r)
        {
            Stopwatch d = new Stopwatch();
            d.Start();
            if (renderer == null)
                renderer = new Renderer(r);
            time.Update(s);
            Update();
            Render();
            d.Stop();

            double t = targetDelta - d.ElapsedMilliseconds;
            if (t > 0)
                Thread.Sleep((int)t);
        }
        protected abstract void Update();
        protected abstract void Render();

    }
    public class Time
    {
        public double delta
        {
            get;
            set;
        }
        public double time
        {
            get;
            set;
        }
        public Time()
        {
            delta = 0;
            time = 0;
        }
        public void Update(Stopwatch s)
        {
            delta = s.Elapsed.TotalSeconds - time;
            time = s.Elapsed.TotalSeconds;
        }
    }
    public partial class Renderer
    {
        RenderTarget target;
        SolidColorBrush myBrush;
        public Renderer(RenderTarget t)
        {
            target = t;
            myBrush = new SolidColorBrush(target, Color.White);
        }
        public void SetColor(Color c)
        {
            myBrush.Color = c;
        }
    }
}
