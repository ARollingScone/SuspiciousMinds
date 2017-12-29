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

            var hitscanGun = new PlayerHitscanGun(physics);

            input.SetPhysics(physics);
            input.SetGun(hitscanGun);

            entity.AddComponent<IStepComponent>(hitscanGun);
            entity.AddComponent<IStepComponent>(physics);
            entity.AddComponent<IInputComponent>(input);
            entity.AddComponent<IDisplayComponent>(display);

            return entity;
        }
    }
}
