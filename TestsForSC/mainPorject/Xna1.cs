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
using forces;

namespace mainPorject
{
    class Xna1 : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        XnaFormable home;

        VertexBuffer vertexBuffer;
        IndexBuffer indexBuffer;

        BasicEffect basicEffect;
        Matrix world = Matrix.CreateTranslation(0, 0, 0);
        Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, 3), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
        Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.01f, 100f);

        private int points;
        public float accuracy = 1f;
        public int multipler = 2;
        private VertexPositionColor[] primitiveList;
        private short[] lineStripIndices;
        private bool ShouldDraw;

        public Xna1(XnaFormable formm)
        {
            this.home = formm;
            graphics = new GraphicsDeviceManager(this);
            graphics.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>(graphics_PreparingDeviceSettings);
            Form xnaWindow = (Form)Control.FromHandle((this.Window.Handle));
            xnaWindow.GotFocus += new EventHandler(xnaWindow_GotFocus);
            home.XnaContorl.Resize += new EventHandler(Panel_Resize);

            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            ShouldDraw = false;
        }

        void graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
            e.GraphicsDeviceInformation.PresentationParameters.DeviceWindowHandle = home.XnaContorl.Handle;
        }

        void xnaWindow_GotFocus(object sender, EventArgs e)
        {
            ((Form)sender).Visible = false;
            home.Form.TopMost = false;
        }

        void Panel_Resize(object sender, EventArgs e)
        {
            graphics.PreferredBackBufferWidth = home.XnaContorl.Width;
            graphics.PreferredBackBufferHeight = home.XnaContorl.Height;
            float aspectRatio = (float)home.XnaContorl.Width / home.XnaContorl.Height;
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

            if (home.NewPointsFlag)
            {
                setVertices();
                home.NewPointsFlag = false;
            }
            else if (home.NewPointPositionFlag)
            {
                updateVertices();
                home.NewPointPositionFlag = false;
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
                    new Vector3(0.0f, 0.0f, (float)(((home.Beam.Length + 10) / 2) / Math.Tan(MathHelper.ToRadians(45 / 2.0f)))),
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

         #region vertices
         private void setVertices()
         {
             points = (int)(home.Beam.Length * 2 * accuracy) + 2;

             primitiveList = new VertexPositionColor[points];
             for (int i = 0; i < points/2; i++)
             {
                 Color c = Color.Green;
                 primitiveList[i * 2] = new VertexPositionColor(new Vector3(i / accuracy - (float)home.Beam.Length / 2.0f, -(float)home.Beam.Height / 2, 0.0f), c);
                 primitiveList[i * 2 + 1] = new VertexPositionColor(new Vector3(primitiveList[i*2].Position.X, primitiveList[i*2].Position.Y + (float)home.Beam.Height, 0.0f), c);
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
                 Color c = new Color((float)Math.Abs(home.Beam.forces.getMomentom(i / accuracy) / home.Beam.MaxMomentom), 1 - (float)Math.Abs(home.Beam.forces.getMomentom(i / accuracy) / home.Beam.MaxMomentom), 0.01f);
                 primitiveList[i * 2].Color = c;
                 primitiveList[i * 2 + 1].Color = c;
             }
         }
         private void updateDiflection()
         {
             updateDiflection_Y();
             updateDiflection_X();
         }
         private void updateDiflection_Y()
         {
             for (int i = 0; i < points / 2; i++)
             {
                 primitiveList[i * 2].Position.Y = (float)home.Beam.getDiflectionAt(i / accuracy) * multipler - (float)home.Beam.Height;
                 primitiveList[i * 2 + 1].Position.Y = primitiveList[i * 2].Position.Y + (float)home.Beam.Height;
             }
         }
         private void updateDiflection_X()
         {
             for (int i = 1; i < points / 2 - 1; i++)
             {
                 double momentom = home.Beam.getMomentomAt(i / accuracy);
                 if (momentom == 0) continue;
                 double p = home.Beam.getI(i / accuracy) * home.Beam.E / home.Beam.getMomentomAt(i / accuracy);
                 if (p == 0) continue;
                 double Es;
                 Es = home.Beam.getNaturalSerfaceDepth() / p;
                 primitiveList[i * 2 - 2].Position.X -= (float)Es;
                 primitiveList[i * 2 + 2].Position.X += (float)Es;

                 Es = (home.Beam.Height - home.Beam.getNaturalSerfaceDepth()) / p;
                 primitiveList[i * 2 - 1].Position.X += (float)Es;
                 primitiveList[i * 2 + 1].Position.X -= (float)Es;
             }
         }
        #endregion
    } 
}
