namespace Gameplay.Survival.Health
{
    public interface IHealthInfo
    {
        float MaximumHealth { get; }
        float StartingHealth { get; }
        float HealthRegen { get; }
    }
}