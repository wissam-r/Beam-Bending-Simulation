using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace forces
{
    public class ReflectionBeamForce : PointBaemForce
    {
        #region variables
        //variables
        private bool isleft;
        //variables end
        #endregion

        public ReflectionBeamForce(double power, double position, Double beamLength)
            :base(power,position,beamLength,false)
        {
            this.isleft = position==0;
        }

        #region BeamForce override
        //BeamForce override
        /// <summary>
        /// return momentom at <code>distance</code> form the left
        /// </summary>
        /// <param name="distance">this should be in cm</param>
        public override double getMomentom(double distance)
        {
            if (!isleft)
                return 0;
            else
            {
                return distance * Power * factor;
            }
        }
        /// <summary>
        /// return shear at <code>distance</code> form the left
        /// </summary>
        /// <param name="distance">this should be in cm</param>
        public override double getShaer(double distance)
        {
            return 0;
        }
        /// <summary>
        /// return momentom Integration twice at <code>distance</code> form the left
        /// </summary>
        /// <param name="distance">this should be in cm</param>
        public override double getfMomentomd2x(double distance)
        {
            if (!isleft)
                return 0;
            else{
                double A = -Power * Math.Pow(BeamLength , 2) / (6) ;
                return (Power * Math.Pow(distance , 3) / 6 + A*distance) * factor;
            }
        }
        /// <summary>
        /// return this force reflection at the <code>x</code>th support
        /// </summary>
        /// <param name="x">the order of the support form left</param>
        /// <exception cref="ArgumentOutOfRangeException">ArgumentOutOfRangeException if negative of exceed the supports number</exception>
        public override ReflectionBeamForce getReflection(int x)
        {
            return null;
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
                base.add(force);
        }
        /// <summary>
        /// check to see if you can add <code>force</code> to this force
        /// </summary>
        /// <param name="force">the force to be checked</param>
        /// <returns>true if true</returns>
        public override bool canAdd(Force_ force)
        {
            if (!base.canAdd(force)) return false;
            return this.isleft == ((ReflectionBeamForce)force).isleft;
        }
        //Force override
        #endregion
    }
}
