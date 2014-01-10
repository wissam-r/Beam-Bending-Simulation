using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TestsForSC.beem.reinforcement
{
    interface Reinforcement
    {
        //R : radius قطر قضيب التسليح
        //N : number of Reinforcing penis عدد قضبان التسليح
        double spaceTensileReinforcement();
        //moment effective inertia 
        //عزم العطالة حول مركز الجسم المتشقق
        double Ie(double Mcr, double Ma, double Ig, double Icr);

    }
}
