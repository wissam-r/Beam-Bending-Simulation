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

        VertexBuffer vertexBuffer;
        IndexBuffer indexBuffer;

        BasicEffect basicEffect;
        Matrix world = Matrix.CreateTranslation(0, 0, 0);
        Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, 3), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
        Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.01f, 100f);

        int points;
        const float accuracy = 10f;
        int multipler = 100;
        VertexPositionColor[] primitiveList;
        short[] lineStripIndices;
        private bool ShouldDraw;

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
            ShouldDraw = false;
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
            basicEffect = new BasicEffect(GraphicsDevice);

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

            if (form.NewPointsFlag)
            {
                setVertices();
                form.NewPointsFlag = false;
            }
            else if (form.NewPointPositionFlag)
            {
                updateVertices();
                form.NewPointPositionFlag = false;
            }
             
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
         protected override void Draw(GameTime gameTime)
         {
             GraphicsDevice.Clear(Color.Black);
             if (ShouldDraw)
             {
                 Matrix viewMatrix = Matrix.CreateLookAt(
                    new Vector3(0.0f, 0.0f, (float)(((form.BeamLenght + 10) / 2) / Math.Tan(MathHelper.ToRadians(45 / 2.0f)))),
                    Vector3.Zero,
                    Vector3.Up
                    );

                 Matrix projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.01f, 1000f);
                 basicEffect.World = world;
                 basicEffect.View = viewMatrix;
                 basicEffect.Projection = projectionMatrix;
                 basicEffect.VertexColorEnabled = true;

                 GraphicsDevice.SetVertexBuffer(vertexBuffer);
                 GraphicsDevice.Indices = indexBuffer;

                 RasterizerState rasterizerState = new RasterizerState();
                 rasterizerState.CullMode = CullMode.None;
                 GraphicsDevice.RasterizerState = rasterizerState;

                 foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
                 {
                     pass.Apply();
                     GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(
                                                                    PrimitiveType.TriangleStrip,
                                                                    primitiveList,
                                                                    0,   // vertex buffer offset to add to each element of the index buffer
                                                                    primitiveList.Length,   // number of vertices to draw
                                                                    lineStripIndices,
                                                                    0,   // first index element to read
                                                                    lineStripIndices.Length - 2 // number of primitives to draw
                                                                );
                 }
             }
             base.Draw(gameTime);
             
         }

         private void setVertices()
         {
             points = (int)(form.BeamLenght * 2 * accuracy);

             primitiveList = new VertexPositionColor[points];
             for (int i = 0; i < points/2; i++)
             {
                 Color c = Color.Green;
                 primitiveList[i * 2] = new VertexPositionColor(new Vector3(i / accuracy - (float)form.BeamLenght / 2.0f, 0.0f, 0.0f), c);
                 primitiveList[i * 2 + 1] = new VertexPositionColor(new Vector3(i / accuracy - (float)form.BeamLenght / 2.0f, 10.0f, 0.0f), c);
             }
             updateColors();
             updateDiflection();
             vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), points, BufferUsage.WriteOnly);
             vertexBuffer.SetData<VertexPositionColor>(primitiveList);

             lineStripIndices = new short[points];
             for (int i = 0; i < points; i++)
             {
                 lineStripIndices[i] = (short)(i);
             }
             indexBuffer = new IndexBuffer(graphics.GraphicsDevice, typeof(short), lineStripIndices.Length, BufferUsage.WriteOnly);
             indexBuffer.SetData(lineStripIndices);

             
             ShouldDraw = true;
         }
         private void updateVertices()
         {
             updateColors();
             updateDiflection();

             ShouldDraw = true;
         }

         private void updateColors()
         {
             for (int i = 0; i < points / 2; i++)
             {
                 Color c = new Color((float)Math.Abs(form.MomentomAt(i / accuracy) / form.MaxMomentom), 1 - (float)Math.Abs(form.MomentomAt(i / accuracy) / form.MaxMomentom), 0.01f);
                 primitiveList[i * 2].Color = c;
                 primitiveList[i * 2 + 1].Color = c;
             }
         }
         private void updateDiflection()
         {
             for (int i = 0; i < points / 2; i++)
             {
                 primitiveList[i * 2].Position.Y = (float)form.diflectionAt(i / accuracy)*multipler;
                 primitiveList[i * 2 + 1].Position.Y = primitiveList[i * 2].Position.Y + 10;
             }
         }
    } 
}
