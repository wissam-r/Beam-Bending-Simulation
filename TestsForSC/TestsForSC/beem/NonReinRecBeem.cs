using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsForSC.beem
{
    class NonReinRecBeem : Beem
    {
        double As; 
        
        public NonReinRecBeem(double cS,double h ,double l , double b ) 
            :base(cS)
        {
            Form = new forms.Rectangle(h, l, b);
            forms.Rectangle Rectangle = (forms.Rectangle)Form;
            As = getCrossSectionalArea(); 
        }

        
        
    }
}
