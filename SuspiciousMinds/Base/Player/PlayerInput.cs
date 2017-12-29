using SFML.System;
using SuspiciousMinds.Base.Interfaces;
using System.Collections.Generic;
using static SFML.Window.Keyboard;
using static SFML.Window.Mouse;

namespace SuspiciousMinds.Base.Player
{
    public class PlayerInput : IInputComponent
    {
        private PhysicsComponent m_physicsComponent;
        private PlayerHitscanGun m_hitscanGun;

        public Vector2f MouseCoords { get; set; } = new Vector2f();

        public Dictionary<Key, bool> Keys { get; } = new Dictionary<Key, bool>
        {
            { Key.W, false },
            { Key.A, false },
            { Key.S, false },
            { Key.D, false }
        };

        public Dictionary<Button, bool> MouseButtons { get; } = new Dictionary<Button, bool>
        {
            { Button.Left, false },
            { Button.Right, false },
            { Button.Middle, false }
        };

        public void SetPhysics(PhysicsComponent component)
        {
            m_physicsComponent = component;
        }

        public void SetGun(PlayerHitscanGun gun)
        {
            m_hitscanGun = gun;
        }

        public void Update()
        {
            if (m_physicsComponent == null)
                return;

            var x = 0;
            var y = 0;

            if (Keys[Key.W])
                y -= 1;

            if (Keys[Key.A])
                x -= 1;

            if (Keys[Key.S])
                y += 1;

            if (Keys[Key.D])
                x += 1;

            m_physicsComponent.Acceleration = new Vector2f(0.01f * x, 0.01f * y);
            m_physicsComponent.Facing = MouseCoords;

            // Update Gun
            m_hitscanGun.SetIsFiring(MouseButtons[Button.Left], MouseCoords);
        }
    }
}
