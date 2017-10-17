using SFML.Graphics;
using SuspiciousMinds.Base;
using SuspiciousMinds.Base.Interfaces;
using SuspiciousMinds.Base.Player;

namespace SuspiciousMinds.Factories
{
    public static class PlayerFactory
    {
        public static Entity Create()
        {
            var entity = new Entity();

            var physics = new PhysicsComponent();
            var input = new PlayerInput();

            var display = new PixelGridDisplay(
                new PixelGrid(Color.Green),
                physics);

            input.SetPhysics(physics);

            entity.Components.Add(typeof(PhysicsComponent), physics);
            entity.Components.Add(typeof(IInputComponent), input);
            entity.Components.Add(typeof(IDisplayComponent), display);

            return entity;
        }
    }
}
