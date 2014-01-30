using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TestsForSC.beem;

namespace TestsForSC
{
    //static class Program 
    //{
        
    //    /// <summary>
    //    /// The main entry point for the application.
    //    /// </summary>
    //    [STAThread]
    //    static void Main()
    //    {
    //        Application.EnableVisualStyles();
    //        Application.SetCompatibleTextRenderingDefault(false);
    //        Application.Run(new jasam());  
    //    }
    //}

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static Xna1 game;
        static void Main(string[] args)
        {
            //jasam form = new jasam();
            //form.Disposed += new EventHandler(form_Disposed);
            //using (game = new Xna1(form))
            //{
            //    form.Show();
            //    form.TopMost = true;
            //    game.Run();
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainBeamSpec());

            //using (Game1 game = new Game1())
            //{
            //    game.Run();
            //}
        }

        static void form_Disposed(object sender, EventArgs e)
        {
            game.Exit();
        }
    }

}
