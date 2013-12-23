using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace TestsForSC.force
{
    class Forces : ICollection<Force>
    {
        LinkedList<Force> forces;

        public void ICollection<Force>.Add(Force item)
        {
            bool added = false;
            foreach (Force f in forces)
            {
                if (f.canAdd(item))
                {
                    f.add(item);
                    added = true;
                    break;
                }
            }
            if (!added)
                forces.AddBefore(forces.Last, item);

        }

        public Forces(DistributedBeamForce weight,double beamLength)
        {
            forces = new LinkedList<Force>();
            forces.AddFirst(new ReflectionBeamForce(weight.Power * beamLength / 2, 0));
            forces.AddLast(new ReflectionBeamForce(weight.Power * beamLength / 2, beamLength));
            forces.AddBefore(forces.Last, weight);
        }

        public double getMomentom(double distance)
        {
            double sum = 0;
            foreach (Force f in forces)
            {
                sum += f.getMomentom(distance);
            }
            return sum;
        }
        public double getfMomentomd2x(double distance, double beamLength)
        {
            double sum = 0;
            foreach (Force f in forces)
            {
                sum += f.getfMomentomd2x(distance,beamLength);
            }
            return sum;
        }


        

        void ICollection<Force>.Clear()
        {
            forces.Clear();
        }

        bool ICollection<Force>.Contains(Force item)
        {
            return this.forces.Contains(item);
        }

        void ICollection<Force>.CopyTo(Force[] array, int arrayIndex)
        {
            this.forces.CopyTo(array, arrayIndex);
        }

        int ICollection<Force>.Count
        {
            get { return this.forces.Count; }
        }

        private bool ICollection<Force>.IsReadOnly
        {
            get { return false; }
        }

        bool ICollection<Force>.Remove(Force item)
        {
            return forces.Remove(item);
        }

        IEnumerator<Force> IEnumerable<Force>.GetEnumerator()
        {
            return this.forces.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.forces.GetEnumerator();
        }
    }
}
