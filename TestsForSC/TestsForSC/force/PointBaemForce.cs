using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsForSC.force
{
    public class PointBaemForce : Force 
    {
        private double Position;
        
        public PointBaemForce(double power, double position)
            : base(power)
        {
            this.Position = position;
        }
        public override double getMomentom(double distance)
        {
            if (distance <= Position)
                return 0;
            else
            {
                return -(distance - Position) * Power * factor;
            }
        }

        public override double getfMomentomd2x(double distance,double beamLength)
        {
            
            double A = Power * Math.Pow(beamLength - Position, 3) / (6 * beamLength);
            if (distance <= Position)
                return A * distance * factor;
            else{                
                return (-Power * Math.Pow(distance - Position, 3) / 6 + A*distance)*factor;
            }
        }
        public override void add(Force force)
        {
            if (this.canAdd(force))
                base.addPower(force);
        }
        public override bool canAdd(Force force)
        {
            if (!base.sameType(force)) return false;
            return this.Position == ((PointBaemForce)force).Position;
        }

        public override ReflectionBeamForce getReflectionLeft(double BeamLenght)
        {
            return new ReflectionBeamForce(this.Power * (BeamLenght - this.Position) / BeamLenght, 0);
        }

        public override ReflectionBeamForce getReflectionRight(double BeamLenght)
        {
            return new ReflectionBeamForce(this.Power * this.Position / BeamLenght, 0);
        }
    }
}
