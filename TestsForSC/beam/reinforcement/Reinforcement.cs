using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace beam.reinforcement
{
    public interface Reinforcement
    {
        //R : radius قطر قضيب التسليح
        //N : number of Reinforcing penis عدد قضبان التسليح
        //مساحة المقطع العرضي لتسليح الشد
        double spaceTensileReinforcement();
        //مساحة المقطع العرضي لتسليح الضغط
        double spaceCompressionReinforcement();

    }
}
