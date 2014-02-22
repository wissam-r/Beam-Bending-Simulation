using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace forces
{
    public class DistributedBeamForce:Force ,BeamForce
    {
        private Double start;
        private Double end;
        private Double beamLength;

        public DistributedBeamForce(double power, double start, double end,Double beamLength)
            : base(power)
        {
            this.start = start;
            this.end = end;
            this.beamLength = beamLength;
            calculReflectionLeft();
            calculReflectionRight();
        }
        public double getMomentom(double distance)
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
                return -Power * (distance*(e - start) - Math.Pow(e, 2) / 2 + Math.Pow(start, 2) / 2) * factor;
            }
                
        }
        public double getShaer(double distance)
        {
            if (distance <= start)
            {
                return ReflectionLeft.Power;
            }
            else if (distance >= end)
            {
                return -ReflectionRight.Power;
            }
            else /* if (start < distance < end*/
            {
                return (ReflectionLeft.Power + ReflectionRight.Power) / (start - end) * (distance - start) + ReflectionLeft.Power;
            }
        }
        public double getfMomentomd2x(double distance)
        {
            double A = Power * Math.Pow(beamLength - start, 4) / (24 * beamLength);
                    A += -Power * Math.Pow(beamLength - end, 4) / (24 * beamLength);
            if (distance <= start)
                return A * distance * factor;
            else
            {
                double all, sub = 0;
                all = Power * Math.Pow(distance - start, 4) / 24;
                if (distance > end)
                {
                    sub = Power * Math.Pow(distance - end, 4) / 24;
                }
                return (-(all - sub) + A * distance) * factor;
            }

        }
        public override void add(Force_ force)
        {
            if (this.canAdd(force))
            {
                base.addPower(force);
                calculReflectionRight();
                calculReflectionLeft();
            }
        }
        public override bool canAdd(Force_ force)
        {
            if (!base.sameType(force)) return false;
            return this.start == ((DistributedBeamForce)force).start
                && this.end == ((DistributedBeamForce)force).end;
        }

        public double BeamLength
        {
            get { return beamLength; }
        }
        public double Start
        {
            get { return start; }
        }
        public double End
        {
            get { return end; }
        }

        private ReflectionBeamForce ReflectionLeft;
        private void calculReflectionLeft()
        {
            ReflectionLeft = new ReflectionBeamForce(this.Power * (Math.Pow(start, 2) - Math.Pow(end, 2) + 2 * BeamLength * (end - start)) / (2 * BeamLength), 0,beamLength);
        }
        private ReflectionBeamForce ReflectionRight;
        private void calculReflectionRight()
        {
            ReflectionRight = new ReflectionBeamForce(this.Power * (Math.Pow(end, 2) - Math.Pow(start, 2)) / (2 * BeamLength), BeamLength,beamLength);
        }
        public ReflectionBeamForce getReflection(int x)
        {
            switch (x)
            {
                case 0: return ReflectionLeft;
                //break;
                case 1: return ReflectionRight;
                //break;
            }
            throw new ArgumentOutOfRangeException("x", x, "x is to be in [0,1]");
        }
    }
}
