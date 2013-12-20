using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsForSC.beem
{
    abstract class Beem
    {
        public Beem(double CS)
        {
            this.CS = CS;
            emC = Math.Sqrt(this.CS) * 6645;
        }

        forms.Form form;
        public forms.Form Form {
            get { return form; }
            set {form = value;}

        }

        reinforcement.Reinforcement reinforcement;
        public reinforcement.Reinforcement Reinforcement
        {
            get { return reinforcement; }
            set { reinforcement = value; }
        } 
              
        private double cS; //Compressive Strength for Concrete (f'c)
        public double CS 
        {
            get { return cS ; }
            set { cS = value; }
        
        }

        private double emC;//Elastic modulus of concrete Eco

        public double getCrossSectionalArea()
        {
            return Form.crossSectionalArea(); 
        }


    }
}
