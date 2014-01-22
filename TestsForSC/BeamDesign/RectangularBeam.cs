using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeamDesign
{
    public abstract class RectangularBeam
    {
        /* b Width of section
         * d Effective depth of section
         * As Cross-sectional area of longitudinal tensile reinforcement
         */
        #region Private Members
        private double mu;
        private double b;
        private double d;
        private double fy;
        private double fc;
        private double As;
        #endregion

        #region Properties
        protected double Mu
        {
            private set { this.mu = value * Math.Pow(10, 6); }
            get { return mu; }
        }
        public double D
        {
            protected set { d = Math.Round(value, 5); }
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
        #endregion
        public RectangularBeam() { }
        public RectangularBeam(double Mu, double B, double D, double Fy, double Fc)
        {
            this.Mu = Mu;
            this.B = B;
            this.D = D;
            this.Fy = Fy;
            this.Fc = Fc;
        }
        public RectangularBeam(double Mu, double B, double Fy, double Fc) : this(Mu, B, 0, Fy, Fc)
        {
            
        }
    }
}
