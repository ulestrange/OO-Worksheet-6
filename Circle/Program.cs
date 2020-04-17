using System;

namespace Circle
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle[] myCircles = new Circle[4];

            for (int i = 0; i < 4; i++)
            {
                myCircles[i] = new Circle();
            }

            myCircles[0].Radius = 10;
            myCircles[2].Radius = 10;

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(myCircles[i].ToString() );
            }

            Console.WriteLine("The first circle has an area of {0}", myCircles[0].GetArea());
            Console.WriteLine("The fourth circle has an area of {0}", myCircles[3].GetArea());
        }
    }
}
