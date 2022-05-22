namespace InvestmentTracker.Core
{
    public static class SortHelper
    {
        private static int _sortA, _sortB;
        private static Element _swap;

        public static Element[] SortID(Element[] data, bool isAscend)
        {
            for (_sortA = 0; _sortA < data.Length - 1; _sortA++)
            {
                for (_sortB = SortBStartIndex(); _sortB < data.Length; _sortB++)
                {
                    if (isAscend) { if (data[_sortB].id < data[_sortA].id) Swap(data, _sortA, _sortB); }
                    else { if (data[_sortB].id > data[_sortA].id) Swap(data, _sortA, _sortB); }
                }
            }
            return data;
        }

        public static Element[] SortInvested(Element[] data, bool isAscend)
        {
            for (_sortA = 0; _sortA < data.Length - 1; _sortA++)
            {
                for (_sortB = SortBStartIndex(); _sortB < data.Length; _sortB++)
                {
                    if (isAscend) { if (data[_sortB].invested < data[_sortA].invested) Swap(data, _sortA, _sortB); }
                    else { if (data[_sortB].invested > data[_sortA].invested) Swap(data, _sortA, _sortB); }
                }
            }
            return data;
        }

        public static Element[] SortPrice(Element[] data, bool isAscend)
        {
            for (_sortA = 0; _sortA < data.Length - 1; _sortA++)
            {
                for (_sortB = SortBStartIndex(); _sortB < data.Length; _sortB++)
                {
                    if (isAscend) { if (data[_sortB].priceBought < data[_sortA].priceBought) Swap(data, _sortA, _sortB); }
                    else { if (data[_sortB].priceBought > data[_sortA].priceBought) Swap(data, _sortA, _sortB); }
                }
            }
            return data;
        }

        public static Element[] SortBTC(Element[] data, bool isAscend)
        {
            for (_sortA = 0; _sortA < data.Length - 1; _sortA++)
            {
                for (_sortB = SortBStartIndex(); _sortB < data.Length; _sortB++)
                {
                    if (isAscend) { if (data[_sortB].btc < data[_sortA].btc) Swap(data, _sortA, _sortB); }
                    else { if (data[_sortB].btc > data[_sortA].btc) Swap(data, _sortA, _sortB); }
                }
            }
            return data;
        }

        public static Element[] SortSellPrice(Element[] data, bool isAscend)
        {
            for (_sortA = 0; _sortA < data.Length - 1; _sortA++)
            {
                for (_sortB = SortBStartIndex(); _sortB < data.Length; _sortB++)
                {
                    if (isAscend) { if (data[_sortB].sellPrice < data[_sortA].sellPrice) Swap(data, _sortA, _sortB); }
                    else { if (data[_sortB].sellPrice > data[_sortA].sellPrice) Swap(data, _sortA, _sortB); }
                }
            }
            return data;
        }

        public static Element[] SortBTCSellPrice(Element[] data, bool isAscend)
        {
            for (_sortA = 0; _sortA < data.Length - 1; _sortA++)
            {
                for (_sortB = SortBStartIndex(); _sortB < data.Length; _sortB++)
                {
                    if (isAscend) { if (data[_sortB].btcSellPrice < data[_sortA].btcSellPrice) Swap(data, _sortA, _sortB); }
                    else { if (data[_sortB].btcSellPrice > data[_sortA].btcSellPrice) Swap(data, _sortA, _sortB); }
                }
            }
            return data;
        }

        public static Element[] SortPlatform(Element[] data, bool isAscend)
        {
            for (_sortA = 0; _sortA < data.Length - 1; _sortA++)
            {
                for (_sortB = SortBStartIndex(); _sortB < data.Length; _sortB++)
                {
                    if (isAscend) { if (data[_sortB].platform.CompareTo(data[_sortA].platform) == -1) Swap(data, _sortA, _sortB); }
                    else { if (data[_sortB].platform.CompareTo(data[_sortA].platform) == 1) Swap(data, _sortA, _sortB); }
                }
            }
            return data;
        }

        public static Element[] SortGain(Element[] data, bool isAscend)
        {
            for (_sortA = 0; _sortA < data.Length - 1; _sortA++)
            {
                for (_sortB = SortBStartIndex(); _sortB < data.Length; _sortB++)
                {
                    if (isAscend) { if (data[_sortB].gain < data[_sortA].gain) Swap(data, _sortA, _sortB); }
                    else { if (data[_sortB].gain > data[_sortA].gain) Swap(data, _sortA, _sortB); }
                }
            }
            return data;
        }

        public static Element[] SortGainAmount(Element[] data, bool isAscend)
        {
            for (_sortA = 0; _sortA < data.Length - 1; _sortA++)
            {
                for (_sortB = SortBStartIndex(); _sortB < data.Length; _sortB++)
                {
                    if (isAscend) { if (data[_sortB].gainAmount < data[_sortA].gainAmount) Swap(data, _sortA, _sortB); }
                    else { if (data[_sortB].gainAmount > data[_sortA].gainAmount) Swap(data, _sortA, _sortB); }
                }
            }
            return data;
        }

        public static Element[] SortGainTotal(Element[] data, bool isAscend)
        {
            for (_sortA = 0; _sortA < data.Length - 1; _sortA++)
            {
                for (_sortB = SortBStartIndex(); _sortB < data.Length; _sortB++)
                {
                    if (isAscend) { if (data[_sortB].gainTotal < data[_sortA].gainTotal) Swap(data, _sortA, _sortB); }
                    else { if (data[_sortB].gainTotal > data[_sortA].gainTotal) Swap(data, _sortA, _sortB); }
                }
            }
            return data;
        }

        private static void Swap(Element[] data, int indexA, int indexB)
        {
            _swap = data[indexA];
            data[indexA] = data[indexB];
            data[indexB] = _swap;
            _swap = null;
        }

        private static int SortBStartIndex() => _sortA + 1;
    }
}