using System;
using System.Collections.Generic;
using System.Text;

namespace Circle
{
    class Circle
    {
        private double radius;
        //temp


        // define a public property Radius
        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }


        public Circle ()
        {
            radius = 1;
        }

        public Circle (double r)
        {
            radius = r;
        }

        /* This returns the area of the circle
         */

        public double GetArea()
        {
            return Math.PI * radius * radius;
        }

        public override string  ToString()
        {
            return String.Format("The radius of this circle is {0}", radius);
        }
       
    }
}
