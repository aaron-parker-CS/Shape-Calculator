using System;
using System.Collections.Generic;

namespace hw3
{
    class hw3
    {
        static public Rectangle makeRectangle()
        {
            try
            {
                Console.WriteLine("Enter your rectangle's name: ");
                string rName = Console.ReadLine();
                Console.WriteLine("Enter the lower left vertex coordinate seperated by a comma [#,#]: "); // v1 is the bottom left corner, every polygon in this program is set up for the bottom left vertex and goes clockwise
                string[] vertex1 = Console.ReadLine().Split(','); // so we read the console line and split it amongst the comma characters and store that in an array so we can convert the array
                Point v1 = new Point(Array.ConvertAll(vertex1, s => double.Parse(s))); // what we're doing here is taking the array from the following line and then parsing its indices and converting it to double values. if the array has things that aren't numbers it'll throw a typeException
                Console.WriteLine("Enter the top right vertex coordinate seperated by a comma [#,#]");
                string[] vertex2 = Console.ReadLine().Split(',');
                Point v2 = new Point(Array.ConvertAll(vertex2, s => double.Parse(s)));
                Rectangle newRect = new Rectangle(rName, v1, v2); // so we take all of that info and make a new rectangle :)
                newRect.getArea();
                newRect.getPerimeter();
                //Point testPoint = new Point(2, 2);
                //newRect.isPointInsideArea(testPoint);
                // the above lines were used for testing in the first version of the program
                return newRect;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Input value too large for type Double.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Input value not understood. Make sure you only put in double values seperated by a comma.");
            }
            catch (Exception e)
            {
                Console.WriteLine("An unknown exception occurred.");
                Console.WriteLine(e);
            }
            Rectangle missingRect = new Rectangle();
            return missingRect;
        }
        static public Triangle makeTriangle()
        {
            try
            {
                // this is essentially a copy of the above method
                Console.WriteLine("Enter your Triangle's name: ");
                string tName = Console.ReadLine();
                Console.WriteLine("Enter the lower left vertex coordinate seperated by a comma [#,#]: ");
                string[] vertex1 = Console.ReadLine().Split(',');
                Point v1 = new Point(Array.ConvertAll(vertex1, s => double.Parse(s)));
                Console.WriteLine("Enter the top vertex coordinate seperated by a comma [#,#]");
                string[] vertex2 = Console.ReadLine().Split(',');
                Point v2 = new Point(Array.ConvertAll(vertex2, s => double.Parse(s)));
                Console.WriteLine("Enter the lower right vertex coordinate seperated by a comma [#,#]");
                string[] vertex3 = Console.ReadLine().Split(',');
                Point v3 = new Point(Array.ConvertAll(vertex3, s => double.Parse(s)));
                // for the above lines, we take the input, split it, convert it to double and then store it in a new point structure.  we then put this in our new Triangle
                Triangle newTrig = new Triangle(tName, v1, v2, v3);
                //Point testPoint = new Point(2, 2);
                newTrig.getArea();
                newTrig.getPerimeter();
                //newTrig.isPointInsideArea(testPoint);
                return newTrig;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Input value too large for type Double.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Input value not understood. Make sure you only put in double values seperated by a comma.");
            }
            catch (Exception e)
            {
                Console.WriteLine("An unknown exception occurred.");
                Console.WriteLine(e);
            }
            Triangle missingTrig = new Triangle();
            return missingTrig;
        }
        static public Circle makeCircle()
        {
            try
            {
                // again, copy of the above two, this method will not be annotated
                Console.WriteLine("Enter your circle's name: ");
                string cName = Console.ReadLine();
                Console.WriteLine("Enter circle center x coordinate: ");
                double cX = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter circle center y coordinate: ");
                double cY = Convert.ToDouble(Console.ReadLine());
                Point cPoint = new Point(cX, cY);
                Console.WriteLine("Enter Radius: ");
                double cR = Convert.ToDouble(Console.ReadLine());
                Circle newCirc = new Circle(cName, cPoint, cR);
                newCirc.getArea();
                newCirc.getPerimeter();
                return newCirc;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Input value too large for type Double.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Input value not understood. Make sure you only put in integer values.");
            }
            catch (Exception e)
            {
                Console.WriteLine("An unknown exception occurred.");
                Console.WriteLine(e);
            }
            Circle missingCircle = new Circle();
            return missingCircle;
        }

        public static void addTrigs(List<Triangle> Shapes)
        {
            // so to add two shapes, we have seperate methods.  I could not figure out how to make generic lists work with multiple types of objects.
            try
            {
                if (Shapes.Count < 2) // we need two shapes to add together
                    throw new Exception("You don't have enough shapes to add!");
                Console.WriteLine("Enter the name of the first shape: ");
                string shape1 = Console.ReadLine().ToLower();
                Console.WriteLine("Enter the name of the second shape: ");
                string shape2 = Console.ReadLine().ToLower();
                // we use toLower to make it consistent searching
                int ind1 = Shapes.FindIndex(shape => shape.Name.Contains(shape1));
                int ind2 = Shapes.FindIndex(shape => shape.Name.Contains(shape2));
                // the above variables find the indices of the user input.  an IndexOutOfRangeException will be thrown if the name is incorrect
                double area = Shapes[ind1] + Shapes[ind2];
                // add the areas using the defined overload and then print it to console
                Console.WriteLine("Area of {0} plus {1} is {2}", shape1, shape2, area);

            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Input shape not found! Are you sure you have the correct name?");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void addCircs(List<Circle> Shapes)
        {
            try
            {
                // copy of the above method
                if (Shapes.Count < 2)
                    throw new Exception("You don't have enough shapes to add!");
                Console.WriteLine("Enter the name of the first shape: ");
                string shape1 = Console.ReadLine().ToLower();
                Console.WriteLine("Enter the name of the second shape: ");
                string shape2 = Console.ReadLine().ToLower();
                int ind1 = Shapes.FindIndex(shape => shape.Name.Contains(shape1));
                int ind2 = Shapes.FindIndex(shape => shape.Name.Contains(shape2));
                double area = Shapes[ind1] + Shapes[ind2];
                Console.WriteLine("Area of {0} plus {1} is {2}", shape1, shape2, area);
                
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Input shape not found! Are you sure you have the correct name?");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void addRects(List<Rectangle> Shapes)
        {
            try
            {
                // copy of the above method
                if (Shapes.Count < 2)
                    throw new Exception("You don't have enough shapes to add!");
                Console.WriteLine("Enter the name of the first shape: ");
                string shape1 = Console.ReadLine().ToLower();
                Console.WriteLine("Enter the name of the second shape: ");
                string shape2 = Console.ReadLine().ToLower();
                int ind1 = Shapes.FindIndex(shape => shape.Name.Contains(shape1));
                int ind2 = Shapes.FindIndex(shape => shape.Name.Contains(shape2));
                double area = Shapes[ind1] + Shapes[ind2];
                Console.WriteLine("Area of {0} plus {1} is {2}", shape1, shape2, area);
                
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Input shape not found! Are you sure you have the correct name?");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void testPoint(List<shape> Shapes)
        {
            try
            {
                // method to test points inside of shapes
                Console.WriteLine("Enter the point you would like to test: ");
                string[] pointString = Console.ReadLine().Split(','); // take user input and makes it a point
                Point p = new Point(Array.ConvertAll(pointString, s => double.Parse(s)));
                Console.WriteLine("Enter the shape you would like to test: "); // ask the user to enter the shape they want to test
                string input = Console.ReadLine().ToLower();
                foreach (var shape in Shapes) // linear scan
                {
                    if(shape.Name.ToLower() == input) // search for the shape to test
                    {
                        shape.isPointInsideArea(p);
                        return;
                    }
                }
                // if no shape is found, this line will execute
                Console.WriteLine("No matching entry in the shape list found, are you sure you typed the name correctly?");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Input too large for type Double.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Make sure you're typing only Double values seperated by a comma.");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the shape calculator.\n" +
                "Currently supported shapes are: Rectangle, Triangle, and Circle.\n");
            List<shape> ShapeList = new List<shape>();
            List<Rectangle> RectList = new List<Rectangle>();
            List<Circle> CircList = new List<Circle>();
            List<Triangle> TrigList = new List<Triangle>();
            // since we need to access shapes to test points and add areas apparently i want to have a list of objects, i couldn't figure out generics to make it work with just one list
            string input;
            while (true)
            {
                // looping shape menu
                Console.WriteLine("Input which shape you'd like to make: ");
                input = Console.ReadLine().ToLower(); // put the input in lowercase so we don't have to distinguish between RECTANGLE and rectangle
                switch (input)
                {
                    case "rect":
                    case "rectangle":
                        Rectangle newRectangle = makeRectangle();
                        ShapeList.Add(newRectangle);
                        RectList.Add(newRectangle);
                        // make the new rectangle and store it into the above lists.  the below lines are copies for different shapes
                        break;
                    case "trig":
                    case "triangle":
                        Triangle newTriangle = makeTriangle();
                        ShapeList.Add(newTriangle);
                        TrigList.Add(newTriangle);
                        break;
                    case "circ":
                    case "circle":
                        Circle newCircle = makeCircle();
                        ShapeList.Add(newCircle);
                        CircList.Add(newCircle);
                        break;
                    case "quit":
                    case "q":
                        Environment.Exit(0);
                        // quit the loop and exit the program
                        break;
                    default:
                        Console.WriteLine("Input not understood, make sure that you type 'circle', 'rectangle' or 'Triangle'."); 
                        // and something to make it so that it's clear if input is invalid
                        break;
                }
                Console.WriteLine("The current list of shapes are: ");
                foreach(var shape in ShapeList) // linear scan of the overarching shapes list to show the current amount of shapes
                {
                    Console.Write(shape.Name + ", ");
                }
                bool choosing = true; // a second looping menu to allow the user to make decisions on what they want to do next
                while (choosing)
                {
                    Console.WriteLine("Would you like to [TEST] a point, [ADD] shape areas, or [CREATE] a new shape?");
                    input = Console.ReadLine().ToLower();
                    switch (input)
                    {
                        case "test":
                            testPoint(ShapeList); // test a point method
                            break;
                        case "add":
                            Console.WriteLine("What type of shape would you like to add?"); // ask what types of shapes want to be added together
                            string userInput = Console.ReadLine().ToLower();
                            switch (userInput)
                            {
                                case "trig":
                                case "triangle":
                                    addTrigs(TrigList);
                                    break;
                                case "rect":
                                case "rectangle":
                                    addRects(RectList);
                                    break;
                                case "circ":
                                case "circle":
                                    addCircs(CircList);
                                    break;
                                default:
                                    Console.WriteLine("Input not understood, type only 'triangle', 'circle', or 'rectangle'. Returning...");
                                    break;
                            }
                            break;
                        case "create":
                            choosing = false; // loop back to the main menu to create a new shape
                            break;
                        case "q":
                        case "quit":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Input not understood, type only 'test', 'add', 'create', or 'quit'.");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
