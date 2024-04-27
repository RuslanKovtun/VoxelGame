using OpenTK;

public class Chunk
{
    public const byte WIDTH = 16;
    public const byte HEIGHT = 64;

    private Voxel[,,] _voxels = new Voxel[WIDTH, HEIGHT, WIDTH];

    public void Generate()
    {
        for (int x = 0; x < WIDTH; x++)
        {
            for (int y = 0; y < HEIGHT; y++)
            {
                for (int z = 0; z < WIDTH; z++)
                {
                    var voxel = new Voxel(new Vector3(x, y, z));

                    voxel.Init();

                    _voxels[x, y, z] = voxel;
                }
            }
        }
    }

    public void Render()
    {
        foreach (Voxel voxel in _voxels)
        {
            voxel.Renderer.Render();
        }
    }
}