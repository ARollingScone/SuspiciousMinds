using SuspiciousMinds.Base.Interfaces;
using System;
using SFML.Graphics;
using SFML.System;
using SuspiciousMinds.Helpers;

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
            const int size = 5;

            var centre = m_physicsComponent.Position + (m_pixelGrid.Centre * size);

            var rotation = AngleHelpers.GetRotation(
                centre,
                m_physicsComponent.Facing);

            rotation += AngleHelpers.ToRadians(90);


            foreach (var key in m_pixelGrid.Grid.Keys)
            {
                var pixelPosition = m_physicsComponent.Position + (key * size);
                var rotatedPosition = AngleHelpers.Rotate(pixelPosition - centre, rotation) + centre;

                var shape = new RectangleShape(new Vector2f(size, size))
                {
                    Position = rotatedPosition,
                    FillColor = Color.Black,
                    OutlineColor = m_pixelGrid.Grid[key],
                    OutlineThickness = 1
                };

                target.Draw(shape);
            }
        }
    }
}
