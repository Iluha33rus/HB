namespace HB.Core.GuidFactory
{
    public class GuidFactory : IGuidFactory
    {
        public Guid Create() => Guid.NewGuid();
    }
}
