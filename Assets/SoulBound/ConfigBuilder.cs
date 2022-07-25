using System.Collections.Generic;

namespace SoulBound
{
    public class ConfigBuilder
    {
        private string dataPlaneUrl = Constants.DATA_PLANE_URL;
        public ConfigBuilder WithDataPlaneUrl(string dataPlaneUrl)
        {
            this.dataPlaneUrl = dataPlaneUrl;
            return this;
        }



        private int flushQueueSize = Constants.FLUSH_QUEUE_SIZE;
        public ConfigBuilder WithFlushQueueSize(int flushQueueSize)
        {
            this.flushQueueSize = flushQueueSize;
            return this;
        }

        private int dbCountThreshold = Constants.DB_COUNT_THRESHOLD;
        public ConfigBuilder WithDBCountThreshold(int dbCountThreshold)
        {
            this.dbCountThreshold = dbCountThreshold;
            return this;
        }

        private int sleepTimeOut = Constants.SLEEP_TIME_OUT;
        public ConfigBuilder WithSleepTimeout(int sleepTimeOut)
        {
            this.sleepTimeOut = sleepTimeOut;
            return this;
        }

        private int logLevel = LogLevel.VERBOSE;
        public ConfigBuilder WithLogLevel(int logLevel)
        {
            this.logLevel = logLevel;
            return this;
        }

        private int configRefreshInterval = Constants.CONFIG_REFRESH_INTERVAL;
        public ConfigBuilder WithConfigRefreshInterval(int configRefreshInterval)
        {
            this.configRefreshInterval = configRefreshInterval;
            return this;
        }

        private bool autoCollectAdvertId = Constants.AUTO_COLLECT_ADVERTID;
        public ConfigBuilder withAutoCollectAdvertId(bool autoCollectAdvertId)
        {
            this.autoCollectAdvertId = autoCollectAdvertId;
            return this;
        }
        private bool trackLifecycleEvents = Constants.TRACK_LIFECYCLE_EVENTS;
        public ConfigBuilder WithTrackLifecycleEvents(bool trackLifecycleEvents)
        {
            this.trackLifecycleEvents = trackLifecycleEvents;
            return this;
        }

        private bool recordScreenViews = Constants.RECORD_SCREEN_VIEWS;
        public ConfigBuilder WithRecordScreenViews(bool recordScreenViews)
        {
            this.recordScreenViews = recordScreenViews;
            return this;
        }

        private string controlPlaneUrl = Constants.CONTROL_PLANE_URL;
        public ConfigBuilder WithControlPlaneUrl(string controlPlaneUrl) {
            this.controlPlaneUrl = controlPlaneUrl;
            return this;
        }

        public Config Build()
        {
            return new Config(
                this.dataPlaneUrl,
                this.controlPlaneUrl,
                this.flushQueueSize,
                this.dbCountThreshold,
                this.sleepTimeOut,
                this.logLevel,
                this.configRefreshInterval,
                this.autoCollectAdvertId,
                this.trackLifecycleEvents,
                this.recordScreenViews
               
            );
        }
    }
}
