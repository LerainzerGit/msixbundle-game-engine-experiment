using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private BasicEffect _effect;
        private VertexBuffer _cubeVertices;
        private float _rotation;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void LoadContent()
        {
            _effect = new BasicEffect(GraphicsDevice)
            {
                VertexColorEnabled = true,
                Projection = Matrix.CreatePerspectiveFieldOfView(
                    MathHelper.PiOver4,
                    GraphicsDevice.Viewport.AspectRatio,
                    0.1f, 100f),
                View = Matrix.CreateLookAt(new Vector3(0, 0, 5), Vector3.Zero, Vector3.Up)
            };

            _cubeVertices = BuildCube(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            _rotation += (float)gameTime.ElapsedGameTime.TotalSeconds;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _effect.World = Matrix.CreateRotationY(_rotation) * Matrix.CreateRotationX(_rotation * 0.5f);
            GraphicsDevice.SetVertexBuffer(_cubeVertices);

            foreach (var pass in _effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 12);
            }

            base.Draw(gameTime);
        }

        private static VertexBuffer BuildCube(GraphicsDevice device)
        {
            var verts = new VertexPositionColor[36];
            Vector3[] c =
            {
                new(-1,-1,-1), new(1,-1,-1), new(1,1,-1), new(-1,1,-1),
                new(-1,-1,1),  new(1,-1,1),  new(1,1,1),  new(-1,1,1)
            };
            int[][] faces =
            {
                new[]{0,1,2,0,2,3}, new[]{5,4,7,5,7,6},
                new[]{4,0,3,4,3,7}, new[]{1,5,6,1,6,2},
                new[]{3,2,6,3,6,7}, new[]{4,5,1,4,1,0}
            };
            Color[] faceColors = { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Orange, Color.Purple };

            int vi = 0;
            for (int f = 0; f < 6; f++)
                foreach (var idx in faces[f])
                    verts[vi++] = new VertexPositionColor(c[idx], faceColors[f]);

            var buffer = new VertexBuffer(device, typeof(VertexPositionColor), 36, BufferUsage.WriteOnly);
            buffer.SetData(verts);
            return buffer;
        }
    }
}
