using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dance_konkurrence
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variables af dancing point
            int FirstDancerPoint;
            int SecondDancerPoint;

            //Jeg har brugt do while loop kun til se, hvordan det virker i den program. 
            //do
            {
                // Data ind 
                Console.WriteLine("Skriver 1 danser navn og point");
                string FirstDancerName = Console.ReadLine();
                int.TryParse(Console.ReadLine(), out FirstDancerPoint);

                Console.WriteLine("Skriver 2 danser navn og point");
                string SecondDancerName = Console.ReadLine();
                int.TryParse(Console.ReadLine(), out SecondDancerPoint);

                DancerPoints Dancer1 = new DancerPoints(FirstDancerName, FirstDancerPoint);
                DancerPoints Dancer2 = new DancerPoints(SecondDancerName, SecondDancerPoint);

                // beregning
                DancerPoints result = Dancer1 + Dancer2;

                // Print output
                Console.WriteLine($"Dancer: {result.Name} - Points: {result.Point}");

            }
            Console.ReadLine();
            //while (true);
        }

        class DancerPoints
        //properties Method and klasses
        {
            public string Name { get; set; }
            public int Point { get; set; }
            public DancerPoints()
            {

            }
            public DancerPoints(string name, int point)

            {
                Name = name;
                Point = point;
            }

            public static DancerPoints operator +(DancerPoints Dancer1, DancerPoints Dancer2)
            {
                // Combine result
                DancerPoints result = new DancerPoints();
                result.Name = Dancer1.Name + " " + "&" + " " + Dancer2.Name;
                result.Point = Dancer1.Point + Dancer2.Point;
                return result;
            }

        }
    }
}
