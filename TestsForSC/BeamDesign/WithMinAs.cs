using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeamDesign
{
    public class WithMinAs : SectionDesign
    {
        public WithMinAs(double Mu, double B, double Fy, double Fc): base(Mu, B, Fy, Fc)
        {
            dCalc();
            AsCalc();
        }
        override protected double musCalc()
        {
            return 0.9 / Fy;
        }
        override protected double AlphaCalc()
        {
            return musCalc() * (Fy / (0.85 * Fc));
        }
        public void print()
        {
            Console.WriteLine(musCalc()+ " " + AlphaCalc()+" "+ AzeroCalc()+ " "+ rzeroCalc()+" " +
                GammazeroCalc() + " " + D + " "+ AreaS);
        }
    }
}
