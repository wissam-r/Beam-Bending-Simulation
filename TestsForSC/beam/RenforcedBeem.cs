using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using beam.helper;
using System.Windows.Forms;
namespace beam
{

    public abstract class RenforcedBeem
    {
        public const double Ecu = 0.003;//Deformation of the concrete

        public RenforcedBeem(double cP, double iF, double b, double l, double es)
        {
            B = b;
            L = l;
            CP = cP;
            IF = iF;
            Es = es;
            this.b1 = calcB1();
            this.emC = calcEmc();
            this.cF = calcCF();
            this.muSmin = calcMuSmin();
            this.ey = calcEy();
            this.n = ratioOfStandard();
            this.muSb = calcMuSb();
            


        }

        #region Composing Parammters

        forms.Form form;
        public forms.Form Form
        {
            get { return form; }
            set { form = value; }

        }
        reinforcement.Reinforcement reinforcement;
        public reinforcement.Reinforcement Reinforcement
        {
            get { return reinforcement; }
            set { reinforcement = value; }
        }

        #endregion

        #region Private Parammeters
        //Resistance of concrete to pressure f'c
        private double cP;
        //Resistance of concrete to flatten Fcb
        private double cF;
        //Elastic modulus of concrete Eco
        private double emC;
        //length
        private double l;
        //width
        private double b;
        //Resistant iron to flatten
        private double iF;
        //Minimum ratio of reinforcement
        private double muSmin;
        //Coefficient to bring pressure area in the form of a rectangle
        private double b1;
        //Deformation of reinforcing
        private double ey;
        //Elastic modulus
        private double es;
        //Space equivalent of concrete n ,  ratioOfStandard
        private double n;
        ///Equilibrium ratio of reinforcement
        private double muSb;


        #endregion

        #region Public Getters

        public double MuSb
        {
            get { return muSb; }
        }
        public double Es
        {
            get { return es; }
            private set {
                if (value <= 0) {
                    throw new ArgumentException("Es can't be <=  0");
                }
                else
                {
                    this.es = value;
                }
            }
        }
        public double Ey
        {
            get { return ey; }
        }
        public double B1
        {
            get { return b1; }
        }
        public double MuSmin
        {
            get { return muSmin; }
        }
        public double IF
        {
            get { return iF; }
            private set {
                if (value <= 0) 
                {
                    throw new ArgumentException("iF can't be < 0");    
                }
                else
                {
                    this.iF = value;
                }
            }
        }
        public double B
        {
            get { return b; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("B can't ne <= 0 " );
                }
                else
                    this.b = value;
            }
        }
        public double L
        {
            get { return l; }
            private set {
                if (value <= 0)
                {
                    throw new ArgumentException("L can't be < 0 ");
                }
                else {
                    this.l = value;
                }
            
            }
        }
        public double CP
        {
            get { return cP; }
            private set {
                if (value <= 0)
                {
                    throw new ArgumentException("cP can't be <= 0 ");
                }
                else
                    this.cP = value;
            }
        }
        public double CF
        {
            get { return cF; }
            private set {
                if (value <= 0)
                {
                    throw new ArgumentException("cF can't be < 0 ");
                }
                else
                {
                    cF = value;
                }
            }
        }
        public double EMC
        {
            get { return emC; } 
        }
        #endregion

        #region Protected Getters
        //A
        protected double getCrossSectionalArea()
        {
            return Form.crossSectionalArea();
        }
        //Yt
        protected double getDistanceCenterGravity()
        {
            return Form.distanceCenterGravity();
        }
        //Ig
        protected double getMomentInertiaNonCrackedSection()
        {
            return form.momentInertiaNonCrackedSection();
        }
        protected double getRatioOfStandard()
        {
            return n;
        }
        //As
        protected double getSpaceTensileReinforcement()
        {
            return reinforcement.spaceTensileReinforcement();
        }
        //Aas
        protected double getSpaceCompressionReinforcement() {
            return Reinforcement.spaceCompressionReinforcement();
        }
        //strength reduction factor
        protected double getTeta(byte choese, double muS,double MuSmax, double D)
        {
            if (muS < MuSmax)
            {

                return 0.9;
            }
            else if (muS > MuSb)
            {
                //getTheCorrectY();
                return 0.7;
            }
            else
            {
                MessageBox.Show("enterd");
                //getTheCorrectY();
                if (choese == 1)

                    return 0.7 + (et(D) - (IF / Es)) * (200 / 3) <= 0.9 ? 0.7 + (et(D) - (IF / Es)) * (200 / 3) : 0.9;
                else
                    return 0.75 + (et(D) - (IF / Es)) * (150 / 3) <= 0.9 ? 0.75 + (et(D) - (IF / Es)) * (150 / 3) : 0.9;
            }

        }
        //The depth of the neutral axis of the section 
        protected double getX()
        {
            return calcY() / B1;
        }

        protected double calcMcr()
        {
            return (CF * getMomentInertiaNonCrackedSection() * Math.Pow(10, -8)) / (getDistanceCenterGravity() * Math.Pow(10, -2));
        }
        protected double et(double D)
        //تشوه الحديد
        {
            return (D - (getX()) / getX()) * Ecu;
        }

        //The actual percentage of reinforcement
        protected double calcMuS(double As , double D)
        {
            return As / (D*B);
        }
        protected double calcAsb(double D)
        {
            return MuSb * B * D;
        }
        //The depth of the neutral axis of the section equivalent
        protected double depthNeutralAxisSectionEquivalent(double As ,  double Aas ,  double D ,double Da)
        {
            return MathHelper.sESDRP(B / 2, getRatioOfStandard() * As +(getRatioOfStandard()-1)*Aas,
                -(getRatioOfStandard() * As * D) - (getRatioOfStandard() - 1) * Aas*Da);
        }
        // Moment Inertia equivalent cracked section about the neutral axis Icr
        protected double momentInertiaEquivalentCrackedSection(double x , double As,double Aas ,  double D, double Da )
        {
            return B * Math.Pow(x, 3) / 3 + getRatioOfStandard() * As * Math.Pow(D - x, 2) + (getRatioOfStandard() - 1) * Aas * Math.Pow(x- Da, 2);
        }

        //moment effective inertia 
        //عزم العطالة حول مركز الجسم المتشقق
        public double Ie(double Ma, double Mcr, double Ig, double Icr)
        {
            return Ma <= Mcr ? Ig : ((Math.Pow(Mcr / Ma, 3) * Ig) + (1 - Math.Pow(Mcr / Ma, 3)) * Icr);
        } 

        #endregion

        #region Private CalcMethods

        //Xb/D
        private double getXbDivisionD()
        {
            return Ecu / (Ecu + Ey);
        }
        private double calcMuSmin()
        {
            return Math.Sqrt(CP) / (4 * IF) > 1.4 / IF ? Math.Sqrt(CP) / (4 * IF) : 1.4 / IF; ;
        }
        private double calcB1()
        {
            if (CP <= 30)
                return 0.85;
            else if (CP >= 58)
                return 0.65;
            else
                return 0.85 - 0.007 * (CP - 30);
        }
        private double calcEmc()
        {
            return Math.Sqrt(this.cP) * 6645;
        }
        private double calcCF()
        {
            return 0.74 * Math.Sqrt(this.cP);
        }
        private double calcEy()
        {
            return IF / Es;
        }
        //Space equivalent of concrete n
        private double ratioOfStandard()
        {
            return Es / EMC;
        }
        private double calcMuSb()
        {
            return (B1 * CP * 0.85 * getXbDivisionD()) / IF;
        }
        

        #endregion


        #region Abstract Methods
        //moment effective inertia  
        abstract public double getIe(double Ma);
        //Height equivalent to the pressure zone
        abstract protected double calcY();
        
        //Momentum-resistant
        abstract protected double calcRM();

        abstract public double getERM();

        #endregion



    }
}
