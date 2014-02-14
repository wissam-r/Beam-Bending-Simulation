using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace forces
{
    public interface Force_
    {
        double Power { set; get; }
        void add(Force_ force);
        bool canAdd(Force_ force);
    }
}
