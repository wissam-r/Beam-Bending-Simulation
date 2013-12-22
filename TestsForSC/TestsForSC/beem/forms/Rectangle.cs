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
        }
        public double H
        {
            get { return h; }
        }
        public double B
        {
            get { return b; }
        }
        double A;//crossSectionalArea
        double Yt;//distanceCenterGravity
        double Ig;//momentInertiaNonCrackedSection

        public Rectangle(double h, double l, double b) { 
            this.h = h;
            this.b = b;
            this.l = l;
            this.A = this.h * this.b;
            this.Yt = h / 2.0;
            this.Ig = this.b * Math.Pow(this.h, 3) / 12; 

        }
        public double crossSectionalArea()
        {
            return A;
        }
        public double distanceCenterGravity()
        {
            return Yt; 
        }
        public double momentInertiaNonCrackedSection()
        {
            return Ig;
        }
    }
}
