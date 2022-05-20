using InvestmentTracker.Core;
using InvestmentTracker.ScriptableObjects.Scripts;
using TMPro;
using UnityEngine;

namespace InvestmentTracker
{
    public class StockPriceManager : MonoBehaviour
    {
        [Header("StockPriceManager Global Price")]
        [SerializeField] private FloatVariable _stockPrice;

        [Header("StockPriceManager Local Price")]
        [SerializeField] private TextMeshProUGUI _stockValue;
        [SerializeField] private string _url;
        [SerializeField] private float _refreshRate;
        [SerializeField] private float _flashTime;
        [SerializeField] private Color _colNormal;
        [SerializeField] private Color _colFlash;

        private JsonManager _jsonManager;
        private bool _isProcess;
        private float _timeCur;
        private float _timeCurFlash;

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
        }

        private void DataListener(JsonElement json)
        {
            if (_stockPrice.GetValue() != json.amount)
            {
                _stockPrice.SetValue(json.amount);
                _stockValue.text = $"{json.amount.ToString()} {json.currency}";
                _stockValue.color = _colFlash;
                _timeCur = _refreshRate;
                _timeCurFlash = _flashTime;
            }

            _isProcess = false;
        }
    }
}