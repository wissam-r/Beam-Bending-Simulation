using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestsForSC.helper;

namespace TestsForSC.beem.reinforcement
{
    class SingleReinforcement : Reinforcement
    {
        //As  spaceTensileReinforcement
        private double As;

        public SingleReinforcement(double r, double number)
        {
            if (r <= 0)
                throw new ArgumentException("r can't be < = 0 ");
            if (number <= 0) 
                throw new ArgumentException("number of rebar can't be <=0") ;
            
            As = calcAs(r, number);

        }

        public double spaceTensileReinforcement()
        {
            return As;

        }
        //moment effective inertia 
        //عزم العطالة حول مركز الجسم المتشقق
        public double Ie(double Ma, double Mcr, double Ig, double Icr)
        {
            return Mcr > Ma ? Ig : ((Math.Pow(Mcr / Ma, 3) * Ig) + (1 - Math.Pow(Mcr / Ma, 3)) * Icr);
        } 

        private double calcAs(double r, double number) { return number * Math.PI * Math.Pow(r / 2, 2); }
    }
}
