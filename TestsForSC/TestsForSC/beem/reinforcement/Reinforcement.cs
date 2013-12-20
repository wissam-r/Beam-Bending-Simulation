using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsForSC.beem.reinforcement
{
    interface Reinforcement
    {
        public double elasticModulus();////Elastic modulus
        public double ratioOfStandard(double cP);
        public double spaceTensileReinforcement(double R, double N);//R : radius ,  N : number of Reinforcing penis
        
        
        
    }
}
