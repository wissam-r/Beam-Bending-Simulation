using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TestsForSC.beem
{
    
    abstract class Beem
    {
       
        public Beem(double cP)
        {
            CP = cP;
            emC = Math.Sqrt(this.CP) * 6645;
            cF = 0.74 * Math.Sqrt(CP);
        }

        forms.Form form;
        public forms.Form Form {
            get { return form; }
            set {form = value;}

        }

        //reinforcement.Reinforcement reinforcement;
        //public reinforcement.Reinforcement Reinforcement
        //{
        //    get { return reinforcement; }
        //    set { reinforcement = value; }
        //} 
              
        private double cP; //Resistance of concrete to pressure (f'c)
        public double CP 
        {
            get { return cP ; }
            set { cP = value; }
        
        }
        private double cF;//Resistance of concrete to flatten Fcb

        public double CF
        {
            get { return cF; }
            set { cF = value; }
        }
        private double emC;//Elastic modulus of concrete Eco

        public double getCrossSectionalArea()
        {
            return Form.crossSectionalArea(); 
        }
        public double getDistanceCenterGravity()
        {
            return Form.distanceCenterGravity();
        }//Yt
        public double getMomentInertiaNonCrackedSection() {
            return form.momentInertiaNonCrackedSection();
        }//Ig
        public double Mcr() //the moment that cause of the cracking of the concrete
        {
            return CF * getMomentInertiaNonCrackedSection() / getDistanceCenterGravity() 
        }


    }
}
