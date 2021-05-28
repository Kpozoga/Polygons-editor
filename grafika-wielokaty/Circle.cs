using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafika_wielokaty
{
    public class Circle
    {
        public double X,Y,R;
        //placeholder
        //not worth it
        //would need common base class with polygon class(not in existance)
        public Circle(double x, double y,double r)
        {
            X = x;
            Y = y;
            R = r;
        }
    }
}
