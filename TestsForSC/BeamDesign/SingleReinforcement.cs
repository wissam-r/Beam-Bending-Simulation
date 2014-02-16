using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeamDesign
{
    public abstract class SingleReinforcement : RectangularBeam
    {
        public SingleReinforcement(double Mu, double B, double Fy, double Fc): base(Mu, B, Fy, Fc){ }
        public SingleReinforcement(double Mu, double B, double H, double A, double Fy, double Fc) : base(Mu, B, H, A, Fy, Fc) { }
        abstract protected double AzeroCalc();
        virtual protected void AsCalc()
        {
            AreaS = Mu / (0.9 * GammazeroCalc() * D * Fy);
        }
        
    }
}
