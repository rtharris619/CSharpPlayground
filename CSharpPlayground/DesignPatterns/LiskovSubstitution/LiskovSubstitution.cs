using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.DesignPatterns.LiskovSubstitution
{
    public class LiskovSubstitution
    {
        static public int Area(Rectangle rectangle) => rectangle.Width * rectangle.Height;

        public void Driver()
        {
            Rectangle rectangle = new Rectangle(2, 4);
            WriteLine($"{rectangle} has area {Area(rectangle)}");

            Rectangle square = new Square();
            square.Width = 4;
            WriteLine($"{square} has area {Area(square)}");
        }
    }

    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle()
        {

        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }         

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
        public override int Width
        {
            set { base.Width = base.Height = value; }
        }

        public override int Height
        {
            set { base.Width = base.Height = value; }
        }
    }
}
