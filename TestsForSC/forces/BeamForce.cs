using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace forces
{
    public interface BeamForce : Force_
    {
        Double BeamLength { get; }
        double getMomentom(double distance);
        double getShaer(double distance);
        double getfMomentomd2x(double distance);
        ReflectionBeamForce getReflection(int x); 
    }
}
