using UnityEngine;

namespace InvestmentTracker
{
    public class Table : MonoBehaviour
    {
        [Header("Table Local Properties")]
        [SerializeField] private Transform _dataHolder;
        [SerializeField] private RectTransform _prefabHelper;
        [SerializeField] private Transform _prefabData1;
        [SerializeField] private Transform _prefabData2;
        [SerializeField] private float _addOffset;
        private float _yCur;
        private Vector2 _pos;
        private Transform _tempObj;
        private RectTransform _tempRectTransform;
        private bool _data1Style = true;

        [ContextMenu("EDITOR/Add")]
        public void AddData()
        {
            _tempObj = Instantiate(_data1Style ? _prefabData1 : _prefabData2);
            _tempObj.SetParent(_dataHolder);
            _tempObj.TryGetComponent(out _tempRectTransform);

            _tempRectTransform.offsetMax = _prefabHelper.offsetMax;
            _tempRectTransform.offsetMin = _prefabHelper.offsetMin;
            _tempRectTransform.localScale = _prefabHelper.localScale;
            _tempRectTransform.anchoredPosition = _pos;

            _data1Style = !_data1Style;
            _pos.y = _pos.y + _addOffset;
            _tempObj = null;
            _tempRectTransform = null;
        }
    }
}