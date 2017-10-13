using SuspiciousMinds.Base;
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
            var display = new DisplayComponent();
            var physics = new PhysicsComponent();
            var input = new InputComponent();

            input.SetPhysics(physics);
            display.SetPhysics(physics);

            entity.Components.Add(typeof(PhysicsComponent), physics);
            entity.Components.Add(typeof(InputComponent), input);
            entity.Components.Add(typeof(DisplayComponent), display);

            return entity;
        }
    }
}
