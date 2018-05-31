#define SharpDX

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Mathematics.Interop;

namespace Ants
{
#if(SharpDX)
    public struct Vector2
    {
        public double x;
        public double y;
        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public static double Distance(Vector2 a, Vector2 b)
        {
            return Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2));
        }
        public static explicit operator RawVector2(Vector2 v)
        {
            return new RawVector2((float)v.x, (float)v.y);
        }
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }
        public static Vector2 operator *(Vector2 a, float b)
        {
            return new Vector2(a.x * b, a.y * b);
        }
        public static Vector2 operator *(float b, Vector2 a)
        {
            return new Vector2(a.x * b, a.y * b);
        }
        public static Vector2 operator /(Vector2 a, float b)
        {
            return new Vector2(a.x / b, a.y / b);
        }
        public static Vector2 operator /(float b, Vector2 a)
        {
            return new Vector2(a.x / b, a.y / b);
        }
        public static Vector2 Lerp(Vector2 a, Vector2 b, float amount)
        {
            if (amount > 1)
                amount = 1;

            return (a + amount * (b - a));
        }
    }
#else
    public struct Vector2 : 
#endif
    public struct Rectangle
    {
        public double x;
        public double y;
        public int width;
        public int height;

        public Rectangle(double x , double y, int w, int h)
        {
            this.x = x;
            this.y = y;
            width = w;
            height = h;
        }
        public static explicit operator RawRectangleF(Rectangle v)
        {
            return new RawRectangleF((float)v.x, (float)v.y, (float)(v.x + v.width), (float)(v.y + v.height));
        }
    } 
}
