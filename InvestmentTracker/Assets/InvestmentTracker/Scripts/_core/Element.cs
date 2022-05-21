using System;

namespace InvestmentTracker.Core
{
    [Serializable]
    public class Element
    {
        public int id;
        public string date;
        public float invested;
        public float priceBought;
        public float btc;
        public float gainAmount;
        public float gainTotal;
        public float gain;
        public float sellPrice;
        public float btcSellPrice;
        public string platform;

        public Element(int id, string date, float invested, float priceBought, float btc, string platform, float stockPrice, float targetXTime)
        {
            this.id = id;
            this.date = date;
            this.invested = invested;
            this.priceBought = priceBought;
            this.btc = btc;
            this.platform = platform;
            sellPrice = targetXTime * this.invested;
            btcSellPrice = targetXTime * this.priceBought;
            UpdateValues(stockPrice, targetXTime);
        }

        public void UpdateValues(float stockPrice, float targetXTime)
        {
            gain = ((stockPrice - priceBought) / priceBought) * 100;
            gainAmount = (gain / 100) * invested;
            gainTotal = ((gain / 100) + 1) * invested;
            /*_sellPrice = targetXTime * _invested;
            _btcSellPrice = targetXTime * _priceBought;*/
        }

        public int GetID() => id;
        public void SetID(int value) => id = value;
        public string GetDate() => date;
        public void SetDate(string value) => date = value;
        public float GetInvested() => invested;
        public void SetInvested(float value) => invested = value;
        public float GetPriceBought() => priceBought;
        public void SetPriceBought(float value) => priceBought = value;
        public float GetBTC() => btc;
        public void SetBTC(float value) => btc = value;
        public float GetGainAmount() => gainAmount;
        public void SetGainAmount(float value) => gainAmount = value;
        public float GetGainTotal() => gainTotal;
        public void SetGainTotal(float value) => gainTotal = value;
        public float GetGain() => gain;
        public void SetGain(float value) => gain = value;
        public float GetSellPrice() => sellPrice;
        public void SetSellPrice(float value) => sellPrice = value;
        public float GetBTCSellPrice() => btcSellPrice;
        public void SetBTCSellPrice(float value) => btcSellPrice = value;
        public string GetPlatform() => platform;
        public void SetPlatform(string value) => platform = value;
    }
}