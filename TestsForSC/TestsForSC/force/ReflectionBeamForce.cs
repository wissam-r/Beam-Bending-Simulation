﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsForSC.force
{
    class ReflectionBeamForce : PointBaemForce
    {
        private bool isleft;
        public ReflectionBeamForce(double power, double position)
            : base(power, position)
        {
            this.isleft = position==0;
        }
        public override double getMomentom(double distance)
        {
            if (!isleft)
                return 0;
            else
            {
                return -distance * Power;
            }
        }

        public override double getfMomentomd2x(double distance,double beamLength)
        {
            if (!isleft)
                return 0;
            else{
                double A = -Power * Math.Pow(beamLength , 3) / (6*beamLength);
                return -Power * Math.Pow(distance , 3) / 6 - A*distance;
            }
        }
        public override void add(Force force)
        {
            if (this.canAdd(force))
                base.add(force);
        }
        public override bool canAdd(Force force)
        {
            if (!base.canAdd(force)) return false;
            return this.isleft == ((ReflectionBeamForce)force).isleft;
        }
    }
}
