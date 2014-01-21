using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeamDesign
{
    public class WithMaxAs : SectionDesign
    {
        public WithMaxAs(double Mu, double B, double Fy, double Fc): base(Mu, B, Fy, Fc)
        {
            dCalc();
            AsCalc();
        }
        override protected double musCalc()
        {
            return (AlphaCalc() * 0.85 * Fc) / Fy;
        }
        override protected double AlphaCalc()
        {
            return 0.5 * Beta1Calc() * (630 / (630 + Fy));
        }


        public void print()
        {
            Console.WriteLine(musCalc() + " " + AlphaCalc() + " " + AzeroCalc() + " " + rzeroCalc() + " " +
                GammazeroCalc() + " " + D + " " + AreaS);
        }
    }
}
