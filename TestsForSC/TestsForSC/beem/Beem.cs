using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TestsForSC.beem
{
    
    abstract class RenforcedBeem
    {
        public const double Ecu = 0.003 ;//Deformation of the concrete
       
        public RenforcedBeem(double cP,double iF,double b, double l ,double es)
        {
            this.b = b;
            this.l = l;
            this.cP = cP;
            this.iF = iF;
            this.es = es;
            this.b1 = b1Q();
            this.emC = emcQ();
            this.cF = cfQ();
            this.mioSmin = mioSminQ();
            this.ey = EyQ();
            this.n = ratioOfStandard();
            this.mioSb = mioSbQ();
            this.mioSmax = mioSmaxQ();
            
                        
        }



        

        forms.Form form;
        public forms.Form Form {
            get { return form; }
            set {form = value;}

        }
        reinforcement.Reinforcement reinforcement;
        public reinforcement.Reinforcement Reinforcement
        {
            get { return reinforcement; }
            set { reinforcement = value; }
        }

        private double cP; //Resistance of concrete to pressure (f'c
        private double cF;//Resistance of concrete to flatten Fcb
        private double emC;//Elastic modulus of concrete Eco
        private double l;//
        private double b;//
        private double iF;//Resistant iron to flatten
        private double mioSmin;//Minimum ratio of reinforcement
        private double b1;//Coefficient to bring pressure area in the form of a rectangle
        private double ey;//Deformation of reinforcing
        private double es;//Elastic modulus
        private double n; //Space equivalent of concrete n ,  ratioOfStandard
        private double mioSb;///Equilibrium ratio of reinforcement
        private double mioSmax;//Maxmum ratio of reinforcement
        

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
        }//Resistance of concrete to pressure (f'c
        public double CF
        {
            get { return cF; }
        }//Resistance of concrete to flatten Fcb
        public double EMC
        {
            get { return emC; }
        }//Elastic modulus of concrete Eco
       

        public double getCrossSectionalArea()
        {
            return Form.crossSectionalArea(); 
        }//A
        public double getDistanceCenterGravity()
        {
            return Form.distanceCenterGravity();
        }//Yt
        public double getMomentInertiaNonCrackedSection() {
            return form.momentInertiaNonCrackedSection();
        }//Ig
        public double getRatioOfStandard() {
            return n;
        }     
        public double getSpaceTensileReinforcement() {
            return reinforcement.spaceTensileReinforcement();
        }//As
        
        protected double getTeta(byte choese,double mioS) {
            if (mioS < MioSmax)
                return 0.9;
            else if (mioS > MioSb)
                return 0.7;
            else {
                if (choese == 1)

                    return 0.7 + (et() - (IF / Es)) * (200 / 3) <= 0.9 ? 0.7 + (et() - (IF / Es)) * (200 / 3) : 0.9;
                else
                    return 0.75 + (et() - (IF / Es)) * (150 / 3) <= 0.9 ? 0.75 + (et() - (IF / Es)) * (150 / 3): 0.9;
            }
                
        }//strength reduction factor
        protected double getX() {
            return yQ() / B1;
        }////The depth of the neutral axis of the section 
        public double getXbDivisiond(){
            return Ecu/(Ecu+Ey) ;
        }

        private double mioSminQ() {
            return Math.Sqrt(CP) / (4 * IF) > 1.4 / IF ? Math.Sqrt(CP) / (4 * IF) : 1.4 / IF; ;
        }
        private double b1Q() {
            if (CP <= 30)
                return 0.85;
            else if (CP >= 58)
                return 0.65;
            else
                return 0.85 - 0.007 * (CP - 30);
        }
        private double emcQ() {
            return Math.Sqrt(this.cP) * 6645;
        }
        private double cfQ()
        {
            return 0.74 * Math.Sqrt(this.cP);
        }
        private double EyQ() {
            return IF / Es;
        }
        private double ratioOfStandard()
        {
            return Es / EMC;
        }//Space equivalent of concrete n
        private double mioSbQ() {
            return (B1 * CP * 0.85 * getXbDivisiond()) / IF; 
        }
        private double mioSmaxQ()
        {
            return mioSbQ() / 2;
        }


        abstract public double getIe(double Ma);//moment effective inertia  
        abstract public double yQ();//Height equivalent to the pressure zone
        abstract public double et();//
        abstract public double rM();//Momentum-resistant

        


    }
}
