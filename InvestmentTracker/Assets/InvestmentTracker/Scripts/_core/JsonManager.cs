using System;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

namespace InvestmentTracker.Core
{
    public class JsonManager
    {
        private JsonElement _json;
        private HttpClient _client;
        private string _response;
        private string _url;
        private Action<JsonElement> _observers;

        public JsonManager(string url)
        {
            _client = new HttpClient();
            _json = new JsonElement();
            _url = url;
        }


        public void Trigger() => GetDataFromClient();
        public void Subscribe(Action<JsonElement> _observer) => _observers += _observer;
        public void Unsubscribe(Action<JsonElement> _observer) => _observers -= _observer;

        private async Task GetDataFromClient()
        {
            try
            {
                _client.DefaultRequestHeaders.IfModifiedSince = new DateTimeOffset(DateTime.Now);
                _response = await _client.GetStringAsync(_url);
                JsonConverter.DeserializeJson(ref _json, _response);
                _observers(_json);
            }
            catch (Exception e) { Debug.Log(e.ToString()); }
        }
    }
}