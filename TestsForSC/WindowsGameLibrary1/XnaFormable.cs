using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using beam;
using forces;

namespace mainPorject
{
    public interface XnaFormable
    {
        /// <summary>
        /// return a contorl that will hold xna drawing
        /// </summary>
        Control XnaContorl { get; }
        /// <summary>
        /// return the form in which xna will be hold
        /// </summary>
        Form Form { get; }
        /// <summary>
        /// indecate that there is new points
        /// </summary>
        bool NewPointsFlag { get; set; }
        /// <summary>
        /// indecate that there is new position of the previous points has new y
        /// </summary>
        bool NewPointPositionFlag { get; set; }
        /// <summary>
        /// indecate that there is new test forces
        /// </summary>
        bool NewTestForces { get; set; }
        /// <summary>
        /// return beam wrapper to use in xna
        /// </summary>
        BeamWrapper Beam { get; }
        /// <summary>
        /// send message to the form
        /// </summary>
        /// <prparam name="str">the messege could hold numbers</prparam>
        void sendMassege(string str);
    }
}
