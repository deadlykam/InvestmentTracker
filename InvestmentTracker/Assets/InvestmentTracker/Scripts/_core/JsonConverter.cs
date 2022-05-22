using UnityEngine;

namespace InvestmentTracker.Core
{
    public class JsonConverter
    {
        //{"data":{"base":"BTC","currency":"USD","amount":"30159.85"}}
        public static void DeserializeJson(ref JsonElement element, string raw)
        {
            if (raw.Length == 60)
            {
                element.stockBase = raw.Substring(17, 3);
                element.currency = raw.Substring(34, 3);
                element.amount = float.Parse(raw.Substring(49, 8));
            }
        }
    }
}