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
                return Power * (Math.Pow(e, 2) / 2 - e * start + Math.Pow(start, 2) / 2);
            }
                
        }
        public override double getfMomentomd2x(double distance,double beamLength)
        {
            if (distance <= start)
                return 0;
            else
            {
                double all, sub=0;
                all = Power * Math.Pow(distance - start, 4) / 24;
                double A = -Power * Math.Pow(beamLength - start, 4) / (24 * beamLength);
                if (distance > end)
                {
                    sub = Power * Math.Pow(distance - end, 4) / 24;
                    A += Power * Math.Pow(beamLength - end, 4) / (24 * beamLength);
                }
                return all - sub + A * beamLength;
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
            return this.start == ((DistributedBeamForce)force).start
                && this.end == ((DistributedBeamForce)force).end;
        }
        
    }
}
