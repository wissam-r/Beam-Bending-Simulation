using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace forces
{
    public interface BeamForce : Force_
    {
        /// <summary>
        /// beam length should be in cm
        /// </summary>
        Double BeamLength { get; }
        /// <summary>
        /// return momentom at <code>distance</code> form the left
        /// </summary>
        /// <param name="distance">this should be in cm</param>
        double getMomentom(double distance);
        /// <summary>
        /// return shear at <code>distance</code> form the left
        /// </summary>
        /// <param name="distance">this should be in cm</param>
        double getShaer(double distance);
        /// <summary>
        /// return momentom Integration twice at <code>distance</code> form the left
        /// </summary>
        /// <param name="distance">this should be in cm</param>
        double getfMomentomd2x(double distance);
        /// <summary>
        /// return this force reflection at the <code>x</code>th support
        /// </summary>
        /// <param name="x">the order of the support form left</param>
        /// <exception cref="ArgumentOutOfRangeException">ArgumentOutOfRangeException if negative of exceed the supports number</exception>
        ReflectionBeamForce getReflection(int x); 
    }
}
