﻿using MyWebServer.Common;

namespace MyWebServer.Http
{
    public class HttpSession
    {
        public const string SessionCookieName = "MyWebServerSID";

        private Dictionary<string, string> data;

        public HttpSession(string id)
        {
            Guard.AgainstNull(id, nameof(id));

            this.Id = id;

            this.data = new Dictionary<string, string>();
        }

        public string Id { get; init; }

        public bool IsNew { get; set; }

        public int Count => this.data.Count;

        public string this[string key]
        {
            get => this.data[key];
            set => this.data[key] = value;
        }

        public bool ContainsKey(string key) => this.data.ContainsKey(key);

        public void Remove(string key)
        {
            if (this.data.ContainsKey(key))
            {
                this.data.Remove(key);
            }
        }
    }
}