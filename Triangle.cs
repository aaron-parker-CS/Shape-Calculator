using System;
using System.Collections.Generic;
using System.Text;

namespace hw3
{
    class Triangle : shape
    {
        private Point vert1;
        private Point vert2;
        private Point vert3;

        private double side1;
        private double side2;
        private double side3;

        public static double operator +(Triangle s1, Triangle s2)
        {
            return s1.area + s2.area;
        }

        public override void getArea()
        {
            Console.WriteLine("Area of " + this.name + ": " + this.area.ToString());
        }

        public override void getPerimeter()
        {
            Console.WriteLine("Perimeter of " + this.name + ": " + this.perimeter.ToString());
        }

        public override void isPointInsideArea(Point p)
        {
            // any point P inside of a Triangle T will create three triangles formed by two vertices and a side. the sum of the area of these triangles is equal to the area of the Triangle.
            // therefore if we make three new triangles and find their areas, the total area should be equal if the point is inside.
            Triangle t1 = new Triangle("trig1", this.vert1, this.vert2, p);
            Triangle t2 = new Triangle("trig2", p, this.vert2, this.vert3);
            Triangle t3 = new Triangle("trig3", p, this.vert1, this.vert3);
            double trigSum = t3.area + t2.area + t1.area;
            Console.WriteLine("Sum of triangles formed with point {0},{1}: {2}",p.x, p.y, trigSum);
            if(this.area >= trigSum)
            {
                Console.WriteLine("Point {0},{1} is inside of Triangle {2}.", p.x, p.y, this.name);
            } 
            else
            {
                Console.WriteLine("Point {0},{1} is not inside of Triangle {2}.", p.x, p.y, this.name);
            }
        }

        public Triangle(string n, Point v1, Point v2, Point v3)
        {
            name = n;
            try
            {
                /*
                 *          v2
                 *      /       \
                 *    v1 ________ v3
                 */
                vert1 = v1;
                vert2 = v2;
                vert3 = v3;
                side1 = getDistance(v3.x, v1.x, v3.y, v1.y); // base
                side2 = getDistance(v2.x, v1.x, v2.y, v1.y);
                side3 = getDistance(v3.x, v2.x, v3.y, v2.y);
                area = Math.Round(heronFormula(side1, side2, side3));
                perimeter = side1 + side2 + side3;
            }
            catch(Exception e)
            {
                Console.WriteLine("An exception occurred. Ensure you input all information correctly.");
                Console.WriteLine(e);
            }
        }
        public Triangle()
        {
            name = "Null";
            Console.WriteLine("An empty Triangle has been created.");
        }

    }
}
