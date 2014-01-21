using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeamDesign
{
    public abstract class SingleReinforcement : RectangularBeam
    {
        public SingleReinforcement(double Mu, double B, double Fy, double Fc): base(Mu, B, Fy, Fc){ }
        public SingleReinforcement(double Mu, double B, double D, double Fy, double Fc) : base(Mu, B, D, Fy, Fc) { }
        abstract protected double AzeroCalc();
        abstract protected double AlphaCalc();
        protected double GammazeroCalc()
        {
            return 1 - 0.5 * AlphaCalc();
        }
        virtual protected void AsCalc()
        {
            AreaS = Mu / (0.9 * GammazeroCalc() * D * Fy);
        }
        protected double Beta1Calc()
        {
            return Fc <= 30 ? 0.85 : 0.85 - 0.007 * (Fc - 30);
        }
    }
}
