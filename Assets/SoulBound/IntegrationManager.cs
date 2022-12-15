using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http;
using MiniJSON;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

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
            var request = new UnityWebRequest(this._config.dataPlaneUrl, "POST");
            byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(messageBytes);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer " + _writeKey);
            request.SetRequestHeader("Access-Control-Allow-Origin", "*");

            request.SendWebRequest();
            
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
