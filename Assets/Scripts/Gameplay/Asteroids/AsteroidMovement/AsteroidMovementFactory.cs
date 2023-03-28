using Asteroids;
using Zenject;

public class AsteroidMovementFactory : PlaceholderFactory<AsteroidMoveConfig, AsteroidView, AsteroidRandomDirectedMovement>
{
    public override AsteroidRandomDirectedMovement Create(AsteroidMoveConfig config, AsteroidView view)
    {
        var movement = new AsteroidRandomDirectedMovement(view, config);
        movement.StartMovement();
        return movement;
    }
}
