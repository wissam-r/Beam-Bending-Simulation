using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace forces
{
    public class Forces
    {
        LinkedList<BeamForce> forces;        

        public Forces(double weight,Double beamLength)
        {
            forces = new LinkedList<BeamForce>();
            forces.AddFirst(new ReflectionBeamForce(weight / 2, 0,beamLength));
            forces.AddLast(new ReflectionBeamForce(weight / 2, beamLength,beamLength));
            forces.AddBefore(forces.Last, new DistributedBeamForce(weight/beamLength,0,beamLength,beamLength));
        }

        public BeamForce this[double value]
        {
            get
            {
                foreach(BeamForce f in forces) 
                {
                    if (f is PointBaemForce)
                    {
                        if ((f as PointBaemForce).Position == value)
                        {
                            return f;
                        }
                    }
                }
                return null;
            }
        }

        public BeamForce this[double value1, double value2]
        {
            get
            {
                foreach (BeamForce f in forces)
                {
                    if (f is DistributedBeamForce)
                    {
                        if ((f as DistributedBeamForce).Start == value1 &&
                            (f as DistributedBeamForce).End == value2)
                        {
                            return f;
                        }
                    }
                }
                return null;
            }
        }

        public BeamForce this[int value]
        {
            get { return forces.ElementAt(value); }
        }

        public void Add(BeamForce item)
        {
            if(item is ReflectionBeamForce)
                return;
            bool added = false;
            foreach (BeamForce f in forces)
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
            this.forces.First.Value.add(item.getReflection(0));
            this.forces.Last.Value.add(item.getReflection(1));
        }

        public void AddAll(Forces alot)
        {
            foreach (BeamForce f in alot.forces)
            {
                this.Add(f);
            }
        }

        public double getShaer(double distance)
        {
            double sum = 0;
            foreach (BeamForce f in forces)
            {
                sum += f.getShaer(distance);
            }
            return sum;
        }
        public double getMomentom(double distance)
        {
            double sum = 0;
            foreach (BeamForce f in forces)
            {
                sum += f.getMomentom(distance);
            }
            return sum;
        }
        public double getfMomentomd2x(double distance)
        {
            double sum = 0;
            foreach (BeamForce f in forces)
            {
                sum += f.getfMomentomd2x(distance);
            }
            return sum;
        }

        public void Clear()
        {
            forces.Clear();
        }

        public bool Contains(BeamForce item)
        {
            return this.forces.Contains(item);
        }

        public void CopyTo(BeamForce[] array, int arrayIndex)
        {
            this.forces.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.forces.Count; }
        }

        public bool Remove(BeamForce item)
        {
            return forces.Remove(item);
        }
    }
}
