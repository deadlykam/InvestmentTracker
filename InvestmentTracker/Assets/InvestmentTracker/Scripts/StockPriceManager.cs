using InvestmentTracker.Core;
using InvestmentTracker.ScriptableObjects.Scripts;
using TMPro;
using UnityEngine;

namespace InvestmentTracker
{
    public class StockPriceManager : MonoBehaviour
    {
        [Header("StockPriceManager Global Price")]
        [SerializeField] private Data _data;
        [SerializeField] private FloatVariable _stockPrice;
        [SerializeField] private FloatFixedVariable _targetXTime;
        [SerializeField] private ActionNoneObserver _observers;

        [Header("StockPriceManager Local Price")]
        [SerializeField] private TextMeshProUGUI _stockValue;
        [SerializeField] private TMP_InputField _customStockValueInput;
        [SerializeField] private string _url;
        [SerializeField] private float _refreshRate;
        [SerializeField] private float _flashTime;
        [SerializeField] private Color _colNormal;
        [SerializeField] private Color _colFlash;

        private JsonManager _jsonManager;
        private bool _isProcess;
        private bool _isUpdateValues;
        private float _timeCur;
        private float _timeCurFlash;
        private int _pointer;
        private float _curStockValue;
        private float _customStockValue;
        private bool _isCustomStock;

        private void Awake()
        {
            _stockPrice.SetValue(0.00f); // REMOVE THIS TEST VALUE AND REPLACE FROM ONLINE
            _stockValue.text = _stockPrice.GetValue().ToString();
            _jsonManager = new JsonManager(_url);
            _jsonManager.Subscribe(DataListener);
            _jsonManager.Trigger();
            _timeCur = _refreshRate;
        }

        private void Update()
        {
            if (_timeCur <= 0)
            {
                if (!_isProcess)
                {
                    _jsonManager.Trigger();
                    _isProcess = true;
                }
            }
            else _timeCur -= Time.deltaTime;

            if(_timeCurFlash != 0f)
            {
                _timeCurFlash -= Time.deltaTime;

                if(_timeCurFlash <= 0f)
                {
                    _stockValue.color = _colNormal;
                    _timeCurFlash = 0f;
                }
            }

            if (_isUpdateValues) 
            {
                _data.GetData()[_pointer].UpdateValues(_stockPrice.GetValue(), _targetXTime.GetValue());
                _pointer++;

                if(_pointer >= _data.Size())
                {
                    _observers.Trigger();
                    _isUpdateValues = false;
                }
            }
        }

        public void SetCustomStockValue()
        {
            _customStockValue = float.Parse(_customStockValueInput.text);

            if (_customStockValue != 0f)
            {
                if (!_isCustomStock) _isCustomStock = true;
                SetStockPrice();
                _isUpdateValues = true;
                _pointer = 0;
            }
            else
            {
                _isCustomStock = false;
                SetStockPrice();
                _isUpdateValues = true;
                _pointer = 0;
            }
        }

        private void DataListener(JsonElement json)
        {
            if (_curStockValue != json.amount)
            {
                _curStockValue = json.amount;
                SetStockPrice();
                _stockValue.text = $"{json.amount.ToString()} {json.currency}";
                _stockValue.color = _colFlash;
                _timeCur = _refreshRate;
                _timeCurFlash = _flashTime;
                if (_data.Size() != 0 && !_isCustomStock) _isUpdateValues = true;
                _pointer = 0;
            }

            _isProcess = false;
        }

        private void SetStockPrice()
        {
            if (!_isCustomStock) _stockPrice.SetValue(_curStockValue);
            else _stockPrice.SetValue(_customStockValue);
        }
    }
}