using SuspiciousMinds.Base.Interfaces;
using System;
using SFML.Graphics;
using SFML.System;

namespace SuspiciousMinds.Base.Player
{
    public class PixelGridDisplay : IDisplayComponent
    {
        private PhysicsComponent m_physicsComponent;
        private PixelGrid m_pixelGrid;

        public PixelGridDisplay(PixelGrid grid, PhysicsComponent physics)
        {
            m_pixelGrid = grid
                ?? throw new ArgumentNullException(nameof(grid));

            m_physicsComponent = physics 
                ?? throw new ArgumentNullException(nameof(physics));
        }

        public void Draw(RenderTarget target)
        {
            var position = m_physicsComponent.Position;

            foreach(var key in m_pixelGrid.Grid.Keys)
            {
                const int size = 5;

                var shape = new RectangleShape(new Vector2f(size, size))
                {
                    Position = m_physicsComponent.Position + (key * size),
                    FillColor = Color.Black,
                    OutlineColor = m_pixelGrid.Grid[key],
                    OutlineThickness = 1
                };

                target.Draw(shape);
            }
        }
    }
}
