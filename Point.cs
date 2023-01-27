using System;
using System.Collections.Generic;
using System.Text;

namespace hw3
{
    // I know this struct is strictly unnecessary but it makes the code a lot more readable and easier for me to understand
    struct Point
    {
        public double x;
        public double y;

        public Point(double a, double b)
        {
            this.x = a;
            this.y = b;
        }
        public Point(double[] p)
        {
            this.x = p[0];
            this.y = p[1];
            if (p.Length >= 3)
                // i don't really want to set up converting more than just the two entries in an input into a point, so I'm letting the user know if their array has more than 3 entries then i'm cutting off data.
                Console.WriteLine("Lost data converting array to point!");
        }
    }
}
