using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class Program
    {
        static void Main(string[] args)
        {
            Core.Display.Init(1920, 1080, "Display");
            Core.Display.Start();
        }
    }
}