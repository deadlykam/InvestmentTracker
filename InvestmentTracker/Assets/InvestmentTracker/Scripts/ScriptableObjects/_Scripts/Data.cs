using InvestmentTracker.Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace InvestmentTracker.ScriptableObjects.Scripts
{
    [CreateAssetMenu(fileName = "Data",
                     menuName = "InvestmentTracker/ScriptableObjects/Data",
                     order = 1)]
    public class Data : BaseScriptableObject
    {
        [Header("Data Global Properties")]
        [SerializeField] private UniqueIDGenerator _uig;
        [SerializeField] private FloatVariable _stockPrice;
        [SerializeField] private FloatVariable _rOIx;
        [SerializeField] private ActionNoneObserver _observersSave;
        [SerializeField] private ActionNone _removeAllTableData;
        [SerializeField] private ActionNone _triggerTableManagerUpdate;
        [SerializeField] private ActionNone _triggerStockPriceManagerUpdate;

        private List<Element> _data;
        private List<Element> _dataSold;
        private Element[] _tempData;
        private Element[] _dataSort;
        private Element _element;
        private Action<Element> _observers;
        private int _index;
        private string _fileNameTable = "DefaultSave.json";
        private string _fileNameSold = "DefaultSoldSave.json";
        private string _fileNameROIx = "DefaultROIx.json";
        private bool _isAscend = true;

        private void Awake()
        {
            SaveLoad.Initialize();
            _data = new List<Element>();
            _dataSold = new List<Element>();
            _observers = null;
        }

        public void AddData(string date, float invested, float priceBought, float _btc, string platform)
        {
            _element = new Element(_uig.GetID(), date, invested, priceBought, _btc, platform, _stockPrice.GetValue(), _rOIx.GetValue());
            _data.Add(_element);
            Trigger(_element);
            _element = null;
        }

        public void SoldData(int id)
        {
            _dataSold.Add(_data[id]);
            RemoveData(id);
        }

        public void RemoveData(int id)
        {
            _data.RemoveAt(id);
            _tempData = _data.ToArray();
            _data.Clear();
            _uig.Reset();
            for (_index = 0; _index < _tempData.Length; _index++) AddData(_tempData[_index].date, _tempData[_index].invested, _tempData[_index].priceBought, _tempData[_index].btc, _tempData[_index].platform);
        }

        public Element[] GetData() => _data.ToArray();
        public Element[] GetDataSold() => _dataSold.ToArray();
        public Element[] GetDataSort() => _dataSort;

        public void SaveData()
        {
            SaveLoad.SaveData(GetData(), _fileNameTable);
            SaveLoad.SaveData(_dataSold.ToArray(), _fileNameSold);
            SaveLoad.SaveData(_rOIx.GetValue(), _fileNameROIx);
            _observersSave.Trigger();
        }

        public void LoadData()
        {
            Reset(); // Resetting id and data
            _removeAllTableData.CallDelegate(); // Removing all table data
            _rOIx.SetValue(SaveLoad.LoadDataFloat(_fileNameROIx)); // Loading ROIx value
            _tempData = SaveLoad.LoadData(_fileNameTable);
            for (_index = 0; _index < _tempData.Length; _index++) AddData(_tempData[_index].date, _tempData[_index].invested, _tempData[_index].priceBought, _tempData[_index].btc, _tempData[_index].platform);
            _tempData = SaveLoad.LoadData(_fileNameSold);
            
            for (_index = 0; _index < _tempData.Length; _index++)
            {
                _element = new Element(-1, _tempData[_index].date, _tempData[_index].invested, _tempData[_index].priceBought, _tempData[_index].btc, _tempData[_index].platform, _stockPrice.GetValue(), _rOIx.GetValue());
                _dataSold.Add(_element);
            }
            _element = null;
            _triggerTableManagerUpdate.CallDelegate();
            _triggerStockPriceManagerUpdate.CallDelegate();
            _observersSave.Trigger();
        }

        public int Size() => _data.Count;
        public int SizeSold() => _dataSold.Count;
        public int SizeSort() => _dataSort.Length;
        public void Subscribe(Action<Element> observer) => _observers += observer;
        public void Unsubscribe(Action<Element> observer) => _observers -= observer;
        public void Trigger(Element element) => _observers(element);
        public bool IsSaveFileExist() => SaveLoad.IsFileExist(_fileNameTable);
        
        public void SortID()
        {
            _dataSort = SortHelper.SortID(_data.ToArray(), _isAscend);
            _isAscend = !_isAscend;
        }

        public void SortInvested()
        {
            _dataSort = SortHelper.SortInvested(_data.ToArray(), _isAscend);
            _isAscend = !_isAscend;
        }

        public void SortPrice()
        {
            _dataSort = SortHelper.SortPrice(_data.ToArray(), _isAscend);
            _isAscend = !_isAscend;
        }

        public void SortBTC()
        {
            _dataSort = SortHelper.SortBTC(_data.ToArray(), _isAscend);
            _isAscend = !_isAscend;
        }

        public void SortSellPrice()
        {
            _dataSort = SortHelper.SortSellPrice(_data.ToArray(), _isAscend);
            _isAscend = !_isAscend;
        }

        public void SortBTCSellPrice()
        {
            _dataSort = SortHelper.SortBTCSellPrice(_data.ToArray(), _isAscend);
            _isAscend = !_isAscend;
        }

        public void SortPlatform()
        {
            _dataSort = SortHelper.SortPlatform(_data.ToArray(), _isAscend);
            _isAscend = !_isAscend;
        }

        public void SortGain()
        {
            _dataSort = SortHelper.SortGain(_data.ToArray(), _isAscend);
            _isAscend = !_isAscend;
        }

        public void SortGainAmount()
        {
            _dataSort = SortHelper.SortGainAmount(_data.ToArray(), _isAscend);
            _isAscend = !_isAscend;
        }

        public void SortGainTotal()
        {
            _dataSort = SortHelper.SortGainTotal(_data.ToArray(), _isAscend);
            _isAscend = !_isAscend;
        }

        public void Reset()
        {
            _data.Clear();
            _dataSold.Clear();
            _uig.Reset();
        }
    }
}