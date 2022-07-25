using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http;
using System.Threading;
using MiniJSON;
using UnityEngine;

namespace SoulBound
{
    class IntegrationManager
    {
        private Dictionary<string, object> _rudderServerConfig = null;
        private string _serverConfigJson = null;
        private string _writeKey = null;
        private Config _config = null;
        private object _lockingObj = new object();
        private string _persistedUserId = null;
        private Traits _persistedTraits = null;

        public IntegrationManager(string writeKey, Config config)
        {
            this._writeKey = writeKey;
            this._config = config;
        }


        public void SendPostData(string message)
        {
            bool isDone = false;
            int retryCount = 0;
            int retryTimeOut = 10;
            Console.WriteLine(message);
            while (!isDone && retryCount <= 3)
            {
                try
                {
                    Logger.LogDebug("configEndpontUrl: " + this._config.dataPlaneUrl);
                    // create http request object
                    var postrequest = (HttpWebRequest)WebRequest.Create(new Uri(this._config.dataPlaneUrl));
                    var authKeyBytes = System.Text.Encoding.UTF8.GetBytes(_writeKey + ":");
                    var messageBytes = System.Text.Encoding.UTF8.GetBytes(message);
                    string authHeader = Convert.ToBase64String(authKeyBytes);
                    postrequest.Headers.Add("Authorization", "Basic " + authHeader);

                    postrequest.Method = "POST";
                    postrequest.ContentType="application/json";
                    postrequest.ContentLength = authKeyBytes.Length;
                    
                    using (var stream = postrequest.GetRequestStream())
                    {
                        stream.Write(messageBytes, 0, messageBytes.Length);
                    }

                    HttpWebResponse response = (HttpWebResponse)postrequest.GetResponse();
                    var responseJson = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    Logger.LogDebug("Config Server Response: " + responseJson);
                    if (responseJson != null)
                    {
                        lock (this._lockingObj)
                        {
                            this._serverConfigJson = responseJson;
                        }
                        isDone = true;
                    }
                    else
                    {
                        retryCount += 1;
                        Thread.Sleep(1000 * retryCount * retryTimeOut);
                    }
                }
                catch (Exception ex)
                {
                    // Logger.LogError(ex.Message);
                    retryCount += 1;
                    Thread.Sleep(1000 * retryCount * retryTimeOut);
                }
            }
        }

        public void MakeIntegrationDump(Message message)
        {
            Logger.LogDebug("Sending message " + message.eventName);
            SendPostData(message.convertMessageToJson());
        }

        public void MakeIntegrationIdentify(Traits traits)
        {

            Logger.LogDebug("Identify " + traits.getId());
            string traitsJson = Json.Serialize(traits.traitsDict);

            SendPostData(traitsJson);


        }



    }
}
