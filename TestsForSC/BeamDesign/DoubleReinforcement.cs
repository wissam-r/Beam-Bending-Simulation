using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeamDesign
{
    public abstract class DoubleReinforcement : RectangularBeam
    {
        private double d_;
        private double As_;
        abstract protected double AzeroCalc();
        public DoubleReinforcement(double Mu, double B, double H, double A, double Fy, double Fc)
            : base(Mu, B, H, A, Fy, Fc)
        {
            this.D_ = A;
        }
        public double D_
        {
            protected set { d_ = Math.Round(value, 5); }
            get { return d_; }
        }
        public double AreaS_
        {
            protected set { this.As_ = Math.Round(value, 5); }
            get { return As_; }
        }
    }
}
