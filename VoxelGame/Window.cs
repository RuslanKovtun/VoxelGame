using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;

namespace VoxelGame
{
    public class Window : GameWindow
    {
        private int _fps;
        private double _coveredTime;

        private Chunk _chunk;
        private Camera _camera;

        private Vector3 _cameraPosition = Vector3.Zero;
        private Vector3 _cameraRotation = Vector3.Zero;

        public Window(int width, int height, GraphicsMode mode, string title) : base(width, height, mode, title)
        {
            VSync = VSyncMode.Off;
        }

        protected override void OnLoad(EventArgs eventArgs)
        {
            GL.Enable(EnableCap.CullFace);
            GL.Enable(EnableCap.DepthTest);

            GL.CullFace(CullFaceMode.Back);

            LoadPerspectiveMatrix();

            var voxelPosition = new Vector3(0f, 0f, -1f);

            var moveSpeed = 0.01f;
            var rotateSpeed = 0.1f;

            _camera = new Camera(_cameraPosition, _cameraRotation, moveSpeed, rotateSpeed);
            _chunk = new Chunk();

            _chunk.Generate();

            base.OnLoad(eventArgs);
        }

        protected override void OnUnload(EventArgs eventArgs)
        {
            base.OnUnload(eventArgs);
        }

        protected override void OnUpdateFrame(FrameEventArgs frameEvent)
        {
            _camera.Move();
            _camera.RotateMove();

            base.OnUpdateFrame(frameEvent);
        }

        protected override void OnRenderFrame(FrameEventArgs frameEvent)
        {
            Title = $"Position: {_camera.Position} | Rotation: {_camera.Rotation} | Render Time: {frameEvent.Time}";

            CalculateFPS(frameEvent);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.ClearColor(0f, 0.6f, 1f, 1f);

            _chunk.Render();

            SwapBuffers();

            base.OnRenderFrame(frameEvent);
        }

        private void CalculateFPS(FrameEventArgs frameEvent)
        {
            if (_coveredTime < 1d)
            {
                _fps++;
                _coveredTime += frameEvent.Time;
            }
            else
            {
                Console.WriteLine($"FPS: {_fps}");
                _fps = 0;
                _coveredTime = 0d;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        private void LoadPerspectiveMatrix()
        {
            var fov = MathHelper.PiOver4;

            float aspectRatio = Width / Height;

            var nearPlane = 0.1f;
            var farPlane = 100f;

            GL.MatrixMode(MatrixMode.Projection);

            var perspectiveMatrix = Matrix4.CreatePerspectiveFieldOfView(fov, aspectRatio, nearPlane, farPlane);

            GL.LoadIdentity();
            GL.LoadMatrix(ref perspectiveMatrix);
        }
    }
}
