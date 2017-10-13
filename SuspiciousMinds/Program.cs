using SFML.Graphics;
using SFML.Window;
using SuspiciousMinds.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SuspiciousMinds
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thedium().Run(TimeSpan.FromMilliseconds(8));
        }
    }
}
