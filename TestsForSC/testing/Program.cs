using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeamDesign;
namespace testing
{
    class Program
    {
        static void Main(string[] args)
        {
            WithMaxAs xb = new WithMaxAs(200 * 1000000, 250, 240, 20);
            Console.WriteLine(xb.AreaS + " " + xb.B + " " + xb.D + " " + xb.Fc + " " + xb.Fy + " " + xb.Mu);

            Console.WriteLine();
            Console.WriteLine();
            xb.print();

            Console.Read();
        }
    }
}
