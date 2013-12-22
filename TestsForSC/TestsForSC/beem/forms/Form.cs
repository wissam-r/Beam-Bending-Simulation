using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsForSC.beem.forms
{
    interface Form
    {
        double crossSectionalArea(); //Area Calculation
        double distanceCenterGravity();// Distance from the center of gravity
        double momentInertiaNonCrackedSection();//Moment inertia non-cracked section

    }
}
