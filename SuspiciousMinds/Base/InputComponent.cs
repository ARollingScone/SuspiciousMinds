using SFML.System;
using System;
using System.Collections.Generic;
using static SFML.Window.Keyboard;

namespace SuspiciousMinds.Base
{
    public class InputComponent
    {
        private PhysicsComponent m_physicsComponent;
        private Dictionary<Key, bool> m_keys = new Dictionary<Key, bool>
        {
            { Key.W, false },
            { Key.A, false },
            { Key.S, false },
            { Key.D, false }
        };

        // For multiplayer
        public Guid HardwareId { get; } = new Guid();

          public void SetPhysics(PhysicsComponent component)
        {
            m_physicsComponent = component;
        }

        public void SetKey(Key key, bool state)
        {
            m_keys[key] = state;
        }

        public void Update()
        {
            var x = 0;
            var y = 0;

            if (m_keys[Key.W])
                y -= 1;

            if (m_keys[Key.A])
                x -= 1;

            if (m_keys[Key.S])
                y += 1;

            if (m_keys[Key.D])
                x += 1;

            m_physicsComponent.Acceleration = new Vector2f(0.01f * x, 0.01f * y);
        }
    }
}
