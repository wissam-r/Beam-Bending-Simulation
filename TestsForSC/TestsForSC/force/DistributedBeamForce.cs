using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsForSC.force
{
    class DistributedBeamForce:Force 
    {
        private Double start;
        private Double end;

        public DistributedBeamForce(double power, double start, double end)
            : base(power)
        {
            this.start = start;
            this.end = end;
        }
        public override double getMomentom(double distance)
        {
            if (distance <= start)
                return 0;
            else
            {
                Double e;
                if (distance < end)
                    e = distance;
                else
                    e = end;
                return -Power * (Math.Pow(e, 2) / 2 - e * start + Math.Pow(start, 2) / 2) * factor;
            }
                
        }
        public override double getfMomentomd2x(double distance,double beamLength)
        {
            double A = Power * Math.Pow(beamLength - start, 4) / (24 * beamLength);
            
            if (distance <= start)
                return A * distance * factor;
            else
            {
                double all, sub = 0;
                all = Power * Math.Pow(distance - start, 4) / 24;
                if (distance > end)
                {
                    sub = Power * Math.Pow(distance - end, 4) / 24;
                    A += -Power * Math.Pow(beamLength - end, 4) / (24 * beamLength);
                }
                return (-(all - sub) + A * distance) * factor;
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
            return this.start == ((DistributedBeamForce)force).start
                && this.end == ((DistributedBeamForce)force).end;
        }


        public override ReflectionBeamForce getReflectionLeft(double BeamLenght)
        {
            return new ReflectionBeamForce(this.Power * ( Math.Pow(start, 2) - Math.Pow(end, 2) + 2 * BeamLenght * (end-start)) / (2 * BeamLenght),0);
        }

        public override ReflectionBeamForce getReflectionRight(double BeamLenght)
        {
            return new ReflectionBeamForce(this.Power * (Math.Pow(end, 2) - Math.Pow(start, 2)) / (2 * BeamLenght), BeamLenght);
        }
    }
}
