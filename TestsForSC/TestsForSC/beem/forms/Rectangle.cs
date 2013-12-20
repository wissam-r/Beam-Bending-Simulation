using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsForSC.beem.forms
{
    class Rectangle : Form
    {
        public Rectangle(double h, double l, double b) { 
            H = h;
            B = b;
            L = l;
        }
        double l, h, b; //
        public double crossSectionalArea()
        {
            return H * B;
        }

        

        public double L
        {
            get { return l; }
            set { l = value; }
        }

        public double H
        {
            get { return h; }
            set { h = value; }
        }

        public double B
        {
            get { return b; }
            set { b = value; }
        }
    }
}
