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
using mainPorject;

namespace WindowsGameLibrary1
{
    public class XnaBeam:Game
    {
        private GraphicsDeviceManager graphics;
        XnaFormable home;

        VertexBuffer vertexBuffer;
        IndexBuffer indexBuffer;

        SpriteBatch spriteBatch;
        BasicEffect basicEffect;
        Matrix world = Matrix.CreateTranslation(0, 0, 0);
        Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, 3), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
        Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.01f, 100f);

        
        private int points;
        private VertexPositionColor[] primitiveList;
        private Vector3 leftSupportPos, rightSupportPos;
        private Vector3 leftSupportSize, rightSupportSize;
        private Vector3 F1pos, F2pos;
        private short[] lineStripIndices;

        public float accuracy = 1f;
        public int multipler = 2;
        private bool ShouldDraw;

        private Texture2D rightSupport,leftSupport,F1,F2;

        public XnaBeam(XnaFormable formm)
        {
            Content.RootDirectory = "Content";

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
            basicEffect = new BasicEffect(GraphicsDevice);
            if (home.Beam != null)
            {
                initializeWorld();
            }
            base.Initialize();
        }
        private void initializeWorld()
        {
            Matrix viewMatrix = Matrix.CreateLookAt(
                        new Vector3(0.0f, 0.0f, (float)(((home.Beam.Length + 10) / 2) / Math.Tan(MathHelper.ToRadians(45 / 2.0f)))),
                        Vector3.Zero,
                        Vector3.Up
                        );
            float depth = (float)((home.Beam.Length / 2) / Math.Sin(MathHelper.ToRadians(45 / 2f)))*1.2f;
            Matrix projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.01f, depth);
            basicEffect.World = world;
            basicEffect.View = viewMatrix;
            basicEffect.Projection = projectionMatrix;
            basicEffect.VertexColorEnabled = true;
        }

        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            rightSupport = Content.Load<Texture2D>("RightSupport");
            leftSupport = Content.Load<Texture2D>("LeftSupport");
            F1 = Content.Load<Texture2D>("force");
            F2 = Content.Load<Texture2D>("force");
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
            if (home.NewTestForces)
            {
                updateFoces();
                home.NewTestForces = false;
            }
             
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
         protected override void Draw(GameTime gameTime)
         {
             GraphicsDevice.Clear(Color.LightGray);
             if (ShouldDraw)
             {
                 

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
                 spriteBatch.Begin();
                 //int supportsize = (int)(home.Beam.Length / 100);
                 spriteBatch.Draw(leftSupport,
                              new Rectangle((int)leftSupportPos.X, (int)leftSupportPos.Y, (int)leftSupportSize.X, (int)leftSupportSize.Y),
                              Color.White);
                 spriteBatch.Draw(rightSupport,
                              new Rectangle((int)rightSupportPos.X, (int)rightSupportPos.Y, (int)rightSupportSize.X, (int)rightSupportSize.Y),
                              Color.White);
                 if (home.Beam.F1 != null)
                     spriteBatch.Draw(F1, new Vector2(F1pos.X, F1pos.Y), Color.White);
                 if (home.Beam.F2 != null)
                     spriteBatch.Draw(F2, new Vector2(F2pos.X, F2pos.Y), Color.White);
                 spriteBatch.End();
             }

             

             base.Draw(gameTime);
             
         }

         #region vertices
         float height;
         private void setVertices()
         {
             initializeWorld();
             height = (float)home.Beam.Length / 20;
             points = (int)(home.Beam.Length * 2 * accuracy) + 2;

             primitiveList = new VertexPositionColor[points];
             for (int i = 0; i < points/2; i++)
             {
                 Color c = Color.Green;
                 primitiveList[i * 2] = new VertexPositionColor(new Vector3(i / accuracy - (float)home.Beam.Length / 2.0f, -(float)height / 2, 0.0f), c);
                 primitiveList[i * 2 + 1] = new VertexPositionColor(new Vector3(primitiveList[i * 2].Position.X, primitiveList[i * 2].Position.Y + (float)height, 0.0f), c);
             }
             updateVertices();
             vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), points, BufferUsage.WriteOnly);
             vertexBuffer.SetData<VertexPositionColor>(primitiveList);

             lineStripIndices = new short[points];
             for (int i = 0; i < points; i++)
             {
                 lineStripIndices[i] = (short)(i);
             }
             indexBuffer = new IndexBuffer(graphics.GraphicsDevice, typeof(short), lineStripIndices.Length, BufferUsage.WriteOnly);
             indexBuffer.SetData(lineStripIndices);

             Vector3 size = new Vector3((float)home.Beam.Length / 16);
             Vector3 temp;
             leftSupportPos = graphics.GraphicsDevice.Viewport.Project(primitiveList.First().Position, basicEffect.Projection, basicEffect.View, basicEffect.World);
             temp = graphics.GraphicsDevice.Viewport.Project(primitiveList.First().Position + size, basicEffect.Projection, basicEffect.View, basicEffect.World);
             leftSupportSize = temp - leftSupportPos;
             leftSupportSize.X = Math.Abs(leftSupportSize.X) * 1.5f;
             leftSupportSize.Y = Math.Abs(leftSupportSize.Y);
             leftSupportPos.X -= leftSupportSize.X / 2;

             rightSupportPos = graphics.GraphicsDevice.Viewport.Project(primitiveList[points - 2].Position, basicEffect.Projection, basicEffect.View, basicEffect.World);
             temp = graphics.GraphicsDevice.Viewport.Project(primitiveList[points - 2].Position + size, basicEffect.Projection, basicEffect.View, basicEffect.World);
             rightSupportSize = temp - rightSupportPos;
             rightSupportSize.X = Math.Abs(rightSupportSize.X)*0.9f;
             rightSupportSize.Y = Math.Abs(rightSupportSize.Y);
             rightSupportPos.X -= rightSupportSize.X / 2;
             
             ShouldDraw = true;
         }
         private void updateVertices()
         {
             updateColors();
             updateDiflection();
             updateFoces();
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
             //updateDiflection_X();
         }
         private void updateDiflection_Y()
         {
             bool sent = false;
             for (int i = 0; i < points / 2; i++)
             {
                 float def = (float)home.Beam.getDiflectionAt(i / accuracy);
                 primitiveList[i * 2].Position.Y = def * multipler - height;
                 primitiveList[i * 2 + 1].Position.Y = primitiveList[i * 2].Position.Y + height;
                 if (def < home.Beam.MaxDiflection && !sent)
                 {
                     home.sendMassege("break def|" + def + "|" + i / accuracy/100);
                     sent = true;
                 }
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
                 double Es = home.Beam.getNaturalSerfaceDepth() / p;
                 primitiveList[i * 2 - 2].Position.X -= (float)Es;
                 primitiveList[i * 2 + 2].Position.X += (float)Es;

                 Es = (home.Beam.Height - home.Beam.getNaturalSerfaceDepth()) / p;
                 primitiveList[i * 2 - 1].Position.X += (float)Es;
                 primitiveList[i * 2 + 1].Position.X -= (float)Es;
             }
         }

         private void updateFoces()
         {
             
             int indexF ;
             if (home.Beam.F1 != null)
             {
                 indexF = (int)(home.Beam.F1.Position * 2 * accuracy) + 1;
                 indexF += indexF % 2 == 0 ? 1 : 0;
                 F1pos = graphics.GraphicsDevice.Viewport.Project(primitiveList[indexF].Position, basicEffect.Projection, basicEffect.View, basicEffect.World);
                 F1pos.Y -= F1.Height;
                 F1pos.X -= F1.Width / 2;
             }
             if (home.Beam.F2 != null)
             {
                 indexF = (int)(home.Beam.F2.Position * 2 * accuracy) + 1;
                 indexF += indexF % 2 == 0 ? 1 : 0;
                 F2pos = graphics.GraphicsDevice.Viewport.Project(primitiveList[indexF].Position, basicEffect.Projection, basicEffect.View, basicEffect.World);
                 F2pos.Y -= F2.Height;
                 F2pos.X -= F2.Width / 2;
             }
         }
        #endregion
    } 
}

