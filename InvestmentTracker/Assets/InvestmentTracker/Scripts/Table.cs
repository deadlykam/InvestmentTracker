using InvestmentTracker.Core;
using InvestmentTracker.ScriptableObjects.Scripts;
using UnityEngine;

namespace InvestmentTracker
{
    public class Table : MonoBehaviour
    {
        [Header("Table Global Properties")]
        [SerializeField] private Data _data;

        [Header("Table Local Properties")]
        [SerializeField] private Transform _dataHolder;
        [SerializeField] private RectTransform _prefabHelper;
        [SerializeField] private Transform _prefabData1;
        [SerializeField] private Transform _prefabData2;
        [SerializeField] private RectTransform _contentTransform;
        [SerializeField] private float _addOffset;

        private DataElement _dataElement;
        private Vector2 _posTemp;
        private Vector2 _posContent;
        private Transform _tempObj;
        private RectTransform _tempRectTransform;
        private bool _data1Style = true;

        private void Start()
        {
            _data.Subscribe(AddData);
            _posTemp.y = -_addOffset; // Making sure the first temp added is in the 0th position
        }

        private void AddData(Element element)
        {
            _posTemp.y += _addOffset;

            IncreaseContentSize();

            _tempObj = Instantiate(_data1Style ? _prefabData1 : _prefabData2);

            _tempObj.TryGetComponent(out _dataElement);
            _dataElement.SetDataElement(element);

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

        [ContextMenu("EDITOR/Add")]
        public void AddData()
        {
            _posTemp.y += _addOffset;

            IncreaseContentSize();

            _tempObj = Instantiate(_data1Style ? _prefabData1 : _prefabData2);
            _tempObj.SetParent(_dataHolder);
            _tempObj.TryGetComponent(out _tempRectTransform);

            _tempRectTransform.offsetMax = _prefabHelper.offsetMax;
            _tempRectTransform.offsetMin = _prefabHelper.offsetMin;
            _tempRectTransform.localScale = _prefabHelper.localScale;
            _tempRectTransform.anchoredPosition = _posTemp;

            _data1Style = !_data1Style;
            _tempObj = null;
            _tempRectTransform = null;
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