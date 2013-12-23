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
            this.cP = cP;
            emC = Math.Sqrt(this.cP) * 6645;
            cF = 0.74 * Math.Sqrt(this.cP);
            
            
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

        private double cP; //Resistance of concrete to pressure (f'c
        private double cF;//Resistance of concrete to flatten Fcb
        private double emC;//Elastic modulus of concrete Eco
        private double mcr;//the moment that cause the cracking of the concrete  MNm

        public double CP
        {
            get { return cP; }
        }//Resistance of concrete to pressure (f'c
        public double CF
        {
            get { return cF; }
        }//Resistance of concrete to flatten Fcb
        public double EMC
        {
            get { return emC; }
        }//Elastic modulus of concrete Eco
        public double Mcr //the moment that cause the cracking of the concrete
        {
            get { return mcr; }
            protected set { mcr = value; }
        }
       

        public double getCrossSectionalArea()
        {
            return Form.crossSectionalArea(); 
        }//A
        public double getDistanceCenterGravity()
        {
            return Form.distanceCenterGravity();
        }//Yt
        public double getMomentInertiaNonCrackedSection() {
            return form.momentInertiaNonCrackedSection();
        }//Ig
        public double getRatioOfStandard() {
            return reinforcement.ratioOfStandard();
        }
        abstract public double getIe(double Ma);//{
           // return reinforcement.Ie(Mcr , Ma , getMomentInertiaNonCrackedSection() , Icr) ;
        //}    //moment effective inertia  
        public double getSpaceTensileReinforcement() {
            return reinforcement.spaceTensileReinforcement();
        }//As


        


    }
}
