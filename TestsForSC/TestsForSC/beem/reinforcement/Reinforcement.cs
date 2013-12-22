using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TestsForSC.beem.reinforcement
{
    interface Reinforcement
    {
        double elasticModulus();////Elastic modulus
        double ratioOfStandard();
        double spaceTensileReinforcement();//R : radius ,  N : number of Reinforcing penis
        double Ie(double Mcr , double Ma ,double Ig,double Icr); //moment effective inertia 

        
        
        
    }
}
