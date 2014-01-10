using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestsForSC.beem
{

    abstract class RenforcedBeem
    {
        public const double Ecu = 0.003;//Deformation of the concrete

        public RenforcedBeem(double cP, double iF, double b, double l, double es)
        {
            this.b = b;
            this.l = l;
            this.cP = cP;
            this.iF = iF;
            this.es = es;
            this.b1 = calcB1();
            this.emC = calcEmc();
            this.cF = calcCF();
            this.mioSmin = calcMioSmin();
            this.ey = calcEy();
            this.n = ratioOfStandard();
            this.mioSb = calcMioSb();
            this.mioSmax = calcMioSmax();


        }





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
        private double mioSmin;
        //Coefficient to bring pressure area in the form of a rectangle
        private double b1;
        //Deformation of reinforcing
        private double ey;
        //Elastic modulus
        private double es;
        //Space equivalent of concrete n ,  ratioOfStandard
        private double n;
        ///Equilibrium ratio of reinforcement
        private double mioSb;
        //Maxmum ratio of reinforcement
        private double mioSmax;


        public double MioSmax
        {
            get { return mioSmax; }
        }
        public double MioSb
        {
            get { return mioSb; }
        }
        public double Es
        {
            get { return es; }
        }
        public double Ey
        {
            get { return ey; }
        }
        public double B1
        {
            get { return b1; }
        }
        public double MioSmin
        {
            get { return mioSmin; }
        }
        public double IF
        {
            get { return iF; }
        }
        public double B
        {
            get { return b; }
        }
        public double L
        {
            get { return l; }
        }
        public double CP
        {
            get { return cP; }
        }
        public double CF
        {
            get { return cF; }
        }
        public double EMC
        {
            get { return emC; }
        }

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
        //strength reduction factor
        protected double getTeta(byte choese, double mioS)
        {
            if (mioS < MioSmax)
            {

                return 0.9;
            }
            else if (mioS > MioSb)
            {
                //getTheCorrectY();
                return 0.7;
            }
            else
            {
                MessageBox.Show("enterd");
                //getTheCorrectY();
                if (choese == 1)

                    return 0.7 + (et() - (IF / Es)) * (200 / 3) <= 0.9 ? 0.7 + (et() - (IF / Es)) * (200 / 3) : 0.9;
                else
                    return 0.75 + (et() - (IF / Es)) * (150 / 3) <= 0.9 ? 0.75 + (et() - (IF / Es)) * (150 / 3) : 0.9;
            }

        }
        //The depth of the neutral axis of the section 
        protected double getX()
        {
            return calcY() / B1;
        }
        //Xb/D
        private double getXbDivisionD()
        {
            return Ecu / (Ecu + Ey);
        }

        private double calcMioSmin()
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
        private double calcMioSb()
        {
            return (B1 * CP * 0.85 * getXbDivisionD()) / IF;
        }
        private double calcMioSmax()
        {
            return calcMioSb() / 2;
        }

        //moment effective inertia  
        abstract public double getIe(double Ma);
        //Height equivalent to the pressure zone
        abstract protected double calcY();
        abstract protected double et();
        //Momentum-resistant
        abstract protected double calcRM();
        abstract protected void getTheCorrectY();



    }
}
