using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using beam;
using forces;

namespace mainPorject
{
    public class BeamWrapper
    {
        public RenforcedBeem beam;
        public Forces forces;

        public double Width { 
            get{
                return beam.B;
            }
        }
        public double Height {
            get
            {
                if (beam.Form is beam.forms.Rectangle)
                {
                    return beam.Form.crossSectionalArea() / Width;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }
        public double Length{get{return beam.L;}}

        public double MaxMomentom
        {
            get
            {
                return beam.ERM;
            }
        }
        public double E
        {
            get
            {
                return beam.EMC;
            }
        }
        
        public double getDiflectionAt(double position){
            return forces.getfMomentomd2x(position) / (beam.getIe(forces.getMomentom(position)) * beam.EMC);
        }

        public double getShaer(double position)
        {
            return forces.getShaer(position);
        }
        public double getMomentomAt(double position)
        {
            return forces.getMomentom(position);
        }

        public double getNaturalSerfaceDepth()
        {
            if (beam is SinReinRecBeem)
            {
                return (beam as SinReinRecBeem).X;
            }
            else if (beam is DoubReinRecBeem)
            {
                return (beam as DoubReinRecBeem).X;
            }
            else throw new NotImplementedException();
        }
        public double getI(double position)
        {
            return beam.getIe(forces.getMomentom(position));
        }

        public PointBaemForce F1,F2;
    }
}
