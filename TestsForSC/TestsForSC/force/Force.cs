using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsForSC.force
{
    abstract class Force
    {
        public Force(double power)
        {
            Power = power;
        }
        public double Power { protected set; public get; }
        abstract public double getMomentom(double distance);
        abstract public double getfMomentomd2x(double distance, double beamLength);
        public void add(Force force)
        {
            this.Power += force.Power;
        }
        public bool canAdd(Force force)
        {
            return this.GetType() == force.GetType();
        }
    }
}
