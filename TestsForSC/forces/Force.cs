using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace forces
{
    public abstract class Force : Force_
    {
        public const int factor = 1;//للتحويل بين الواحدات
        public Force(double power)
        {
            Power = power;
        }
        public double Power { set; get; }
        protected void addPower(Force_ force)
        {
            this.Power += force.Power;
        }
        protected bool sameType(Force_ force)
        {
            return this.GetType() == force.GetType();
        }


        public abstract void add(Force_ force);

        public abstract bool canAdd(Force_ force);
    }
}
