using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beam.reinforcement
{
    public class DoubleReinforcement : Reinforcement
    {
        #region private parameters
        //SpaceTensileReinforcement
        //مساحة المقطع العرضي لتسليح الشد
        private double As;
        //SpaceCompressionReinforcement
        //مساحة المقطع العرضي لتسليح الضغط
        private double Aas;

        #endregion

        #region Constructers
        public DoubleReinforcement(double r , int n , double ra  , int na) {

            if (r <= 0)
                throw new ArgumentException("r can't be < = 0 ");
            if (n <= 0)
                throw new ArgumentException("n of rebar can't be <=0");
            if (ra <= 0)
                throw new ArgumentException("ra can't be < = 0 ");
            if (na <= 0)
                throw new ArgumentException("na of rebar can't be <=0");

            As = calcAs(r, n);
            Aas = calcAs(ra, na);
            
        
        
        }
        #endregion

        #region override methods
        public double spaceTensileReinforcement()
        {
            return As;
        }

        public double spaceCompressionReinforcement()
        {
            return Aas;
        }
        #endregion

        #region private methods
        private double calcAs(double r, int number) { return number * Math.PI * Math.Pow(r / 2, 2); }
        #endregion
    }


}
