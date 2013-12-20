using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsForSC.beem
{
    class NonReinRecBeem : Beem
    {
        
        
        public NonReinRecBeem(double cP,double h ,double l , double b ) 
            :base(cP)
        {
            Form = new forms.Rectangle(h, l, b);
            forms.Rectangle Rectangle = (forms.Rectangle)Form;
             
        }

        
        
    }
}
