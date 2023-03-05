namespace SpaceObjects
{
    public interface ISpaceObjectBuilder
    {
        ISpaceObjectBuilder BuildPlanetSystem();

        ISpaceObjectBuilder BuildGravityAura();

        ISpaceObjectBuilder BuildDamageAura();
    }
}