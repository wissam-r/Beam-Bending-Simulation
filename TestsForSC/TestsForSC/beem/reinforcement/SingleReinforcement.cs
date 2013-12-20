using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsForSC.beem.reinforcement
{
    class SingleReinforcement : Reinforcement
    {
        private double es;//Elastic modulus

        private double Es
        {
            get { return es; }
            set { es = value; }
        }
        public SingleReinforcement(double es) {
            Es = es;
        }
        public double elasticModulus()
        {
            return Es;
        }

        public double ratioOfStandard( double cP)
        {
            return Es/ cP;
        }


        public double spaceTensileReinforcement(double R, double N)
        {
            return N*Math.PI * Math.Pow(R / 2, 2);
            
        }
    }
}
