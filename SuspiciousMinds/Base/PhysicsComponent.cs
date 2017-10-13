using SFML.System;

namespace SuspiciousMinds.Base
{
    public class PhysicsComponent
    {
        private Vector2f m_velocity;

        public Vector2f Acceleration { get; set; } = new Vector2f();
        public Vector2f Position { get; private set; } = new Vector2f();

        public void Step(float delta)
        {
            m_velocity += Acceleration * delta;
            Position += m_velocity * delta;
        }
    }
}
