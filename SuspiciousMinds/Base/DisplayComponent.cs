using SFML.Graphics;

namespace SuspiciousMinds.Base
{
    public class DisplayComponent
    {
        private readonly CircleShape m_shape = new CircleShape(50);

        private PhysicsComponent m_physicsComponent;

        public void SetPhysics(PhysicsComponent component)
        {
            m_physicsComponent = component;
        }

        public void Draw(RenderTarget target)
        {
            m_shape.Position = m_physicsComponent.Position;

            m_shape.FillColor = new Color(100, 50, 100);

            target.Draw(m_shape);
        }
    }
}
