using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeamDesign
{
    public abstract class SectionDesign : SingleReinforcement
    {
        public SectionDesign(double Mu, double B, double Fy, double Fc): base(Mu, B, Fy, Fc){ }
        abstract protected double musCalc();
        abstract override protected double AlphaCalc();
        override protected double AzeroCalc()
        {
            return AlphaCalc() * (1 - 0.5 * AlphaCalc());
        }
        protected double rzeroCalc()
        {
            return Math.Sqrt(1 / AzeroCalc());
        }
        protected void dCalc()
        {
            D = rzeroCalc() * Math.Sqrt(Mu / (0.9 * 0.85 * B * Fc));
        }
    }
}
