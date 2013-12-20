using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsForSC.beem.forms
{
    class Rectangle : Form
    {
        double l, h, b; // h : high  , l : Length , b : width

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

        public Rectangle(double h, double l, double b) { 
            H = h;
            B = b;
            L = l;
        }
 
        public double crossSectionalArea()
        {
            return H * B;
        }

        


        public double distanceCenterGravity()
        {
            return H / 2.0; 
        }


        public double momentInertiaNonCrackedSection()
        {
            return B * Math.Pow(H, 3) / 12;
        }
    }
}
