using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

public class Camera
{
    private Vector3 _position;
    private Vector3 _rotation;

    private float _moveSpeed;
    private float _rotateSpeed;

    public Vector3 Position => _position;
    public Vector3 Rotation => _rotation;

    public Camera(Vector3 position, Vector3 rotation, float moveSpeed, float rotateSpeed)
    {
        _position = position;
        _rotation = rotation;

        _moveSpeed = moveSpeed;
        _rotateSpeed = rotateSpeed;
    }

    public void Move()
    {
        var keyboard = Keyboard.GetState();
        var direction = Vector3.Zero;

        if (keyboard.IsKeyDown(Key.W))
        {
            direction += Vector3.UnitZ * _moveSpeed;
        }
        if (keyboard.IsKeyDown(Key.S))
        {
            direction += -Vector3.UnitZ * _moveSpeed;
        }
        if (keyboard.IsKeyDown(Key.A))
        {
            direction += Vector3.UnitX * _moveSpeed / 2;
        }
        if (keyboard.IsKeyDown(Key.D))
        {
            direction += -Vector3.UnitX * _moveSpeed / 2;
        }
        if (keyboard.IsKeyDown(Key.ShiftLeft))
        {
            direction += Vector3.UnitY * _moveSpeed / 2;
        }
        if (keyboard.IsKeyDown(Key.Space))
        {
            direction += -Vector3.UnitY * _moveSpeed / 2;
        }

        Translate(in direction);
    }

    public void RotateMove()
    {
        var keyboard = Keyboard.GetState();
        var direction = Vector3.Zero;

        if (keyboard.IsKeyDown(Key.Left))
        {
            direction = -Vector3.UnitY * _rotateSpeed;
        }
        else if (keyboard.IsKeyDown(Key.Right))
        {
            direction = Vector3.UnitY * _rotateSpeed;
        }
        else if (keyboard.IsKeyDown(Key.Up))
        {
            direction = -Vector3.UnitX * _rotateSpeed;
        }
        else if (keyboard.IsKeyDown(Key.Down))
        {
            direction = Vector3.UnitX * _rotateSpeed;
        }

        Rotate(in direction);
    }

    private void Rotate(in Vector3 rotation)
    {
        if (rotation == Vector3.Zero)
        {
            return;
        }

        _rotation += rotation;

        if (_rotation.X < 0)
        {
            _rotation.X += 360f;
        }
        else if (_rotation.X >= 360)
        {
            _rotation.X -= 360f;
        }
        if (_rotation.Y < 0)
        {
            _rotation.Y += 360f;
        }
        else if (_rotation.Y >= 360)
        {
            _rotation.Y -= 360f;
        }

        GL.Rotate(_rotateSpeed, rotation);
    }

    private void Translate(in Vector3 direction)
    {
        if (direction == Vector3.Zero)
        {
            return;
        }

        _position += direction;

        GL.Translate(direction);
    }
}