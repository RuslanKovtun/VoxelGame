using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics;

namespace VoxelGame
{
    public class Program
    {
        private static void Main(string[] args)
        {
            using(var window = new Window(900, 900, GraphicsMode.Default, "VoxelGame"))
            {
                window.Run();
            }
        }
    }
}
