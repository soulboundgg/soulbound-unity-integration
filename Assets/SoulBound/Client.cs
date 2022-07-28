
using UnityEngine;
using System;
using System.Collections.Generic;
using MiniJSON;

namespace SoulBound
{
    public class Client 
    {
        private static Client _instance;
        private static IntegrationManager _integrationManager;
        
        
        private string _writeKey;
        private string _dataPlaneUrl;
        private string _controlPlaneUrl;
        private int _logLevel;


        private Client(
            string _writeKey,
            string _dataPlaneUrl,
            string _configPlaneUrl,
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
            this._writeKey = _writeKey;
            this._dataPlaneUrl = _dataPlaneUrl;
            this._controlPlaneUrl = _configPlaneUrl;
            this._logLevel = _logLevel;
        }

        public static Client GetInstance(
            string writeKey,
            Config config
        )
        {
            if (_instance == null)
            {
                // initialize the cache
                Cache.Init();

                Logger.LogDebug("Instantiating Client SDK");
                // initialize the instance
                _instance = new Client(
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


                Logger.LogDebug("Instantiating IntegrationManager");
                _integrationManager = new IntegrationManager(
                    writeKey,
                    config
                );
            }
            else
            {
                Logger.LogDebug("Client SDK is already initiated");
            }

            return _instance;
        }

        public static Client GetInstance(string writeKey)
        {
            return GetInstance(writeKey, new Config());
        }

        public static Client GetInstance(string writeKey, string dataPlaneUrl)
        {
            Config config = new ConfigBuilder().WithDataPlaneUrl(dataPlaneUrl).Build();
            return GetInstance(writeKey, config);
        }

        public void Track(Message message)
        {
            Logger.LogDebug("Track Event: " + message.eventName);
            if (_integrationManager != null)
            {
                _integrationManager.MakeIntegrationDump(message);
            }

        }

        public void Screen(Message message)
        {
            Logger.LogDebug("Screen Event: " + message.eventName);
            if (_integrationManager != null)
            {
                _integrationManager.MakeIntegrationDump(message);
            }
        }

        public void Identify(string userId, Traits traits)
        {
            Cache.SetUserId(userId);
            if (traits.getId() == null)
            {
                traits.PutId(userId);
            }

            if (_integrationManager != null)
            {
               
                _integrationManager.MakeIntegrationIdentify(traits);
            }

        }


        public void setAnonymousId(string _anonymousId)
        {
            Logger.LogDebug("SetAnonymousId: " + _anonymousId);
        }

    }
}
