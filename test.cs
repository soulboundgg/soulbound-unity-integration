using UnityEngine;
using System;
using System.Collections.Generic;
using RudderStack.MiniJSON;

namespace RudderStack
{
    public class RudderClient : MonoBehaviour
    {
        private static RudderClient _instance;




        private static RudderIntegrationManager _integrationManager;

        /*
        private constructor to prevent instantiating
         */
        private RudderClient(
            string _writeKey,
            string _dataPlaneUrl,
            string _controlPlaneUrl,
            int _flushQueueSize,
            int _dbCountThreshold,
            int _sleepTimeout,
            int _configRefreshInterval,
            bool _autoCollectAdvertId,
            bool _trackLifecycleEvents,
            bool _recordScreenViews,
            int _logLevel
        )
        {
        }

        public static RudderClient GetInstance(
            string writeKey,
            RudderConfig config
        )
        {
            if (_instance == null)
            {
                // initialize the cache
                RudderCache.Init();

                RudderLogger.LogDebug("Instantiating RudderClient SDK");
                // initialize the instance
                _instance = new RudderClient(
                    writeKey,
                    config.dataPlaneUrl,
                    config.controlPlaneUrl,
                    config.flushQueueSize,
                    config.dbCountThreshold,
                    config.sleepTimeOut,
                    config.configRefreshInterval,
                    config.autoCollectAdvertId,
                    config.trackLifecycleEvents,
                    config.recordScreenViews,
                    config.logLevel
                );


                RudderLogger.LogDebug("Instantiating RudderIntegrationManager");
                _integrationManager = new RudderIntegrationManager(
                    writeKey,
                    config
                );
            }
            else
            {
                RudderLogger.LogDebug("RudderClient SDK is already initiated");
            }

            return _instance;
        }

        public static RudderClient GetInstance(string writeKey)
        {
            return GetInstance(writeKey, new RudderConfig());
        }

        public static RudderClient GetInstance(string writeKey, string dataPlaneUrl)
        {
            RudderConfig config = new RudderConfigBuilder().WithDataPlaneUrl(dataPlaneUrl).Build();
            return GetInstance(writeKey, config);
        }

        public void Track(RudderMessage message)
        {
            RudderLogger.LogDebug("Track Event: " + message.eventName);
            if (_integrationManager != null)
            {
                _integrationManager.MakeIntegrationDump(message);
            }

        }

        public void Screen(RudderMessage message)
        {
            RudderLogger.LogDebug("Screen Event: " + message.eventName);
            if (_integrationManager != null)
            {
                _integrationManager.MakeIntegrationDump(message);
            }
        }

        public void Identify(string userId, RudderTraits traits, RudderMessage message)
        {
            RudderLogger.LogDebug("Identify Event: " + message.eventName);
            RudderCache.SetUserId(userId);
            if (_integrationManager != null)
            {
                _integrationManager.MakeIntegrationIdentify(userId, traits);
            }

            // put supplied userId under traits as well if it is not set
            if (traits.getId() == null)
            {
                traits.PutId(userId);
            }
            string traitsJson = Json.Serialize(traits.traitsDict);
        }

        public void Reset()
        {
            RudderLogger.LogDebug("SDK reset");
            if (_integrationManager != null)
            {
                _integrationManager.Reset();
            }
            RudderCache.Reset();
        }

        public void setAnonymousId(string _anonymousId)
        {
            RudderLogger.LogDebug("SetAnonymousId: " + _anonymousId);
        }

        public static RudderClient GetInstance()
        {
            return _instance;
        }

        public static void SerializeSqlite()
        {
        }
        void Update()
        {
            if (_integrationManager != null)
            {
                _integrationManager.Update();
            }
        }
    }
}