using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestsForSC.helper;

namespace TestsForSC.beem.reinforcement
{
    class SingleReinforcement : Reinforcement
    {
        private double es;//Elastic modulus
        private double n; //Space equivalent of concrete n ,  ratioOfStandard
        private double As;//As  spaceTensileReinforcement
        

        public SingleReinforcement(double es, double emc, double r, double number)
        {
            this.es = es;
            this.n = es / emc;
            As = number * Math.PI * Math.Pow(r / 2, 2);
           
        }
        public double elasticModulus()
        {
            return es;
        }
        public double ratioOfStandard()
        {
            return n;
        }//Space equivalent of concrete n
        public double spaceTensileReinforcement()
        {
            return As;
            
        }
        public double Ie(double Mcr, double Ma, double Ig , double Icr)
        {
             return Mcr > Ma ? Ig :((Math.Pow(Mcr/Ma,3)*Ig)+(1-Math.Pow(Mcr/Ma,3))* Icr)  ;
        }
        
    }
}
