using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace forces
{
    public class PointBaemForce : Force , BeamForce
    {
        #region variables
        //variables
        private double position;
        public Double Position
        {
            get { return position; }
            //set { position = value; }
        }
        private Double beamLength;
        /// <summary>
        /// beam length should be in cm
        /// </summary>
        public  Double BeamLength
        {
            get { return beamLength; }
        }


        private ReflectionBeamForce ReflectionLeft;
        private ReflectionBeamForce ReflectionRight;
        //variables
        #endregion

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

        #region BeamForce override
        //BeamForce override
        /// <summary>
        /// return momentom at <code>distance</code> form the left
        /// </summary>
        /// <param name="distance">this should be in cm</param>
        public virtual double getMomentom(double distance)
        {
            if (distance <= position)
                return 0;
            else
            {
                return -(distance - position) * Power * factor;
            }
        }
        /// <summary>
        /// return shear at <code>distance</code> form the left
        /// </summary>
        /// <param name="distance">this should be in cm</param>
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
        /// <summary>
        /// return momentom Integration twice at <code>distance</code> form the left
        /// </summary>
        /// <param name="distance">this should be in cm</param>
        public virtual double getfMomentomd2x(double distance)
        {
            
            double A = Power * Math.Pow(beamLength - position, 3) / (6 * beamLength);
            if (distance <= position)
                return A * distance * factor;
            else{                
                return (-Power * Math.Pow(distance - position, 3) / 6 + A*distance)*factor;
            }
        }
        /// <summary>
        /// return this force reflection at the <code>x</code>th support
        /// </summary>
        /// <param name="x">the order of the support form left</param>
        /// <exception cref="ArgumentOutOfRangeException">ArgumentOutOfRangeException if negative of exceed the supports number</exception>
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
        //BeamForce override end
        #endregion

        #region Force_ override 
        //Force override 
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
            return this.position == ((PointBaemForce)force).position;
        }
        //Force override end
        #endregion

        #region reflection
        //reflection
        private void calculReflectionLeft()
        {
            ReflectionLeft = new ReflectionBeamForce(this.Power * (BeamLength - this.position) / BeamLength, 0,beamLength);
        }
        private void calculReflectionRight()
        {
            ReflectionRight = new ReflectionBeamForce(this.Power * this.position / BeamLength, 0,beamLength);
        }
        //reflection end
        #endregion
    }
}
