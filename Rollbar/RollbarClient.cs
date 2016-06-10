﻿using System;
using System.Net;
using Newtonsoft.Json;

namespace RollbarDotNet
{
    /// <summary>
    /// Client for accessing the Rollbar API
    /// </summary>
    public class RollbarClient : IRollbarClient
    {
        public RollbarConfig Config { get; }

        public RollbarClient(RollbarConfig config)
        {
            Config = config;
        }

        public void PostItem(Payload payload)
        {
            SendPost("item/", payload);
        }

        private void SendPost<T>(string url, T payload)
        {
            var webClient = new WebClient();
            webClient.UploadStringAsync(new Uri($"{Config.EndPoint}{url}"), JsonConvert.SerializeObject(payload));
        }
    }

    public interface IRollbarClient
    {
        void PostItem(Payload payload);
    }
}
