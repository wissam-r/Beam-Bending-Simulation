using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestsForSC.helper;

namespace TestsForSC.beem.reinforcement
{
    class SingleReinforcement : Reinforcement
    {
        private double As;//As  spaceTensileReinforcement
        private double iF;//Resistant iron to flatten
        

        public SingleReinforcement(double iF , double r, double number)
        {
            this.iF = iF;
            As = AsQ(r, number);
           
        }
        public double spaceTensileReinforcement()
        {
            return As;
            
        }
        public double Ie(double Ma,double Mcr, double Ig , double Icr)
        {
             return Mcr > Ma ? Ig :((Math.Pow(Mcr/Ma,3)*Ig)+(1-Math.Pow(Mcr/Ma,3))* Icr)  ;
        }

        private double AsQ(double r ,  double number) { return number * Math.PI * Math.Pow(r / 2, 2); }
    }
}
