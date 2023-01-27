using System;
using System.Collections.Generic;
using System.Text;


namespace hw3
{
    class Rectangle : shape
    {
        private Point vert1;
        private Point vert2;
        private Point vert3;
        private Point vert4;
        // the above points are used for maths
        private double side1;
        private double side2;
        // and so are the sides
        public static double operator +(Rectangle s1, Rectangle s2)
        {
            // overload to allow adding the rectangle areas
            return s1.area + s2.area;
        }

        public override void getArea()
        {
            // print the area to console
            Console.WriteLine("area of " + this.name + ": " + this.area.ToString());
        }

        public override void getPerimeter()
        {
            Console.WriteLine("perimeter of " + this.name + ": " + this.perimeter.ToString());
        }

        public override void isPointInsideArea(Point p)
        {
            // a point p creates four triangles with each side and two vertices inside a rectangle. if the sum of the area of these triangles is equal to the area of the rectangle, the point is inside the rectangle.
            // leftSide = rightSide = side2
            // topSide = bottomSide = side1
            double b1 = getDistance(p.x, vert1.x, p.y, vert1.y);
            double c1 = getDistance(p.x, vert2.x, p.y, vert2.y);
            double b2 = getDistance(vert3.x, p.x, vert3.y, p.y);
            double c2 = getDistance(vert4.x, p.x, vert4.y, p.y);
            // these are all the sides of triangles formed by the point that aren't side1 or side2. 
            double trig1 = heronFormula(side1, b1, b2);
            double trig2 = heronFormula(side2, b2, c2);
            double trig3 = heronFormula(side1, c1, c2);
            double trig4 = heronFormula(side2, b1, c1);
            // we find the areas of the four triangles
            double trigSum = Math.Round(trig1 + trig2 + trig3 + trig4); // then add them together 
            Console.WriteLine("The sum of the areas of triangles made with the vertices of the rectangle is: {0}", trigSum);

            if(trigSum <= this.area)
                Console.WriteLine("Point {0},{1} is inside rectangle {2}.", p.x, p.y, this.name); // if area of triangles = area of rectangle then the point is inside
            else
                Console.WriteLine("Point {0},{1} is not inside rectangle {2}.", p.x, p.y, this.name); // the area will be greater if the point is outside

        }

        public Rectangle(string n,Point p1, Point p2)
        {
            name = n;
            try
            {
                vert1 = p1;
                vert3 = p2;
                vert2 = new Point(vert1.x, vert3.y);
                vert4 = new Point(vert3.x, vert1.y);
                side1 = this.getDistance(vert4.x, vert1.x);
                side2 = this.getDistance(vert3.y, vert1.y);
                area = Math.Round(side1 * side2); // len x width
                perimeter = Math.Round(2 * side1 + 2 * side2); // side + side2 + side + side 2
            } 
            catch (Exception e)
            {
                Console.WriteLine("An error ocurred, make sure you put in only two points for each vertex.");
                Console.WriteLine(e);
            }
        }
        public Rectangle()
        {
            name = "Null";
            Console.WriteLine("An empty shape has been created.");
        }
    }
}
