namespace HB.Core.MomentFactory
{
    public class MomentFactory : IMomentFactory
    {
        public DateTimeOffset Now() => DateTimeOffset.UtcNow;
    }
}
