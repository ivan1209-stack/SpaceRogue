namespace Gameplay.Services
{
    public class CurrentGameState
    {
        private int _currentLevel;

        public CurrentGameState()
        {
            _currentLevel = 1;
        }

        private void StartNextLevel()
        {
            _currentLevel += 1;
        }
    }
}