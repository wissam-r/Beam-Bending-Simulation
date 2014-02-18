using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeamDesign
{
    public abstract class DoubleReinforcement : RectangularBeam
    {
        #region Fields
        private double d_;
        private double As_;
        #endregion

        #region Constructors
        public DoubleReinforcement(double Mu, double B, double H, double A, double Fy, double Fc)
            : base(Mu, B, H, A, Fy, Fc)
        {
            this.D_ = A;
        }
        #endregion

        #region Properties
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
        #endregion

        #region Methodz
        abstract protected double AzeroCalc();
        #endregion
    }
}
