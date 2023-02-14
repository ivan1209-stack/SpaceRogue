using Abstracts;
using Gameplay;
using Gameplay.GameState;
using UI.Game;
using UnityEngine;

public sealed class MainController : BaseController
{
    private readonly CurrentState _currentState;

    private readonly GameDataController _gameDataController;

    private GameController _gameController;
    

    public MainController(CurrentState currentState, Transform uiPosition)
    {
        _currentState = currentState;

        _gameDataController = new();
        AddController(_gameDataController);
        
        _currentState.CurrentGameState.Subscribe(OnGameStateChange);
        OnGameStateChange(_currentState.CurrentGameState.Value);
    }

    protected override void OnDispose()
    {
        DisposeAllControllers();
        
        _currentState.CurrentGameState.Unsubscribe(OnGameStateChange);
    }

    private void OnGameStateChange(GameState newState)
    {
        DisposeAllControllers();
        
        switch (newState)
        {
            case GameState.Game:
                _gameController = new GameController(_currentState, new MainCanvas(), _gameDataController); /*TODO remove when new code is ready*/
                break;
            case GameState.None:
            default: break;
        }
    }

    private void DisposeAllControllers()
    {
        _gameController?.Dispose();
    }
    
}