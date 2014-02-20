using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsGameLibrary1;

namespace mainPorject
{
    static class Program
    {
        static XnaBeam game;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            mainWorkForm form = new mainWorkForm();
            form.Disposed += new EventHandler(form_Disposed);
            using (game = new XnaBeam(form))
            {
                form.Show();
                form.TopMost = true;
                game.Run();
            }
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new mainWorkForm());
        }

        static void form_Disposed(object sender, EventArgs e)
        {
            game.Exit();
        }
    }
}
