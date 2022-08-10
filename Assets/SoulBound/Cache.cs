using UnityEngine;

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
#if !UNITY_EDITOR
                cachedAnonymousId = PlayerPrefs.GetString("rl_anon_id", null);
#endif
            }
            if (cachedAnonymousId == null)
            {
                cachedAnonymousId = SystemInfo.deviceUniqueIdentifier;
            }
            if (cachedAnonymousId == null)
            {
#if !UNITY_EDITOR
                cachedUserId = PlayerPrefs.GetString("rl_user_id", null);
#endif
            }
        }

        public static void SetUserId(string userId)
        {
            cachedUserId = userId;
#if !UNITY_EDITOR
                PlayerPrefs.SetString("rl_user_id", userId);
#endif
        }
        public static void SetAnonymousId(string anonId)
        {
            cachedUserId = anonId;
#if !UNITY_EDITOR
                PlayerPrefs.SetString("rl_anon_id", anonId);
#endif
        }


        public static void Reset()
        {
            cachedUserId = null;
#if !UNITY_EDITOR
                PlayerPrefs.SetString("rl_user_id", null);
#endif
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