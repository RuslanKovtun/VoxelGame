using OpenTK;

public class Voxel
{
    private MeshRenderer _renderer;
    public MeshRenderer Renderer => _renderer;

    private Vector3 _position;
    public Vector3 Position => _position;

    public Voxel(Vector3 position)
    {
        _position = position;
    }

    public void Init()
    {
        var vertices = new float[]
        {
            // front
            0f + _position.X, 0f + _position.Y, 1f + _position.Z,
            1f + _position.X, 0f + _position.Y, 1f + _position.Z,
            0f + _position.X, 1f + _position.Y, 1f + _position.Z,
            1f + _position.X, 1f + _position.Y, 1f + _position.Z,

            // back
            0f + _position.X, 0f + _position.Y, 0f + _position.Z,
            0f + _position.X, 1f + _position.Y, 0f + _position.Z,
            1f + _position.X, 0f + _position.Y, 0f + _position.Z,
            1f + _position.X, 1f + _position.Y, 0f + _position.Z,

            // top
            0f + _position.X, 1f + _position.Y, 0f + _position.Z,
            0f + _position.X, 1f + _position.Y, 1f + _position.Z,
            1f + _position.X, 1f + _position.Y, 0f + _position.Z,
            1f + _position.X, 1f + _position.Y, 1f + _position.Z,

            // bottom
            0f + _position.X, 0f + _position.Y, 0f + _position.Z,
            1f + _position.X, 0f + _position.Y, 0f + _position.Z,
            0f + _position.X, 0f + _position.Y, 1f + _position.Z,
            1f + _position.X, 0f + _position.Y, 1f + _position.Z,

            // right
            0f + _position.X, 0f + _position.Y, 0f + _position.Z,
            0f + _position.X, 0f + _position.Y, 1f + _position.Z,
            0f + _position.X, 1f + _position.Y, 0f + _position.Z,
            0f + _position.X, 1f + _position.Y, 1f + _position.Z,

            // left
            1f + _position.X, 0f + _position.Y, 0f + _position.Z,
            1f + _position.X, 1f + _position.Y, 0f + _position.Z,
            1f + _position.X, 0f + _position.Y, 1f + _position.Z,
            1f + _position.X, 1f + _position.Y, 1f + _position.Z,
        };

        var colors = new float[]
        {
            0f, 1f, 0f, 1f,
            0f, 1f, 0f, 1f,
            0f, 1f, 0f, 1f,
            0f, 1f, 0f, 1f,

            0f, 1f, 0f, 1f,
            0f, 1f, 0f, 1f,
            0f, 1f, 0f, 1f,
            0f, 1f, 0f, 1f,

            0f, 1f, 0f, 1f,
            0f, 1f, 0f, 1f,
            0f, 1f, 0f, 1f,
            0f, 1f, 0f, 1f,

            0f, 1f, 0f, 1f,
            0f, 1f, 0f, 1f,
            0f, 1f, 0f, 1f,
            0f, 1f, 0f, 1f,

            0f, 1f, 0f, 1f,
            0f, 1f, 0f, 1f,
            0f, 1f, 0f, 1f,
            0f, 1f, 0f, 1f,

            0f, 1f, 0f, 1f,
            0f, 1f, 0f, 1f,
            0f, 1f, 0f, 1f,
            0f, 1f, 0f, 1f,
        };

        var mesh = new Mesh(vertices, colors);
        _renderer = new MeshRenderer(mesh);

        mesh.InitVBO();
        mesh.Init();
    }
}
