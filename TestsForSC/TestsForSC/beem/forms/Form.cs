using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsForSC.beem.forms
{
    interface Form
    {
        public double crossSectionalArea(); //Area Calculation
        public double distanceCenterGravity();// Distance from the center of gravity
        public double momentInertiaNonCrackedSection();//Moment inertia non-cracked section

    }
}
