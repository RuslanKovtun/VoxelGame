using OpenTK.Graphics.OpenGL;

public class MeshRenderer
{
    private readonly Mesh _mesh;

    public MeshRenderer(Mesh mesh)
    {
        _mesh = mesh;
    }

    public void Render()
    {
        GL.BindVertexArray(_mesh.VaoIndex);
        GL.DrawArrays(PrimitiveType.TriangleStrip, 0, _mesh.Vertices.Length / 3);
    }
}