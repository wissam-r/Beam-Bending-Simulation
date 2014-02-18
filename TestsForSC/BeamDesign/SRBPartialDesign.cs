using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeamDesign
{
    public class SRBPartialDesign : SingleReinforcement
    {
        #region Constructor
        public SRBPartialDesign(double Mu, double B, double H, double A, double Fy, double Fc) : base(Mu, B, H, A, Fy, Fc)
        {
            if(H - A <= 0)
                throw new Exception("α should be less than h");
            AsCalc();
        }
        #endregion
        #region Methods
        protected double AlphaMaxCalc()
        {
            return 0.5 * Beta1Calc() * (630 / (630 + Fy));
        }
        protected double AsMinCalc()
        {
            return (0.9 / Fy) * B * D;
        }
        override protected double AzeroCalc()
        {
            return Mu / (0.9 * 0.85 * Fc * B * D * D);
        }
        override protected double AlphaCalc()
        {
            return 1 - Math.Sqrt(1 - 2 * AzeroCalc());
        }
        override protected void AsCalc()
        {
            if (this.AlphaCalc() <= this.AlphaMaxCalc())
            {
                double As = Mu / (0.9 * GammazeroCalc() * D * Fy);
                AreaS = As < AsMinCalc() ? AsMinCalc() : As;
            }
            else
            {
                throw new Exception("Double reinforcement Needed");
            }
        }
        #endregion
    }
}
