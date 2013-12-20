using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsForSC.beem
{
    class SinReinRecBeem : Beem
    {
        public SinReinRecBeem(double cS, double h, double l, double b)
            : base(cS)
        {
            Form = new forms.Rectangle(h, l, b);
            forms.Rectangle Rectangle = (forms.Rectangle)Form;
        }
    }
}
