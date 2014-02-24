using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using beam.helper;

namespace beam.reinforcement
{
    public class SingleReinforcement : Reinforcement
    {
        #region private pararmetrs
        //As  spaceTensileReinforcement
        private double As;
        #endregion

        #region Constructers

        public SingleReinforcement(double r, int number)
        {
            if (r <= 0)
                throw new ArgumentException("r can't be < = 0 ");
            if (number <= 0) 
                throw new ArgumentException("number of rebar can't be <=0") ;
            
            As = calcAs(r, number);

        }

        #endregion

        #region override methods

        public double spaceTensileReinforcement()
        {
            return As;

        }

        public double spaceCompressionReinforcement()
        {
            return 0;
        }

        #endregion

        #region private calc methods

        private double calcAs(double r, int number) { return number * Math.PI * Math.Pow(r / 2, 2); }

        #endregion
    }
}
