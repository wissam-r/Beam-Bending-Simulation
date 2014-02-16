using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeamDesign
{
    public class DRBPartialDesign : DoubleReinforcement
    {
        public DRBPartialDesign(double Mu, double B, double H, double A, double Fy, double Fc) : base(Mu, B, H, A, Fy, Fc)
        {
            if(H - A <= 0)
                throw new Exception("α should be less than h");
            AsCalc();
        }
        override protected double AlphaCalc()
        {
            return 0.5 * this.Beta1Calc() * (630 / (630 + this.Fy));
        }
        protected double YMax()
        {
            return this.AlphaCalc() * this.D;
        }
        protected double As1Calc()
        {
            return this.Mu1Calc() / (0.9 * this.GammazeroCalc() * this.D * this.Fy);
        }
        protected double Mu1Calc()
        {
            return 0.9 * this.Beta1Calc() * this.Fc * this.B * Math.Pow(this.D, 2) * this.AzeroCalc();
        }
        override protected double AzeroCalc()
        {
            return AlphaCalc() * (1 - 0.5 * AlphaCalc());
        }
        protected void As_Calc()
        {
            this.AreaS_ = (this.Mu - this.Mu1Calc()) / (0.9 * this.Fy * (this.D - this.D_));
        }
        protected void AsCalc()
        {
            this.As_Calc();
            this.AreaS = this.As1Calc() + this.AreaS_;
        }
        private bool check()
        {
            double AsMin = (9/this.Fy)*this.Beta1Calc()*this.D;
            double Asb = (4550/(6300+this.Fy))*(this.Fc/this.Fy)*this.Beta1Calc()*this.D;
            double AsMax = 0.5*Asb;
            As_Calc();
            this.AreaS = As1Calc() + this.AreaS_;
            return AsMax >= (this.As1Calc() + this.AreaS_) && AsMin <= (this.As1Calc() + this.AreaS_) && (this.AreaS_ - (this.As1Calc() + this.AreaS_) <= AsMax);
        }
    }
}
