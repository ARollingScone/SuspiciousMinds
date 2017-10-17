using SFML.Graphics;
using SFML.Window;

namespace SuspiciousMinds
{
    public class WindowContainer
    {
        public RenderWindow Window { get; private set; }

        public WindowContainer()
        {
            Window = new RenderWindow(new VideoMode(640, 480), "Window");
            Window.SetMouseCursorVisible(false);
        }
    }
}
