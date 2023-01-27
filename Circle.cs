using System;
using System.Collections.Generic;
using System.Text;

namespace hw3
{
    class Circle : shape
    {
        private Point centerPoint;
        private double radius;

        public static double operator +(Circle s1, Circle s2)
        {
            return s1.area + s2.area;
        }

        public override void getArea()
        {
            Console.WriteLine("Area of " + this.name + ": " + this.area.ToString());
        }

        public override void getPerimeter()
        {
            Console.WriteLine("Circumference of " + this.name + ": " + this.perimeter.ToString());
        }

        public override void isPointInsideArea(Point p)
        {
            // remarkably easy to find this out, we basically get the distance of the point from the center and then see if it's greater than the radius, if it is then it must be outside of the circle's area
            double d = getDistance(centerPoint.x, p.x, centerPoint.y, p.y);
            if (d <= this.radius)
                Console.WriteLine("Point {0},{1} is inside of {2}.", p.x, p.y, this.name);
            else
                Console.WriteLine("Point {0},{1} is not inside of {2}.", p.x, p.y, this.name);
        }

        public Circle(string n, Point c, double r)
        {
            name = n;
            try
            {
                centerPoint = c;
                radius = r;
                area = Math.PI * Math.Pow(radius, 2);
                perimeter = 2 * Math.PI * radius;
            } 
            catch(Exception e)
            {
                Console.WriteLine("An exception occurred. Ensure that you input all information correctly.");
                Console.WriteLine(e);
            }
        }
        public Circle()
        {
            name = "Null";
            Console.WriteLine("An empty circle has been created.");
        }
    }
}
