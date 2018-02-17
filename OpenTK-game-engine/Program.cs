using Engine.Core;
namespace Engine
{
    class Program
    {
        static void Main(string[] args)
        {
            Display.Init(1920, 1080, "Display");
            Display.Start();
        }
    }
}