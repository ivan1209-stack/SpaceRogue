using Abstracts;

public class AsteroidController : BaseController
{
    private AsteroidView _view;
    private AsteroidModel _model;

    public AsteroidController(AsteroidView view, AsteroidConfig config)
    {
        _view = view;
        _model = new(config);

        _view.DamageDealt += _model.DealDamage;
        _view.ObjectDestroyed += _model.DestroyAsteroid;
    }
}
