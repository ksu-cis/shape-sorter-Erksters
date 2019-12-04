using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun With Shapes!");

            List<IShape> shapes = new List<IShape>()
            {
                new Circle(4.0),
                new Rectangle(6,7),
                new Square(5.0),
                new Circle(3.0),
                new Rectangle(2,4),
                new Square(10.0),

            };

            foreach(IShape x in shapes)
            {
                Console.WriteLine($"Area of shape {x.ToString()} is {x.Area}");
            }

            Console.WriteLine("*****************");

            IEnumerable<IShape> filtered = shapes.Where(shape => shape.Area > 50);


            foreach (IShape x in filtered)
            {
                Console.WriteLine($"Area of shape {x.ToString()} is {x.Area}");
            }

            //Using is Keyword
            //IEnumerable<Circle> circles = shapes.Where(shape => shape is Circle);

            //Using GetType method
            //IEnumerable<Circle> circles = shapes.Where(shape => shape.GetType() == Circle);

            //Using OfType
            IEnumerable<Circle> circles = shapes.OfType<Circle>();
            Console.WriteLine("*****************");


            foreach (IShape x in circles)
            {
                Console.WriteLine($"Area of shape {x.ToString()} is {x.Area}");
            }

            IEnumerable<IShape>  superCircles  = shapes.OfType<Circle>().Where(circle => circle.Area < 30 && circle.Area > 20);

            Console.WriteLine("*****************");


            foreach (IShape x in superCircles)
            {
                Console.WriteLine($"Area of shape {x.ToString()} is {x.Area}");
            }

            Console.WriteLine("Group By Even Area");

            var Groupby = shapes.GroupBy(shape => shape.Area % 2 == 0);
            foreach(var group in Groupby)
            {
                foreach (var x in group)
                {
                    Console.WriteLine($"Shape with area {x.Area}");
                }
            }


            Console.WriteLine("*****************");

            Console.WriteLine("Group By Type");

            var GroupbyType = shapes.GroupBy(shape => shape.GetType());

            foreach (var group in GroupbyType)
            {
                Console.WriteLine($"Shapes of Type { group.Key.Name}");
                foreach (var x in group)
                {
                    Console.WriteLine($"    Shape with area {x.Area}");
                }
            }


        }
    }
}
