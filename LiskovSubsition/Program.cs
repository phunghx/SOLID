using System;

namespace LiskovSubsition
{
    public class Rectangle
    {
        public virtual int Width { set; get; }
        public virtual int Height { set; get; }
        public Rectangle() : this(0,0)
        { }
        public Rectangle(int w, int h)
        {
            Width = w;
            Height = h;
        }
        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }
    public class Square : Rectangle
    {
        public override int Width { set { base.Width = base.Height = value; } }
        public override int Height { set { base.Width = base.Height = value; } }
    }
    class Program
    {
        static int Area(Rectangle r) => r.Height * r.Width;
            
        static void Main(string[] args)
        {
            Rectangle r1 = new Rectangle(2,3);
            Console.WriteLine(r1);
            Console.WriteLine(Area(r1));

            Rectangle s1 = new Square();
            s1.Width = 2;
            Console.WriteLine(s1);
            Console.WriteLine(Area(s1));

        }
    }
}
