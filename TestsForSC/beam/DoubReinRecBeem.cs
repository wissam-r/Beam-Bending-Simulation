using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using beam.forms;
using beam.reinforcement;
using beam.helper;

namespace beam
{
    public class DoubReinRecBeem : RenforcedBeem
    {

        #region Private Parammters
        //The distance between the extreme pressure fiber and tensile reinforcement center in the concrete
        //المسافة بين أقصى ليف ضغط و مركز التسليح للشد
        private double d;
        ////The distance between the extreme pressure fiber and compression reinforcement center in the concrete
        //المسافة بين اقصى ليف ضغط ومركز التسليح للضغط  
        private double da;
        //hight
        private double h;
        //The depth of the neutral axis of the section equivalent
        //عمق المحور المحايد للمقطع المكافئ
        private double equivalentX;
        //Moment Inertia equivalent cracked section about the neutral axis Icr
        //عزم العطالة حول المحور للمقطع المتشقق
        private double icr;
        //The actual trensile percentage of reinforcement
        //نسبة مساحة مقطع تسليح الشد العرضي الى مساحة مقطع الخرسانة العرضي
        private double muS;
        //The actual comprsurre percentage of reinforcement
        //نسبة مساحة مقطع تسليح الضغط العرضي الى مساحة مقطع الخرسانة العرضي
        private double muSa;
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

        public double Da {
            get { return da; }
            private set {
                if (value >= D) {
                    throw new ArgumentException("Da can't be >= D"); 
                }
                else
                {
                    this.da = value; 
                }
            
            }

        
        }

        public double H
        {
            get { return h; }
            private set
            {
                if (value <= 0)
                {
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
        public double Teta
        {
            get { return teta; }
        }
        public double AsMax
        {
            get { return asMax; }
        }
        public double MuSmax
        {
            get { return muSmax; }
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
            private set
            {
                if (value >= 1)
                    throw new ArgumentException("As can't be <=  A");
                else if (value < MuSmin)
                {
                    throw new ArgumentException("Mus can't be < MusMin");
                }
                else
                {
                    this.muS = value;
                }
            }
        }
        public double MuSa
        {
            get { return muSa; }
            private set
            {
                if (value >= 1)
                    throw new ArgumentException("Aas can't be <=  A");
                else if (value + MuS >= 1)
                {
                    throw new ArgumentException("Mus + MuSa can't be > 1");
                }
                else
                {
                    this.muSa = value;
                }
            }
        }
        public double D
        {
            get { return d; }
            private set
            {
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

        #endregion

        public DoubReinRecBeem(double h, double l, double b, double r, double ra, int n, int na)
            : this(30, 420, h, l, b ,  r, ra, n, na) { }

        public DoubReinRecBeem(double cP, double iF, double h, double l, double b, double r, double ra, int n, int na)
            : this(cP, iF, h, l, b, 210000, r, ra, n, na, 5, 5, 1) { }

        public DoubReinRecBeem(double cP, double iF, double h, double l, double b, double es, double r,double ra ,int n,int na ,  double a,double aa ,  byte choese)// a : the distance between the Maximum fiber strain and reinforcement , choese  : Type Bracelets iron
            : base (cP, iF, b, l, es) 
        {
            H = h;
            Form = new Rectangle(h, l, b);
            Reinforcement = new DoubleReinforcement(r, n, ra, na);
            D = H - a;
            Da = aa;
            MuS = calcMuS(getSpaceTensileReinforcement(), D);
            MuSa = calcMuS(getSpaceCompressionReinforcement(), D);
            this.y = calcY();
            this.x = getX();
            this.asb = calcAsb(D);
            this.asMax = calcAsMax();
            this.muSmax = calcMuSmax();
            this.teta = getTeta(choese, MuS, MuSmax, D);
            this.rM = calcRM();
            this.eRM = RM * Teta;

            Mcr = calcMcr();
            equivalentX = depthNeutralAxisSectionEquivalent(getSpaceTensileReinforcement(), getSpaceCompressionReinforcement(), D, Da);
            icr = momentInertiaEquivalentCrackedSection(EquivalentX, getSpaceTensileReinforcement(), getSpaceCompressionReinforcement(), D, Da);  


        }



        #region Overrided Methods
        public override double getIe(double Ma)
        {
            return Ie(Ma, Mcr, getMomentInertiaNonCrackedSection(), Icr); 
        }

        protected override double calcY()
        {
            double y = ((getSpaceTensileReinforcement() - getSpaceCompressionReinforcement()) / B) * IF / (0.85 * CP);               
            if (((MuS- MuSa)<=MuSb) && ((Da/y) <= calcDaDivYLim())){
                return y;
            }
            else if ((MuS- MuSa)<=MuSb)
            {
                return MathHelper.sESDRP(0.85*CP , 
                    -(getSpaceTensileReinforcement()*IF + B*Da*MuSa*Es*Ecu ),
                    B*MuSa*Es*B1*Ecu*Math.Pow(Da,2)) ;
            }
            else if ((Da / y) <= calcDaDivYLim())
                return MathHelper.sESDRP(0.85*CP , 
                    MuS*Es*Ecu*D+getSpaceCompressionReinforcement()*IF ,
                    -(B1*MuS*Es*Ecu*Math.Pow(D , 2 ) )) ;
            else
            {
                return MathHelper.sESDRP(0.85 * CP,
                    MuS * Es * Ecu * D - MuSa * Es * Ecu * Da,
                    -(B1 * MuS * Es * Ecu * Math.Pow(D, 2)) + B1 * MuSa * Es * Ecu * Math.Pow(Da, 2));

            }
        }

        protected override double calcRM()
        {
            return (0.85 * CP * B * Y * (D - y / 2) + getSpaceCompressionReinforcement() * IF * (D - Da));
        }

        public override double getERM() {
            return ERM;
        }

        
        #endregion

        #region Private Methods
        private double calcDaDivYLim() {
            return 1 / B1 - IF / (630 * B1);
        
        }
        private double calcAsMax()
        {
            return Asb*0.75;
        }
        private double calcMuSmax()
        {
            return AsMax / (B * D);
        }
        #endregion

    }
}
