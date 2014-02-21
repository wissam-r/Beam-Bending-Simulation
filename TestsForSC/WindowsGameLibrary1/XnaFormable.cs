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
        Control XnaContorl { get; }
        Form Form { get; }
        bool NewPointsFlag { get; set; }
        bool NewPointPositionFlag { get; set; }
        bool NewTestForces { get; set; }
        BeamWrapper Beam { get; }
        void sendMassege(string str);
    }
}
