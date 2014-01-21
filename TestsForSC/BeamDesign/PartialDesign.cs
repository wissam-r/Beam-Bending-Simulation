using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeamDesign
{
    public class PartialDesign : SingleReinforcement
    {
        public PartialDesign(double Mu, double B, double D, double Fy, double Fc) : base(Mu, B, D, Fy, Fc)
        {
            AsCalc();
        }
        override protected double AzeroCalc()
        {
            return Mu / (0.9 * 0.85 * Fc * B * D * D);
        }
        override protected double AlphaCalc()
        {
            return 1 - Math.Sqrt(1 - 2 * AzeroCalc());
        }
        protected double AlphaMaxCalc()
        {
            return 0.5 * Beta1Calc() * (630 / (630 + Fy));
        }
        protected double AsMinCalc()
        {
            return (0.9 / Fy) * B * D;
        }
        override protected void AsCalc()
        {
            double As = Mu / (0.9 * GammazeroCalc() * D * Fy);
            AreaS = As >= AsMinCalc() ? AsMinCalc() : As;
        }
    }
}
