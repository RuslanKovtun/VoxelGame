using OpenTK.Graphics.OpenGL;

public class Mesh
{
    private readonly float[] _vertices;
    private readonly float[] _colors;

    private int _vboColor;
    private int _vboVertex;

    private int _vaoIndex;

    public float[] Vertices => _vertices;
    public float[] Colors => _colors;

    public int VaoIndex => _vaoIndex;

    public Mesh(float[] vertices, float[] colors)
    {
        _vertices = vertices;
        _colors = colors;
    }

    public void Init()
    {
        _vaoIndex = GL.GenVertexArray();

        GL.BindVertexArray(_vaoIndex);

        GL.EnableClientState(ArrayCap.VertexArray);
        GL.EnableClientState(ArrayCap.ColorArray);

        GL.BindBuffer(BufferTarget.ArrayBuffer, _vboVertex);
        GL.VertexPointer(3, VertexPointerType.Float, 0, 0);

        GL.BindBuffer(BufferTarget.ArrayBuffer, _vboColor);
        GL.ColorPointer(4, ColorPointerType.Float, 0, 0);

        GL.BindVertexArray(0);
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

        GL.DisableClientState(ArrayCap.VertexArray);
        GL.DisableClientState(ArrayCap.ColorArray);
    }

    public void InitVBO()
    {
        _vboVertex = GL.GenBuffer();
        _vboColor = GL.GenBuffer();

        GL.BindBuffer(BufferTarget.ArrayBuffer, _vboVertex);
        GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

        GL.BindBuffer(BufferTarget.ArrayBuffer, _vboColor);
        GL.BufferData(BufferTarget.ArrayBuffer, _colors.Length * sizeof(float), _colors, BufferUsageHint.StaticDraw);
    }

    private void Delete()
    {
        GL.BindVertexArray(0);
        GL.DeleteVertexArray(_vaoIndex);

        GL.DeleteBuffer(_vboVertex);
        GL.DeleteBuffer(_vboColor);
    }

    ~Mesh()
    {
        Delete();
    }
}
