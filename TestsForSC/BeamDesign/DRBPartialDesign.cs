using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeamDesign
{
    public class DRBPartialDesign : DoubleReinforcement
    {
        #region Constructors
        public DRBPartialDesign(double Mu, double B, double H, double A, double Fy, double Fc) : base(Mu, B, H, A, Fy, Fc)
        {
            if (H - A <= 0)
                throw new Exception("α should be less than h");
            AsCalc();
        }
        #endregion
        #region Methods
        override protected double AlphaCalc()
        {
            return 0.5 * this.Beta1Calc() * (630 / (630 + this.Fy));
        }
        override protected double AzeroCalc()
        {
            return AlphaCalc() * (1 - 0.5 * AlphaCalc());
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
        protected double As_Calc()
        {
            this.AreaS_ = (this.Mu - this.Mu1Calc()) / (0.9 * this.Fy * (this.D - this.D_));
            return this.AreaS_;
        }
        protected void AsCalc()
        {
            this.AreaS = this.As1Calc() + this.As_Calc();
            bool check = ((this.AreaS - Math.Abs(this.AreaS_)) / this.B * this.D) >= (this.Beta1Calc() * this.Fc / this.Fy) * ((this.D_ * 535) / (this.D * (630 - this.Fy)));
            if (!check || this.AreaS_ <= 0)
                throw new Exception("Use single reinforcement");
            double AsMin = (0.9 / this.Fy) * this.B * this.D;
            double AsMax = 0.75 * this.AsbCalc();
            this.AreaS = this.AreaS < AsMin ? AsMin : this.AreaS;
            if(this.AreaS > AsMax)
                throw new Exception("b or h must be bigger");
            check = this.AreaS - this.AreaS_ < AsMax;
        }
        private double AsbCalc()
        {
            return (((455 / (630 + this.Fy)) * (this.Fc / this.Fy)) + ((this.As_Calc() * this.FsCalc()) / (this.B * this.D * this.Fy))) * this.B * this.D;
        }
        private double FsCalc()
        {
            double fs = 630 * (1 - (this.D_ * (630 + this.Fy)) / (this.D * 630));
            return fs < this.Fy ? fs : this.Fy;
        }
        #endregion
    }
}
