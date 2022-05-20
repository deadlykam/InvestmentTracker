using System;

namespace InvestmentTracker.Core
{
    [Serializable]
    public class Element
    {
        private int _id;
        private string _date;
        private float _invested;
        private float _priceBought;
        private float _btc;
        private float _gainAmount;
        private float _gainTotal;
        private float _gain;
        private float _sellPrice;
        private float _btcSellPrice;
        private string _platform;

        public Element(int id, string date, float invested, float priceBought, float btc, string platform, float stockPrice, float targetXTime)
        {
            _id = id;
            _date = date;
            _invested = invested;
            _priceBought = priceBought;
            _btc = btc;
            _platform = platform;
            UpdateValues(stockPrice, targetXTime);
        }

        public void UpdateValues(float stockPrice, float targetXTime)
        {
            _gain = ((stockPrice - _priceBought) / _priceBought) * 100;
            _gainAmount = (_gain / 100) * _invested;
            _gainTotal = ((_gain / 100) + 1) * _invested;
            /*_sellPrice = targetXTime * _invested;
            _btcSellPrice = targetXTime * _priceBought;*/
        }

        public int GetID() => _id;
        public void SetID(int value) => _id = value;
        public string GetDate() => _date;
        public void SetDate(string value) => _date = value;
        public float GetInvested() => _invested;
        public void SetInvested(float value) => _invested = value;
        public float GetPriceBought() => _priceBought;
        public void SetPriceBought(float value) => _priceBought = value;
        public float GetBTC() => _btc;
        public void SetBTC(float value) => _btc = value;
        public float GetGainAmount() => _gainAmount;
        public void SetGainAmount(float value) => _gainAmount = value;
        public float GetGainTotal() => _gainTotal;
        public void SetGainTotal(float value) => _gainTotal = value;
        public float GetGain() => _gain;
        public void SetGain(float value) => _gain = value;
        public float GetSellPrice() => _sellPrice;
        public void SetSellPrice(float value) => _sellPrice = value;
        public float GetBTCSellPrice() => _btcSellPrice;
        public void SetBTCSellPrice(float value) => _btcSellPrice = value;
        public string GetPlatform() => _platform;
        public void SetPlatform(string value) => _platform = value;
    }
}