namespace SoulBound
{
    public abstract class Integration
    {
        public abstract void Dump(Message message);
        public abstract void Identify(string userId, Traits traits);
        public abstract void Reset();
    }
}