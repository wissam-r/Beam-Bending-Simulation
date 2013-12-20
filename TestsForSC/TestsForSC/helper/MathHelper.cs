using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections ;

namespace TestsForSC.helper
{
    public class MathHelper
    {
        static public double sESDRP(double a,double b ,double c)//Solving the equation of second-degree And return the possitve one
        {
            double d;
            d = b * b - 4 * a * c;
            if (d < 0) 
            {
                throw new Exception();
            }
            else if (d == 0)
            {
                return (double)(-b / 2 * a);
                
            }
            else
            {
                return Math.Max((double)(-b + Math.Sqrt(d)) / 2 * a ,(double)(-b - Math.Sqrt(d)) / 2 * a);
                
            }
        }
    }
}
