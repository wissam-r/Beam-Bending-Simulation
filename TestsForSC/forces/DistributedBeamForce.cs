using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace forces
{
    public class DistributedBeamForce:Force ,BeamForce
    {
        #region variables
        //variables
        private Double start;
        private Double end;
        private Double beamLength;
        /// <summary>
        /// beam length should be in cm
        /// </summary>
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
        private ReflectionBeamForce ReflectionRight;
        //variables end
        #endregion

        public DistributedBeamForce(double power, double start, double end,Double beamLength)
            : base(power)
        {
            this.start = start;
            this.end = end;
            this.beamLength = beamLength;
            calculReflectionLeft();
            calculReflectionRight();
        }

        #region BeamForce override
        //BeamForce override
        /// <summary>
        /// return momentom at <code>distance</code> form the left
        /// </summary>
        /// <param name="distance">this should be in cm</param>
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
        /// <summary>
        /// return shear at <code>distance</code> form the left
        /// </summary>
        /// <param name="distance">this should be in cm</param>
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
        /// <summary>
        /// return momentom Integration twice at <code>distance</code> form the left
        /// </summary>
        /// <param name="distance">this should be in cm</param>
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
        /// <summary>
        /// return this force reflection at the <code>x</code>th support
        /// </summary>
        /// <param name="x">the order of the support form left</param>
        /// <exception cref="ArgumentOutOfRangeException">ArgumentOutOfRangeException if negative of exceed the supports number</exception>
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
        //BeamForce override
        #endregion

        #region Force_ override
        //Force_ override
        /// <summary>
        /// add force to this force if <code>canAdd(force)</code> is true
        /// </summary>
        /// <param name="force">the force to be added</param>
        /// <seealso cref="canadd"/>"
        public override void add(Force_ force)
        {
            if (this.canAdd(force))
            {
                base.addPower(force);
                calculReflectionRight();
                calculReflectionLeft();
            }
        }
        /// <summary>
        /// check to see if you can add <code>force</code> to this force
        /// </summary>
        /// <param name="force">the force to be checked</param>
        /// <returns>true if true</returns>
        public override bool canAdd(Force_ force)
        {
            if (!base.sameType(force)) return false;
            return this.start == ((DistributedBeamForce)force).start
                && this.end == ((DistributedBeamForce)force).end;
        }
        //Force_ override
        #endregion
                
        #region reflection
        //reflection
        private void calculReflectionLeft()
        {
            ReflectionLeft = new ReflectionBeamForce(this.Power * (Math.Pow(start, 2) - Math.Pow(end, 2) + 2 * BeamLength * (end - start)) / (2 * BeamLength), 0, beamLength);
        }
        private void calculReflectionRight()
        {
            ReflectionRight = new ReflectionBeamForce(this.Power * (Math.Pow(end, 2) - Math.Pow(start, 2)) / (2 * BeamLength), BeamLength,beamLength);
        }
        
        //reflection end
        #endregion
    }
}
