using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace forces
{
    public class PointBaemForce : Force , BeamForce  
    {
        private double position;
        private Double beamLength;
        public  Double BeamLength
        {
            get { return beamLength; }
        }
        public PointBaemForce(double power, double position,Double beamLenght)
            : base(power)
        {
            this.position = position;
            this.beamLength = beamLenght;
            calculReflectionLeft();
            calculReflectionRight();
        }
        protected PointBaemForce(double power, double position, Double beamLenght,bool calc)
            : base(power)
        {
            this.position = position;
            this.beamLength = beamLenght;
            if (calc)
            {
                calculReflectionLeft();
                calculReflectionRight();
            }
        }
        public virtual double getMomentom(double distance)
        {
            if (distance <= position)
                return 0;
            else
            {
                return -(distance - position) * Power * factor;
            }
        }
        public virtual double getShaer(double distance)
        {
            if (distance <= position)
            {
                return ReflectionLeft.Power;
            }
            else/* if (distance > position*/
            {
                return -ReflectionRight.Power;
            }
        }
        public virtual double getfMomentomd2x(double distance)
        {
            
            double A = Power * Math.Pow(beamLength - position, 3) / (6 * beamLength);
            if (distance <= position)
                return A * distance * factor;
            else{                
                return (-Power * Math.Pow(distance - position, 3) / 6 + A*distance)*factor;
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
            return this.position == ((PointBaemForce)force).position;
        }

        private ReflectionBeamForce ReflectionLeft;
        private void calculReflectionLeft()
        {
            ReflectionLeft = new ReflectionBeamForce(this.Power * (BeamLength - this.position) / BeamLength, 0,beamLength);
        }
        private ReflectionBeamForce ReflectionRight;
        private void calculReflectionRight()
        {
            ReflectionRight = new ReflectionBeamForce(this.Power * this.position / BeamLength, 0,beamLength);
        }

        public virtual ReflectionBeamForce getReflection(int x)
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
