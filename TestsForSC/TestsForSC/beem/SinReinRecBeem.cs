using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestsForSC.helper;
using TestsForSC.beem.reinforcement;
using TestsForSC.beem.forms;
using System.Windows.Forms;

namespace TestsForSC.beem
{
    class SinReinRecBeem : RenforcedBeem 
    {

        private double d; //The distance between the extreme pressure fiber and reinforcement center in the concrete 
        private double dNASE;//The depth of the neutral axis of the section equivalent
        private double icr;//Moment Inertia equivalent cracked section about the neutral axis Icr
        private double mioS;
        private double mcr;//the moment that cause the cracking of the concrete  MNm
        private double y; //Height equivalent to the pressure zone
        private double x;//The depth of the neutral axis of the section 
        private double asb;// equilibrium Space reinforcemenT
        private double asMax;//maxmum Space reinforcemenT
        private double teta; //strength reduction factor
        private double momentumRegulars;
        private double momentumInvestment;

        public double MomentumInvestment
        {
            get { return momentumInvestment; }
        }
        public double Teta {
            get { return teta; }
        }
        public double AsMax { 
            get {return asMax;}
        }
        public double Asb
        {
            get { return asb; }
        } 
        public double Y
        {
            get { return y; }
        }
        public double MioS
        {
            get { return mioS; }
        }//The actual percentage of reinforcement
        public double D
        {
            get { return d; }
        }      
        public double DNASE
        {
            get { return dNASE; }
        }
        public double Icr
        {
            get { return icr; }
        }
        public double Mcr //the moment that cause the cracking of the concrete
        {
            get { return mcr; }
            protected set { mcr = value; }
        }
        public double X
        {
            get { return x; }
        }
        public double MomentumRegulars
        {
            get { return momentumRegulars; }
        }
        






        public SinReinRecBeem(double cP, double iF, double h, double l, double b, double es, double r, double n, double a, byte choese)// a : the distance between the Maximum fiber strain and reinforcement , choese  : Type Bracelets iron
            : base(cP,iF , b, l,es)//(30, 20, 200, 20, 210000, 10, 2, 5);
            //a,h,l,b,r : cm , es,cp :Mpa 
        {
            
            Form = new Rectangle(h, l, b);
            Reinforcement = new SingleReinforcement(iF , r, n);

            this.d = h - a;
            this.mioS = mioSQ();
            Mcr = mcrQ(); 
            dNASE = depthNeutralAxisSectionEquivalent();
            icr = momentInertiaEquivalentCrackedSection();
            this.y = yQ();
            this.x = getX();
            this.asb = asbQ();
            this.asMax = asMaxQ();
            this.teta = getTeta(choese , MioS);
            this.momentumRegulars = rM();
            this.momentumInvestment = MomentumRegulars * Teta;
            
                  
        }

        double asMaxQ()
        {
            return Asb / 2;
        }
        double depthNeutralAxisSectionEquivalent( ) //The depth of the neutral axis of the section equivalent
        {
            return MathHelper.sESDRP(B / 2, getRatioOfStandard() * getSpaceTensileReinforcement(),
                -(getRatioOfStandard() * getSpaceTensileReinforcement() * D));
        }
        double momentInertiaEquivalentCrackedSection() // Moment Inertia equivalent cracked section about the neutral axis Icr
        {
            return B * Math.Pow(DNASE, 3) / 3 + getRatioOfStandard() * getSpaceTensileReinforcement() * Math.Pow(D - DNASE, 2);
        }
        double mcrQ()
        {
            return (CF * getMomentInertiaNonCrackedSection() * Math.Pow(10, -8)) / (getDistanceCenterGravity() * Math.Pow(10, -2));
        }
        double mioSQ()
        {
            return getSpaceTensileReinforcement() / (B * D);
        }//The actual percentage of reinforcement
        double asbQ() {
            return MioSb / (B * D);
        }
       
        
        
        
        public override double  yQ() {
            return mioS < MioSb ?
                (getSpaceTensileReinforcement() * IF) / (B * 0.85 * CP) : 
                this.y = MathHelper.sESDRP(((0.85 * CP) / (MioS * Es * Ecu)), D, -(0.85 * Math.Pow(D, 2)));         
        }//Height equivalent to the pressure zone  
        public override double getIe(double Ma) {
            return Reinforcement.Ie(Ma, Mcr,getMomentInertiaNonCrackedSection() , Icr);
        }
        public override double et()
        {
            return (D - (getX() ) / getX()) * Ecu;
        }
        public override double rM()
        {
            return  //getSpaceTensileReinforcement() * IF * (D - (Y / 2));
                0.85 * CP * B * Y * (D - Y / 2);
        }
        public override void getTheCorrectY()
        {
            
             
             MessageBox.Show(Y+"\n"+MioS+"\n"+getSpaceTensileReinforcement());
            
        }
       
    }
}
