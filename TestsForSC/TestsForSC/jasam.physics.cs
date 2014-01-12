using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsForSC
{
    partial class jasam
    {
        private beem.SinReinRecBeem myBeam;
        private force.Forces myForces;

        public double diflectionAt(double position){
            return myForces.getfMomentomd2x(position, myBeam.L) / (myBeam.getIe(myForces.getMomentom(position)) * myBeam.EMC);
        }

        public double BeamLenght{get{return myBeam.L;}}

        public double MomentomAt(double position)
        {
            return myForces.getMomentom(position);
        }
        public double MaxMomentom
        {
            private set;
            get;
        }
    }
}
