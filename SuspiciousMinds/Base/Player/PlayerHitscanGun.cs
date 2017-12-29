using SFML.System;
using SuspiciousMinds.Base.Interfaces;
using System;

namespace SuspiciousMinds.Base.Player
{
    public class PlayerHitscanGun : IStepComponent
    {
        private bool m_isFiring;
        private bool m_isCooling;
        private float m_fireDelay = 0;

        // Logic updates in 10ms increments so multiply by 10
        // The firerate below is 1 second.
        private float m_fireRate = 100;

        private Vector2f m_mouseCoords;

        public PlayerHitscanGun(PhysicsComponent physics)
        {
            if (physics == null)
                throw new ArgumentNullException(nameof(physics));
        }

        public void Step(float delta)
        {
            if(m_isCooling)
            {
                m_fireDelay += delta;

                if (m_fireDelay >= m_fireRate)
                {
                    m_isCooling = false;
                    m_fireDelay = 0;
                }
            }

            if(m_isFiring && !m_isCooling)
            {
                Console.WriteLine("Shooting Gun");

                m_isCooling = true;
            }
        }

        public void SetIsFiring(bool state, Vector2f mouseCoords)
        {
            m_isFiring = state;
            m_mouseCoords = mouseCoords;
        }
    }
}
