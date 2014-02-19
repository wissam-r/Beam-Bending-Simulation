using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using beam;
using forces;

namespace TestsForSC
{
    partial class jasam
    {
        private SinReinRecBeem myBeam;
        private Forces myForces;

        public double diflectionAt(double position){
            return myForces.getfMomentomd2x(position) / (myBeam.getIe(myForces.getMomentom(position)) * myBeam.EMC);
        }

        public double BeamLenght{get{return myBeam.L;}}
        public double BeamHeight { get { return myBeam.B; } }
        public double BeamE { get { return myBeam.EMC; } }

        public double MomentomAt(double position)
        {
            return myForces.getMomentom(position);
        }
        public double MaxMomentom
        {
            private set;
            get;
        }

        public double getNaturalSerfaceDepth()
        {
           return myBeam.X;
        }

        public double getIe(double ma)
        {
            return myBeam.getIe(ma);
        }
    }
}
