using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace forces
{
    public abstract class Force : Force_
    {
        #region variables
        //variables
        public const int factor = 1;//للتحويل بين الواحدات
        /// <summary>
        /// the power of the force should be in newten
        /// </summary>
        public double Power { set; get; }
        //variables end
        #endregion

        public Force(double power)
        {
            Power = power;
        }

        
        protected void addPower(Force_ force)
        {
            this.Power += force.Power;
        }

        protected bool sameType(Force_ force)
        {
            return this.GetType() == force.GetType();
        }

        #region Force_ override
        //Force_ override
        /// <summary>
        /// add force to this force if <code>canAdd(force)</code> is true
        /// </summary>
        /// <param name="force">the force to be added</param>
        /// <seealso cref="canadd"/>"
        public abstract void add(Force_ force);
        /// <summary>
        /// check to see if you can add <code>force</code> to this force
        /// </summary>
        /// <param name="force">the force to be checked</param>
        /// <returns>true if true</returns>
        public abstract bool canAdd(Force_ force);
        //Force_ override end
        #endregion
    }
}
