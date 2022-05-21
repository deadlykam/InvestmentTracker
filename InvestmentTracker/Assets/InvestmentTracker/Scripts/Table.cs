using InvestmentTracker.Core;
using InvestmentTracker.ScriptableObjects.Scripts;
using System.Collections.Generic;
using UnityEngine;

namespace InvestmentTracker
{
    public class Table : MonoBehaviour
    {
        [Header("Table Global Properties")]
        [SerializeField] private Data _data;
        [SerializeField] private ActionNoneObserver _listener;

        [Header("Table Local Properties")]
        [SerializeField] private Transform _dataHolder;
        [SerializeField] private RectTransform _prefabHelper;
        [SerializeField] private Transform _prefabData1;
        [SerializeField] private Transform _prefabData2;
        [SerializeField] private RectTransform _contentTransform;
        [SerializeField] private float _addOffset;

        private List<DataElement> _dataElements;
        private DataElement _dataElement;
        private Vector2 _posTemp;
        private Vector2 _posContent;
        private Transform _tempObj;
        private RectTransform _tempRectTransform;
        private bool _data1Style = true;
        private bool _isUpdate;
        private int _pointer;

        private void Start()
        {
            _listener.Subscribe(Listener);
            _dataElements = new List<DataElement>();
            _data.Subscribe(AddData);
            _posTemp.y = -_addOffset; // Making sure the first temp added is in the 0th position
        }

        private void Update()
        {
            if (_isUpdate)
            {
                _dataElements[_pointer].UpdateData();
                _pointer++;
                if (_pointer >= _data.Size()) _isUpdate = false;
            }
        }

        private void Listener() 
        {
            _isUpdate = true;
            _pointer = 0;
        }

        private void AddData(Element element)
        {
            _posTemp.y += _addOffset;

            IncreaseContentSize();

            _tempObj = Instantiate(_data1Style ? _prefabData1 : _prefabData2);

            _tempObj.TryGetComponent(out _dataElement);
            _dataElement.SetDataElement(element);
            _dataElements.Add(_dataElement);

            _tempObj.SetParent(_dataHolder);
            _tempObj.TryGetComponent(out _tempRectTransform);

            _tempRectTransform.offsetMax = _prefabHelper.offsetMax;
            _tempRectTransform.offsetMin = _prefabHelper.offsetMin;
            _tempRectTransform.localScale = _prefabHelper.localScale;
            _tempRectTransform.anchoredPosition = _posTemp;

            _data1Style = !_data1Style;
            _tempObj = null;
            _tempRectTransform = null;
            _dataElement = null;
        }

        /// <summary>
        /// This method increases the size of the content.
        /// </summary>
        private void IncreaseContentSize()
        {
            if (_posTemp.y <= _contentTransform.offsetMin.y) // Condition for increasing the content's height
            {
                _posContent = _contentTransform.offsetMin;
                _posContent.y += _addOffset;
                _contentTransform.offsetMin = _posContent;
            }
        }
    }
}