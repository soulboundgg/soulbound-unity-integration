using System.Collections.Generic;
using MiniJSON;

namespace SoulBound
{
    public class Message
    {
        public string eventName;
        public Dictionary<string, object> eventProperties;
        public Dictionary<string, object> userProperties;
        public Dictionary<string, object> options;

        public string getEventPropertiesJson()
        {
            return convertToJson(eventProperties);
        }

        public string getUserPropertiesJson()
        {
            return convertToJson(userProperties);
        }

        public string getOptionsJson()
        {
            return convertToJson(options);
        }

        public string convertToJson(Dictionary<string, object> dict)
        {
            if (dict == null) return "{}";

            return Json.Serialize(dict);
        }
        public string convertMessageToJson()
        {
            Dictionary<string, object> messageDict = new Dictionary<string, object>();
            messageDict.Add("UserProperties", getUserPropertiesJson());
            messageDict.Add("EventProperties", getEventPropertiesJson());
            messageDict.Add("Options", getOptionsJson());
            return Json.Serialize(messageDict);
        }
    }
}