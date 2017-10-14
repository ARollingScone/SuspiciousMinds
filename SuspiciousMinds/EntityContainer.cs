using SFML.Graphics;
using SuspiciousMinds.Base;
using SuspiciousMinds.Base.Interfaces;
using SuspiciousMinds.Base.Player;
using System.Collections.Generic;

namespace SuspiciousMinds
{
    public class EntityContainer
    {
        public List<Entity> Entities = new List<Entity>();

        public EntityContainer()
        {
            Entities.Add(CreatePlayer());
        }

        private Entity CreatePlayer()
        {
            var entity = new Entity();

            var physics = new PhysicsComponent();
            var input = new InputComponent();

            var display = new PixelGridDisplay(
                new PixelGrid(Color.Green), 
                physics);

            input.SetPhysics(physics);

            entity.Components.Add(typeof(PhysicsComponent), physics);
            entity.Components.Add(typeof(InputComponent), input);
            entity.Components.Add(typeof(IDisplayComponent), display);

            return entity;
        }
    }
}
