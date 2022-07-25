using System.Collections.Generic;

namespace SoulBound
{
    public class MessageBuilder
    {
        private string eventName;
        public MessageBuilder WithEventName(string eventName)
        {
            this.eventName = eventName;
            return this;
        }
        private Dictionary<string, object> eventProperties;
        public MessageBuilder WithEventProperties(Dictionary<string, object> eventProperties)
        {
            if (eventProperties == null)
            {
                // do not set null value
                return this;
            }
            else
            {
                if (this.eventProperties == null)
                {
                    this.eventProperties = new Dictionary<string, object>();
                }
                foreach (var key in eventProperties.Keys)
                {
                    var value = eventProperties[key];
                    if (value != null)
                    {
                        this.eventProperties.Add(key, value);
                    }
                }
            }
            return this;
        }
        public MessageBuilder WithEventProperty(string key, object value)
        {
            if (this.eventProperties == null)
            {
                this.eventProperties = new Dictionary<string, object>();
            }
            if (value != null)
            {
                this.eventProperties.Add(key, value);
            }
            return this;
        }
        private Dictionary<string, object> userProperties;
        public MessageBuilder WithUserProperties(Dictionary<string, object> userProperties)
        {
            if (userProperties == null)
            {
                // do not set null values
                return this;
            }
            else
            {
                if (this.userProperties == null)
                {
                    this.userProperties = new Dictionary<string, object>();
                }
                foreach (var key in userProperties.Keys)
                {
                    var value = userProperties[key];
                    if (value != null)
                    {
                        this.userProperties.Add(key, value);
                    }
                }
            }
            return this;
        }
        public MessageBuilder WithUserProperty(string key, object value)
        {
            if (this.userProperties == null)
            {
                this.userProperties = new Dictionary<string, object>();
            }
            if (value != null)
            {
                this.userProperties.Add(key, value);
            }
            return this;
        }
        public Message Build()
        {
            Message element = new Message();
            element.eventName = this.eventName;
            element.eventProperties = this.eventProperties;
            element.userProperties = this.userProperties;
            return element;
        }

    }
}