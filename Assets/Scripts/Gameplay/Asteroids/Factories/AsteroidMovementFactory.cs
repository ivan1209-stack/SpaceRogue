using Gameplay.Asteroids.Movement;
using Zenject;

namespace Gameplay.Asteroids.Factories
{
    public class AsteroidMovementFactory : PlaceholderFactory<float, AsteroidView, AsteroidRandomDirectedMovement>
    {
        public override AsteroidRandomDirectedMovement Create(float startingSpeed, AsteroidView view)
        {
            var movement = new AsteroidRandomDirectedMovement(startingSpeed, view);
            movement.StartMovement();
            return movement;
        }
    }
}
