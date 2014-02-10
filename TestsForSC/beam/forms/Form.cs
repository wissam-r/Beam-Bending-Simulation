using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beam.forms
{
    public interface Form
    {
        double crossSectionalArea(); //Area Calculation //حساب مساحة المقطع العرضي
        double distanceCenterGravity();// Distance from the center of gravity // البعد عن مركز الثقل
        double momentInertiaNonCrackedSection();//Moment inertia non-cracked section // عزم العطالة حول مركز الجسم غير المتشقق

    }
}
