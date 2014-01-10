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
