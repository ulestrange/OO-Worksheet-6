using System;
using System.Collections.Generic;
using System.Text;

namespace Circle
{
    class Circle
    {
        private double _radius;
        //temp


        // define a public property Radius
        public double Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }


        public Circle ()
        {
            _radius = 1;
        }

        public Circle (double r)
        {
            _radius = r;
        }

        /* This returns the area of the circle
         */

        public double GetArea()
        {
            return Math.PI * _radius * _radius;
        }

        public override string  ToString()
        {
            return String.Format("The radius of this circle is {0}", _radius);
        }
       
    }
}
