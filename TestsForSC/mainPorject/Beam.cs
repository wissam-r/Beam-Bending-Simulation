using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using beam;
using forces;

namespace mainPorject
{
    public class Beam
    {
        private RenforcedBeem beam;
        private Forces forces;

        public double Width { 
            get{
                throw new NotImplementedException();
            }
        }
        public double Height {
            get
            {
                throw new NotImplementedException();
            }
        }
        public double Length{get{return beam.L;}}

        public double MaxMomentom{
            get
            {
                throw new NotImplementedException();
            }
        }
        
        public double getDiflectionAt(double position){
            return forces.getfMomentomd2x(position, Length) / (beam.getIe(forces.getMomentom(position)) * beam.EMC);
        }
        public double getMomentomAt(double position)
        {
            return forces.getMomentom(position);
        }
    }
}
