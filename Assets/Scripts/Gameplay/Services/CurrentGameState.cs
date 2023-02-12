using Gameplay.Factories;

namespace Gameplay.Services
{
    public class CurrentGameState
    {
        public int CurrentLevelNumber { get; private set; }
        
        private LevelFactory _levelFactory;
        private Level _currentLevel;

        public CurrentGameState(LevelFactory levelFactory)
        {
            _levelFactory = levelFactory;
            
            CurrentLevelNumber = 1;
            _currentLevel = levelFactory.Create(CurrentLevelNumber);
        }

        private void StartNextLevel()
        {
            _currentLevel.Dispose();
            CurrentLevelNumber += 1;
            _currentLevel = _levelFactory.Create(CurrentLevelNumber);
        }
    }
}