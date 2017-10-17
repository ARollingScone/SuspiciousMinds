using SFML.System;
using SuspiciousMinds.Base;
using SuspiciousMinds.Base.Interfaces;
using SuspiciousMinds.Factories;
using System;

namespace SuspiciousMinds
{
    public class Thedium
    {
        private DateTime m_currentTime;
        private DateTime m_previousTime;
        private TimeSpan m_difference;

        private bool m_killMe;

        private EntityContainer m_container;
        private WindowContainer m_windowContainer;

        public Thedium()
        {
            m_container = new EntityContainer();
            m_windowContainer = new WindowContainer();

            m_windowContainer.Window.Closed += Window_Closed;
            m_windowContainer.Window.KeyPressed += Window_KeyPressed;
            m_windowContainer.Window.KeyReleased += Window_KeyReleased;
            m_windowContainer.Window.MouseMoved += Window_MouseMoved;

            m_container.Entities.Add(PlayerFactory.Create());
            m_container.Entities.Add(UIFactory.CreateCrosshair());
        }

        private void Window_MouseMoved(object sender, SFML.Window.MouseMoveEventArgs e)
        {
            foreach (var entity in m_container.Entities)
            {
                var input = entity.GetComponent<IInputComponent>();
                if(input != null)
                    input.MouseCoords = new Vector2f(e.X, e.Y);
            }
        }

        private void Window_KeyReleased(object sender, SFML.Window.KeyEventArgs e)
        {
            foreach(var entity in m_container.Entities)
            {
                var input = entity.GetComponent<IInputComponent>();
                if (input != null)
                    input.Keys[e.Code] = false;
            }
        }

        private void Window_KeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            foreach (var entity in m_container.Entities)
            {
                var input = entity.GetComponent<IInputComponent>();
                if (input != null)
                    input.Keys[e.Code] = true;
            }
        }

        public void Run(TimeSpan heartbeat)
        {
            m_previousTime = DateTime.Now;
            m_currentTime = DateTime.Now;

            while (!m_killMe)
            {
                m_previousTime = m_currentTime;
                m_currentTime = DateTime.Now;

                m_difference += (m_currentTime - m_previousTime);

                while(m_difference >= heartbeat)
                {
                    Intergrate();
                    m_difference -= heartbeat;
                }

                Draw();
            }       
        }

        public void KillMe()
        {
            m_killMe = true;
            m_windowContainer.Window.Closed -= Window_Closed;
            m_windowContainer.Window.Close();
        }

        private void Intergrate()
        {
            foreach(var entity in m_container.Entities)
            {
                entity.GetComponent<IInputComponent>()?.Update();
                entity.GetComponent<PhysicsComponent>()?.Step(1.0f);
            }
        }

        private void Draw()
        {
            if (!m_windowContainer.Window.IsOpen)
                return;

            m_windowContainer.Window.DispatchEvents();
            m_windowContainer.Window.Clear();

            foreach (var entity in m_container.Entities)
            {
                entity.GetComponent<IDisplayComponent>()?.Draw(m_windowContainer.Window);
            }

            m_windowContainer.Window.Display();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            KillMe();
        }
    }
}
