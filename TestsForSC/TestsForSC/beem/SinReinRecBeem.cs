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
        public double ERM
        {
            get { return eRM; }
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
        public double MuS
        {
            get { return muS; }
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
        public double Mcr 
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
        






        public SinReinRecBeem(double cP, double iF, double h, double l, double b, double es, double r, double n, double a, byte choese)// a : the distance between the Maximum fiber strain and reinforcement , choese  : Type Bracelets iron
            : base(cP,iF , b, l,es)//(30, 20, 200, 20, 210000, 10, 2, 5);
            //a,h,l,b,r : cm , es,cp :Mpa 
        {
            H = h;           
            Form = new Rectangle(h, l, b);
            Reinforcement = new SingleReinforcement(r, n);
            D = h - a;
            this.muS = calcMioS();
            if (MuS >= 1)
                throw new ArgumentException("As can't be <=  A");
            Mcr = calcMcr(); 
            equivalentX = depthNeutralAxisSectionEquivalent();
            icr = momentInertiaEquivalentCrackedSection();
            this.y = calcY();
            this.x = getX();
            this.asb = calcAsb();
            this.asMax = calcAsMax();
            this.teta = getTeta(choese , MuS);
            this.rM = calcRM();
            this.eRM = RM * Teta;
            
                  
        }

        private double calcAsMax()
        {
            return Asb / 2;
        }
        //The depth of the neutral axis of the section equivalent
        private double depthNeutralAxisSectionEquivalent( )
        {
            return MathHelper.sESDRP(B / 2, getRatioOfStandard() * getSpaceTensileReinforcement(),
                -(getRatioOfStandard() * getSpaceTensileReinforcement() * D));
        }
        // Moment Inertia equivalent cracked section about the neutral axis Icr
        private double momentInertiaEquivalentCrackedSection() 
        {
            return B * Math.Pow(EquivalentX, 3) / 3 + getRatioOfStandard() * getSpaceTensileReinforcement() * Math.Pow(D - EquivalentX, 2);
        }
        private double calcMcr()
        {
            return (CF * getMomentInertiaNonCrackedSection() * Math.Pow(10, -8)) / (getDistanceCenterGravity() * Math.Pow(10, -2));
        }
        //The actual percentage of reinforcement
        private double calcMioS()
        {
            return getSpaceTensileReinforcement() / (B * D);
        }
        private double calcAsb() {
            return MioSb / (B * D);
        }



        //Height equivalent to the pressure zone  
        protected override double  calcY() {
            return muS < MioSb ?
                (getSpaceTensileReinforcement() * IF) / (B * 0.85 * CP) : 
                this.y = MathHelper.sESDRP(((0.85 * CP) / (MuS * Es * Ecu)), D, -(0.85 * Math.Pow(D, 2)));         
        }
        public override double getIe(double Ma) {
            
            return Reinforcement.Ie(Ma, Mcr,getMomentInertiaNonCrackedSection() , Icr);
        }
        protected override double et()
        {
            return (D - (getX() ) / getX()) * Ecu;
        }
        protected override double calcRM()
        {
            return  //getSpaceTensileReinforcement() * IF * (D - (Y / 2));
                0.85 * CP * B * Y * (D - Y / 2);
        }
        protected override void getTheCorrectY()
        {
            
             
             MessageBox.Show(Y+"\n"+MuS+"\n"+getSpaceTensileReinforcement());
            
        }
       
    }
}
