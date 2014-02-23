using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using beam.helper;
using beam.reinforcement;
using beam.forms;

namespace beam
{
    public class SinReinRecBeem : RenforcedBeem
    {
        #region Private Parammters
        //The distance between the extreme pressure fiber and reinforcement center in the concrete
        //المسافة بين أقصى ليف شد و مركز التسليح
        private double d;
        //hight
        private double h;
        //The depth of the neutral axis of the section equivalent
        //عمق المحور المحايد للمقطع المكافئ
        private double equivalentX;
        //Moment Inertia equivalent cracked section about the neutral axis Icr
        //عزم العطالة حول المحور للمقطع المتشقق
        private double icr;
        //The actual percentage of reinforcement
        //نسبة مساحة مقطع التسليح العرضي الى مساحة مقطع الخرسانة العرضي
        private double muS;
        //Maxmum ratio of reinforcement
        private double muSmax;
        //the moment that cause the cracking of the concrete  MNm
        //عزم التشقق
        private double mcr;
        //Height equivalent to the pressure zone
        //عمق منطقة الضغط
        private double y;
        //The depth of the neutral axis of the section 
        //عمق المحور المحايد
        private double x;
        // equilibrium Space reinforcemenT
        //مساحة التسليح الوسطية
        private double asb;
        //maxmum Space reinforcemenT
        //مساحة التسليح العظمى
        private double asMax;
        //strength reduction factor
        //معامل تخفيض المقاومة
        private double teta;
        //Momentum resistor in the ideal case
        //العزم المقاوم في الحالة المثالية
        private double rM;
        //Momentum-resistant investment
        //العزم المقاوم الاستثماري
        private double eRM;

        #endregion

        #region Public Getters

        public double H 
        { 
            get { return h; }
            private set {
                if (value <= 0) {
                    throw new ArgumentException("H can't be <= 0 "); 
                }
                else
                {
                    this.h = value;
                }
            
            }
        }
        public double MuSmax
        {
            get { return muSmax; }
        }
        override public double ERM
        {
            get { return eRM; }
        }
        override public double Teta {
            get { return teta; }
        }
        override public double AsMax { 
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
        public double MuS
        {
            get { return muS; }
            private set { 
                if (value >= 1)
                    throw new ArgumentException("As can't be >=  "+ getCrossSectionalArea());
                else if (value < MuSmin)
                {
                    throw new ArgumentException("Mus can't be < "+MuSmin);
                }
                else
                {
                    this.muS = value;
                }
            }
        }
        public double D
        {
            get { return d; }
            private set {
                if (value <= 0)
                {
                    throw new ArgumentException("D can't be  <= 0 ");
                }
                else
                {
                    this.d = value;
                }
                
            }
        }      
        public double EquivalentX
        {
            get { return equivalentX; }
        }
        public double Icr
        {
            get { return icr; }
        }
        override public double Mcr 
        {
            get { return mcr; }
            protected set { mcr = value; }
        }
        public double X
        {
            get { return x; }
        }
        public double RM
        {
            get { return rM; }
        }

        #endregion

        public SinReinRecBeem( double h, double l, double b, double r, int n)
            : this(30, 420, h, l, b, r, n) { }

        public SinReinRecBeem(double cP, double iF, double h, double l, double b, double r, int n)
            : this(cP, iF, h, l, b, 210000, r, n, 5, 1) { }

        public SinReinRecBeem(double cP, double iF, double h, double l, double b, double es, double r, int n, double a, byte choese)// a : the distance between the Maximum fiber strain and reinforcement , choese  : Type Bracelets iron
            : base(cP,iF , b, l,es)//(30, 20, 200, 20, 210000, 10, 2, 5);
            //a,h,l,b,r : cm , es,cp :Mpa 
        {
            H = h;           
            Form = new Rectangle(h, l, b);
            Reinforcement = new SingleReinforcement(r, n);
            D = h - a;
            MuS = calcMuS(getSpaceTensileReinforcement() ,  D);
            this.y = calcY();
            this.x = getX();
            this.asb = calcAsb(D);
            this.asMax = calcAsMax();
            this.muSmax = calcMuSmax();       
            this.teta = getTeta(choese, X,D);
            this.rM = calcRM();
            this.eRM = RM * Teta;

            Mcr = calcMcr(); 
            equivalentX = depthNeutralAxisSectionEquivalent(getSpaceTensileReinforcement(),0,D,0);
            icr = momentInertiaEquivalentCrackedSection(EquivalentX, getSpaceTensileReinforcement() , 0, D, 0);  
                          
        }

        #region Private ClacMethodes

        private double calcAsMax()
        {
            return Asb / 2;
        }
        private double calcMuSmax()
        {
            return AsMax/(B*D);
        }
        
        #endregion

        #region Overrided Methodes

        //Height equivalent to the pressure zone  
        protected override double  calcY() {
            return muS < MuSb ?
                (getSpaceTensileReinforcement() * IF) / (B * 0.85 * CP) : 
                this.y = MathHelper.sESDRP(((0.85 * CP) / (MuS * Es * Ecu)), D, -(B1 * Math.Pow(D, 2)));         
        }
        public override double getIe(double Ma) {
            
            return Ie(Ma, Mcr,getMomentInertiaNonCrackedSection() , Icr);
        }
      
        //العزم المقاوم
        protected override double calcRM()
        {
            return  //getSpaceTensileReinforcement() * IF * (D - (Y / 2));
                0.85 * CP * B * Y * (D - Y / 2);
        }

        

        public override string getFailureWay()
        {
            return MuS < 1.5 * MuSmax ? "Ductile failure" : "Brittle faliure";
        }
        


        

        #endregion

    }
}
