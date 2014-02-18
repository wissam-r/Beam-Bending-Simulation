using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeamDesign
{
    public abstract class RectangularBeam
    {
        #region Fields
        private double mu;
        private double b;
        private double d;
        private double fy;
        private double fc;
        private double As;
        private double h;
        private double a;
        #endregion
        #region Properties
        protected double Mu
        {
            private set { this.mu = value * Math.Pow(10, 6); }
            get { return mu; }
        }
        public double D
        {
            protected set { d = value > 0 ? Math.Round(value, 5) : 0; }
            get { return d; }
        }
        protected double B
        {
            private set { this.b = value; }
            get { return b; }
        }
        protected double Fy
        {
            private set { this.fy = value; }
            get { return fy; }
        }
        protected double Fc
        {
            private set { this.fc = value; }
            get { return fc; }
        }
        public double AreaS
        {
            protected set { this.As =  Math.Round(value,5); }
            get { return As; }
        }

        public double H
        {
            protected set { this.h = Math.Round(value, 5); }
            get { return h; }
        }

        public double A
        {
            protected set { this.a = Math.Round(value, 5); }
            get { return a; }
        }
        #endregion
        #region Constructors
        public RectangularBeam() { }
        public RectangularBeam(double Mu, double B, double H, double A, double Fy, double Fc)
        {
            this.Mu = Mu;
            this.B = B;
            this.D = H - A;
            this.Fy = Fy;
            this.Fc = Fc;
        }
        public RectangularBeam(double Mu, double B, double Fy, double Fc) : this(Mu, B, 0, 0, Fy, Fc)
        {
            
        }
        #endregion
        #region Methods
        abstract protected double AlphaCalc();
        protected double Beta1Calc()
        {
            return Fc <= 30 ? 0.85 : 0.85 - 0.007 * (Fc - 30);
        }
        protected double GammazeroCalc()
        {
            return 1 - 0.5 * AlphaCalc();
        }
        #endregion
    }
}
