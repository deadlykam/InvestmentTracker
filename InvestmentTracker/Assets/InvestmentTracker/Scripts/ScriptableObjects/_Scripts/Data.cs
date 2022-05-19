using InvestmentTracker.Core;
using System;
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

        [Header("Data Local Properties")]
        [SerializeField] private int _startLimit = 1;
        [SerializeField, Tooltip("The amount of times the data will increase when limit reached.")] private int _dataSizeIncrease = 2;

        private Element[] _data;
        private Element[] _tempData;
        private Element _element;
        private Action<Element> _observers;
        private int _pointer = 0;
        private int _index;

        private void Awake()
        {
            _data = new Element[_startLimit];
            _observers = null;
        }

        public void AddData(string date, float invested, float priceBought, float _btc, string platform)
        {
            _element = new Element(_uig.GetID(), date, invested, priceBought, _btc, platform);
            _data[_pointer++] = _element;
            Trigger(_element);
            _element = null;

            if (_pointer >= _data.Length) // Condition for increasing data size
            {
                _tempData = _data;
                _data = new Element[_data.Length * _dataSizeIncrease];
                for(_index = 0; _index < _tempData.Length; _index++) { _data[_index] = _tempData[_index]; }
                _tempData = null;
            }
        }

        public void Subscribe(Action<Element> observer) => _observers += observer;
        public void Unsubscribe(Action<Element> observer) => _observers -= observer;
        public void Trigger(Element element) => _observers(element);
    }
}