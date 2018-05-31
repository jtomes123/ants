using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Mathematics.Interop;
using SharpDX.Direct2D1;

namespace Ants
{
    public partial class Renderer
    {
        public void DrawLine(Vector2 start, Vector2 end, float thickness = 1)
        {
            target.DrawLine((RawVector2)start, (RawVector2)end, myBrush, thickness);
        }
        public void DrawCircle(Vector2 positiom, float radius, float thickness = 1)
        {
            DrawElipse(positiom, radius, radius, thickness);
        }
        public void DrawElipse(Vector2 positiom, float radiusX, float radiusY, float thickness = 1)
        {
            target.DrawEllipse(new Ellipse((RawVector2)positiom, radiusX, radiusY), myBrush, thickness);
        }
        public void DrawRectangle(Rectangle r, float thickness = 1)
        {
            target.DrawRectangle((RawRectangleF)r, myBrush, thickness);
        }

        public void FillCircle(Vector2 positiom, float radius)
        {
            FillElipse(positiom, radius, radius);
        }
        public void FillElipse(Vector2 positiom, float radiusX, float radiusY)
        {
            target.FillEllipse(new Ellipse((RawVector2)positiom, radiusX, radiusY), myBrush);
        }
        public void FillRectangle(Rectangle r)
        {
            target.FillRectangle((RawRectangleF)r, myBrush);
        }

        public void OutlinedCircle(Vector2 positiom, float radius, float thickness = 1)
        {
            DrawElipse(positiom, radius, radius, thickness);
            FillElipse(positiom, radius, radius);
        }
        public void OutlinedElipse(Vector2 positiom, float radiusX, float radiusY, float thickness = 1)
        {
            target.FillEllipse(new Ellipse((RawVector2)positiom, radiusX, radiusY), myBrush);
            target.DrawEllipse(new Ellipse((RawVector2)positiom, radiusX, radiusY), myBrush, thickness);
        }
        public void OutlinedRectangle(Rectangle r, float thickness = 1)
        {
            target.FillRectangle((RawRectangleF)r, myBrush);
            target.DrawRectangle((RawRectangleF)r, myBrush, thickness);
        }
    }
}
