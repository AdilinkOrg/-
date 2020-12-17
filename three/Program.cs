using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using three.classes;

namespace three {
    class Program {
        static void Main(string[] args) {
            try {
                List<Point> points = new List<Point>();

                points.Add(new Point('a', 0, 0));
                points.Add(new Point('b', 1, 0));
                points.Add(new Point('c', 1, 1));
                points.Add(new Point('d', 0, 1));

                Rectangle rectangle = new Rectangle("abcd", points);

                Console.WriteLine(rectangle.GetArea().ToString());
            } catch (RectangleExeption ex) {
                Console.WriteLine(ex);
            }

            Console.ReadKey();
        }
    }
}
