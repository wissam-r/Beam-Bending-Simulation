using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beam.forms
{
    public class Rectangle : Form
    {
        //crossSectionalArea 
        //مساحة المقطع العرضي
        private double A;
        //distanceCenterGravity 
        //البعد عن مركز ثقل الجٍسم
        private double Yt;
        //momentInertiaNonCrackedSection 
        // عزم العطالة حول مركز الجسم غير المتشقق
        private double Ig;
        // h : high  ارتفاع, l : Length طول الخرسانة, b : width عرض الخرسانة


        public Rectangle(double h, double l, double b) 
        { 
            this.A = calcCrossSectionalArea(h, b);
            this.Yt = calcDistanceCenterGravity(h);
            this.Ig = calcMomentInertiaNonCrackedSection(h, b);

        }
        
        private double calcCrossSectionalArea(double h , double b){
            return h*b ;
        }
        private double calcDistanceCenterGravity(double h){

            return h / 2.0;
    
    }
        private double calcMomentInertiaNonCrackedSection(double h, double b)
        {
            return b * Math.Pow(h, 3) / 12; 
        
        }

        //A
        public double crossSectionalArea()
        {
            return A;
        }
        // Yt
        public double distanceCenterGravity()
        {
            return Yt; 
        }
        // Ig
        public double momentInertiaNonCrackedSection()
        {
            return Ig;
        } 
    }
}
