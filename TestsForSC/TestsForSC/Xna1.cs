using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Windows.Forms;

namespace TestsForSC
{
    class Xna1 : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        jasam form;

        public Xna1(jasam formm)
        {
            this.form = formm;
            graphics = new GraphicsDeviceManager(this);
            graphics.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>(graphics_PreparingDeviceSettings);
            Form xnaWindow = (Form)Control.FromHandle((this.Window.Handle));
            xnaWindow.GotFocus += new EventHandler(xnaWindow_GotFocus);
            form.XnaContorl.Resize += new EventHandler(Panel_Resize);

            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }
        void graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
            e.GraphicsDeviceInformation.PresentationParameters.DeviceWindowHandle = form.XnaContorl.Handle;
        }

        void xnaWindow_GotFocus(object sender, EventArgs e)
        {
            ((Form)sender).Visible = false;
            form.TopMost = false;
        }

        void Panel_Resize(object sender, EventArgs e)
        {
            graphics.PreferredBackBufferWidth = form.XnaContorl.Width;
            graphics.PreferredBackBufferHeight = form.XnaContorl.Height;
            float aspectRatio = (float)form.XnaContorl.Width / form.XnaContorl.Height;
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {

        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

         protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
         protected override void Draw(GameTime gameTime)
         {
             GraphicsDevice.Clear(Color.Black);

             base.Draw(gameTime);
         }
    }
}
