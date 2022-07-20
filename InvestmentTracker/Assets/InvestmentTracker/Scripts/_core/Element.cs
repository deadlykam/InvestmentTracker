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

        public Element(int id, string date, float invested, float priceBought, float btc, string platform, float stockPrice, float roix)
        {
            this.id = id;
            this.date = date;
            this.invested = invested;
            this.priceBought = priceBought;
            this.btc = btc;
            this.platform = platform;
            UpdateValues(stockPrice, roix);
        }

        public void UpdateValues(float stockPrice, float roix)
        {
            sellPrice = roix * invested;
            btcSellPrice = roix * priceBought;
            gain = ((stockPrice - priceBought) / priceBought) * 100;
            gainAmount = (gain / 100) * invested;
            gainTotal = ((gain / 100) + 1) * invested;
        }
    }
}