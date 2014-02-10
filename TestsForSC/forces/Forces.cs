using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace forces
{
    public class Forces
    {
        LinkedList<Force> forces;
        private double beamLength;
        

        public Forces(double weight,double beamLength)
        {
            this.beamLength = beamLength;
            forces = new LinkedList<Force>();
            forces.AddFirst(new ReflectionBeamForce(weight / 2, 0));
            forces.AddLast(new ReflectionBeamForce(weight / 2, beamLength));
            forces.AddBefore(forces.Last, new DistributedBeamForce(weight/beamLength,0,beamLength));
        }



        public void Add(Force item)
        {
            if(item is ReflectionBeamForce)
                return;
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
            this.forces.First.Value.add(item.getReflectionLeft(beamLength));
            this.forces.Last.Value.add(item.getReflectionRight(beamLength));
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
                sum += f.getfMomentomd2x(distance, beamLength);
            }
            return sum;
        }




        public void Clear()
        {
            forces.Clear();
        }

        public bool Contains(Force item)
        {
            return this.forces.Contains(item);
        }

        public void CopyTo(Force[] array, int arrayIndex)
        {
            this.forces.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.forces.Count; }
        }

        public bool Remove(Force item)
        {
            return forces.Remove(item);
        }
    }
}
