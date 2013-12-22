using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestsForSC.helper;
using TestsForSC.beem.reinforcement;
using TestsForSC.beem.forms;

namespace TestsForSC.beem
{
    class SinReinRecBeem : Beem 
    {

        private double d; //The distance between the extreme pressure fiber and reinforcement center in the concrete 
        public double D
        {
            get { return d; }
        }

        private double dNASE;//The depth of the neutral axis of the section equivalent
        public double DNASE
        {
            get { return dNASE; }
        }

        private double icr;//Moment Inertia equivalent cracked section about the neutral axis Icr
        public double Icr
        {
            get { return Icr; }
        } 
        

        public SinReinRecBeem(double cP, double h, double l, double b, double es, double r, double n, double a)// a : the distance between the Maximum fiber strain and reinforcement
            : base(cP)
            
        {
            this.d = h - a;
            Form = new Rectangle(h, l, b);
            Reinforcement = new SingleReinforcement(es, cP, r, n);
            dNASE = depthNeutralAxisSectionEquivalent(b);
            icr = momentInertiaEquivalentCrackedSection(b);
            

        }

        double depthNeutralAxisSectionEquivalent(double b ) //The depth of the neutral axis of the section equivalent
        {
            return MathHelper.sESDRP(b / 2, getRatioOfStandard() * getSpaceTensileReinforcement(),
                -getRatioOfStandard() * getSpaceTensileReinforcement() * D);
        }
        double momentInertiaEquivalentCrackedSection(double b) // Moment Inertia equivalent cracked section about the neutral axis Icr
        {
            return b * Math.Pow(DNASE, 3) / 3 + getRatioOfStandard() * getSpaceTensileReinforcement() * Math.Pow(D - DNASE, 2);
        }
        double getIe(double Ma) {
            return base.getIe(Ma, Icr);
        }



        
    }
}
