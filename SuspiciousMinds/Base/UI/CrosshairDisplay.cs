using SuspiciousMinds.Base.Interfaces;
using System;
using SFML.Graphics;
using SFML.System;

namespace SuspiciousMinds.Base.UI
{
    public class CrosshairDisplay : IDisplayComponent
    {
        private IInputComponent m_inputComponent;
        private float radius = 4;

        public CrosshairDisplay(IInputComponent inputComponent)
        {
            m_inputComponent = inputComponent 
                ?? throw new ArgumentNullException(nameof(inputComponent));
        }

        public void Draw(RenderTarget target)
        {
            var cornerAA = m_inputComponent.MouseCoords - new Vector2f(radius, radius);
            var cornerAB = m_inputComponent.MouseCoords - new Vector2f(radius, -radius);
            var cornerBB = m_inputComponent.MouseCoords - new Vector2f(-radius, -radius);
            var cornerBA = m_inputComponent.MouseCoords - new Vector2f(-radius, radius);

            var lineA = new []
            {
                new Vertex(cornerAA, Color.Green),
                new Vertex(cornerBB, Color.Green)
            };

            var lineB = new[]
{
                new Vertex(cornerAB, Color.Green),
                new Vertex(cornerBA, Color.Green)
            };

            target.Draw(lineA, PrimitiveType.Lines);
            target.Draw(lineB, PrimitiveType.Lines);
        }
    }
}
