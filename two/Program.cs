using System;
using System.Collections.Generic;
using two.classes;
using two.interfaces;

namespace two {
    class Program {
        public static void ShowTree(List<Product<Mechanism<Detail>>> items) {
            foreach (var product in items) {
                Console.WriteLine(product.ToString());
                foreach (var subProduct in product.Items) {
                    Console.WriteLine(subProduct.ToString());
                    foreach (var subSubProduct in subProduct.Items) {
                        Console.WriteLine(subSubProduct.ToString());
                    }
                }
                Console.WriteLine();
            }
        }

        public static void CrateTree(Node<Product<Mechanism<Detail>>> node) {
            Random random = new Random();

            for (int i = 0; i < random.Next(3, 10); i++) {
                Product<Mechanism<Detail>> prod = new Product<Mechanism<Detail>>(DateTime.Now, i.ToString());
                prod.MinWorkCelsiusTemperature = random.Next(0, 500);
                prod.MaxWorkCelsiusTemperature = random.Next(500, 1000);
                node.addItem(prod);

                for (int j = 0; j < random.Next(1, 7); j++) {
                    Mechanism<Detail> mech = new Mechanism<Detail>(j.ToString(), j.ToString());
                    prod.addItem(mech);

                    for (int h = 0; h < random.Next(0, 4); h++) {
                        Detail det = new Detail(j.ToString(), j.ToString());
                        mech.addItem(det);
                    }
                }
            }
        }

        delegate int allMethod();

        static void Main(string[] args) {
            Node<Product<Mechanism<Detail>>> node = new Node<Product<Mechanism<Detail>>>("0", "1", "2");
            CrateTree(node);

            Console.WriteLine(node.ToString());

            ShowTree(node.Items);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            ShowTree(node.Find("Name", "2"));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Product<Mechanism<Detail>> prod = node.Find("Name", "2")[0];

            var temperature = (ISpecifications)prod;
            var cost = (IPrices)prod;

            Console.WriteLine(temperature.AvgValue());
            Console.WriteLine(cost.AvgValue());

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            allMethod methodsOne = temperature.AvgValue;
            allMethod methodsTwo = cost.AvgValue;
            allMethod methodsThree = methodsOne + methodsTwo;
            allMethod methodsFour = methodsThree - methodsTwo;

            Console.WriteLine("Invoking delegate one:");
            Console.WriteLine(methodsOne());
            Console.WriteLine("Invoking delegate two:");
            Console.WriteLine(methodsTwo());
            Console.WriteLine("Invoking delegate three:");
            Console.WriteLine(methodsThree());
            Console.WriteLine("Invoking delegate four:");
            Console.WriteLine(methodsFour());

            Console.ReadKey();
        }
    }
}
