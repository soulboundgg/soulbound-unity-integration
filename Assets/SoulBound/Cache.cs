namespace SoulBound
{
    public class Cache
    {
        private static string cachedAnonymousId = null;
        private static string cachedUserId = null;

        public static void Init()
        {
            if (cachedAnonymousId == null)
            {
                //TODO cachedAnonymousId = SystemInfo.deviceUniqueIdentifier;
            }
            if (cachedAnonymousId == null)
            {
            }
        }

        public static void SetUserId(string userId)
        {
            cachedUserId = userId;
        }

        public static void Reset()
        {
            cachedUserId = null;
        }

        public static string GetAnonymousId()
        {
            return cachedAnonymousId;
        }

        public static string GetUserId()
        {
            return cachedUserId;
        }
    }
}