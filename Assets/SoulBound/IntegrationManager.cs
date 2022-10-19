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
        private string _writeKey = null;
        private Config _config = null;
        private object _lockingObj = new object();
        

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
            while (!isDone && retryCount <= 3)
            {
                try
                {
                    Logger.LogDebug("configEndpontUrl: " + this._config.dataPlaneUrl);
                    var postrequest = (HttpWebRequest)WebRequest.Create(new Uri(this._config.dataPlaneUrl));
                    var authKeyBytes = System.Text.Encoding.UTF8.GetBytes(_writeKey + ":");
                    var messageBytes = System.Text.Encoding.UTF8.GetBytes(message);
                    string authHeader = Convert.ToBase64String(authKeyBytes);
                    postrequest.Headers.Add("Authorization", "Bearer " + _writeKey);

                    postrequest.Method = "POST";
                    postrequest.ContentType="application/json";
                    postrequest.ContentLength = messageBytes.Length;
                    
                    using (var stream = postrequest.GetRequestStream())
                    {
                        stream.Write(messageBytes, 0, messageBytes.Length);
                    }

                    HttpWebResponse response = (HttpWebResponse)postrequest.GetResponse();
                    var responseJson = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    Logger.LogDebug("Config Server Response: " + responseJson);
                    if (responseJson != null)
                    {
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
                    Logger.LogError(ex.Message);
                    retryCount += 1;
                    Thread.Sleep(1000 * retryCount * retryTimeOut);
                }
            }
        }
        public void MakeIntegrationDump(Message message)
        {
            Logger.LogDebug("Sending message " + message.eventName);
            
            var t = new Thread(() => SendPostData(message.convertMessageToJson()));
            t.Start();
            
        }

        public void MakeIntegrationIdentify(Traits traits)
        {

            Logger.LogDebug("Identify " + traits.getId());
            string traitsJson = Json.Serialize(traits.traitsDict);
            var t = new Thread(() => SendPostData(traitsJson));
            t.Start();

            
        }
    }
}
