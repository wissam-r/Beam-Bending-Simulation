using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestsForSC.helper;
using TestsForSC.beem.reinforcement;

namespace TestsForSC.beem
{
    class SinReinRecBeem : Beem , reinforcement.Reinforcement
    {
        private Reinforcement RF;
        private double spaceTensileReinforcement;

        public double SpaceTensileReinforcement
        {
            get { return spaceTensileReinforcement; }
            set { spaceTensileReinforcement = value; }
        }
        private double ratioOfStandard;

        public double RatioOfStandard
        {
            get { return ratioOfStandard; }
            set { ratioOfStandard = value; }
        }

        private double d; //The distance between the extreme pressure fiber and reinforcement center in the concrete 

        public double D
        {
            get { return d; }
            private set { d = value; }
        }
        public SinReinRecBeem(double cP, double h, double l, double b,double es,double r,double n)
            : base(cP)
            
        {
            Form = new forms.Rectangle(h, l, b);
            forms.Rectangle Rectangle = (forms.Rectangle)Form ;
            RF= new SingleReinforcement(es) ;
            SpaceTensileReinforcement = RF.spaceTensileReinforcement(r,n) ;
            RatioOfStandard = RF.ratioOfStandard(cP) ;
            D = h - 5;
            double dNASE = MathHelper.sESDRP(b / 2, RatioOfStandard * SpaceTensileReinforcement,
                -RatioOfStandard * SpaceTensileReinforcement*D);//The depth of the neutral axis of the section equivalent


            
        }
            
    }
}
