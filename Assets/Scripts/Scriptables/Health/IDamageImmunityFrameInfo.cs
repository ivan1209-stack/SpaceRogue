namespace Scriptables.Health
{
    public interface IDamageImmunityFrameInfo
    {
        public float SecondHitDelay { get; }
        public float Duration { get; }
        public float Cooldown { get; }
    }
}