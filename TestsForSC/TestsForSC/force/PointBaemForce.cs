using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsForSC.force
{
    class PointBaemForce : Force 
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
                return (distance - Position) * Power;
            }
        }

        public override double getfMomentomd2x(double distance,double beamLength)
        {
            if (distance <= Position)
                return 0;
            else{
                double A = -Power * Math.Pow(beamLength - Position, 3) / (6*beamLength);
                return Power * Math.Pow(distance - Position, 3) / 6 + A*distance;
            }
        }
        public override void add(Force force)
        {
            if (this.canAdd(force))
                base.add(force);
        }
        public override bool canAdd(Force force)
        {
            if (!base.canAdd(force)) return false;
            return this.Position == ((PointBaemForce)force).Position;
        }
    }
}
