using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace forces
{
    public interface Force_
    {
        /// <summary>
        /// the power of the force should be in newten
        /// </summary>
        double Power { set; get; }
        /// <summary>
        /// add force to this force if <code>canAdd(force)</code> is true
        /// </summary>
        /// <param name="force">the force to be added</param>
        /// <seealso cref="canadd"/>"
        void add(Force_ force);
        /// <summary>
        /// check to see if you can add <code>force</code> to this force
        /// </summary>
        /// <param name="force">the force to be checked</param>
        /// <returns>true if true</returns>
        bool canAdd(Force_ force);
    }
}
