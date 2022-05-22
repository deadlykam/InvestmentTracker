using InvestmentTracker.Core;
using InvestmentTracker.ScriptableObjects.Scripts;
using TMPro;
using UnityEngine;

namespace InvestmentTracker
{
    public class TableManager : MonoBehaviour
    {
        [Header("TableManager Global Properties")]
        [SerializeField] private Data _data;
        [SerializeField] private ActionNoneObserver _listener;
        [SerializeField] private ActionNoneObserver _listenerSave;

        [Header("TableManager Local Properties")]
        [SerializeField] private TextMeshProUGUI _textInvested;
        [SerializeField] private TextMeshProUGUI _textPriceBought;
        [SerializeField] private TextMeshProUGUI _textBTC;
        [SerializeField] private TextMeshProUGUI _textGainAmount;
        [SerializeField] private TextMeshProUGUI _textGainTotal;
        [SerializeField] private TextMeshProUGUI _textGain;
        [SerializeField] private TextMeshProUGUI _textSellPrice;
        [SerializeField] private TextMeshProUGUI _textBTCSellPrice;
        [SerializeField] private Canvas _saveIconCanvas;

        private float _invested, _priceBought, _btc, _gainAmount, _gainTotal, _gain, _sellPrice, _btcSellPrice;
        private bool _isUpdate;
        private int _pointer;

        private void Awake()
        {
            _data.Reset();
            _data.Subscribe(NewElement);
            _listener.Subscribe(Listener);
            _listenerSave.Subscribe(SaveSuccessful);
        }

        private void Update()
        {
            if (_isUpdate)
            {
                UpdateValues(_data.GetData()[_pointer].gainAmount, _data.GetData()[_pointer].gainTotal, _data.GetData()[_pointer].gain);
                _pointer++;

                if(_pointer >= _data.Size())
                {
                    UpdateValuesText();
                    _isUpdate = false;
                }
            }
        }

        public void BtnSave()
        {
            _saveIconCanvas.enabled = false;
            _data.SaveData();
        }

        public void BtnLoad()
        {
            _data.LoadData();
            _saveIconCanvas.enabled = true;
        }

        private void Listener()
        {
            _isUpdate = true;
            _pointer = 0;
        }

        private void NewElement(Element element)
        {
            _invested += element.invested;
            _priceBought += element.priceBought;
            _btc += element.btc;
            _sellPrice += element.sellPrice;
            _btcSellPrice += element.btcSellPrice;
            UpdateValues(element.gainAmount, element.gainTotal, element.gain);

            _textInvested.text = _invested.ToString();
            _textPriceBought.text = (_priceBought / _data.Size()).ToString();
            _textBTC.text = _btc.ToString();
            _textSellPrice.text = _sellPrice.ToString();
            _textBTCSellPrice.text = (_btcSellPrice / _data.Size()).ToString();
            UpdateValuesText();
        }

        private void UpdateValues(float gainAmount, float gainTotal, float gain)
        {
            _gainAmount += gainAmount;
            _gainTotal += gainTotal;
            _gain += gain;
        }

        private void UpdateValuesText()
        {
            _textGainAmount.text = _gainAmount.ToString();
            _textGainTotal.text = _gainTotal.ToString();
            _textGain.text = (_gain / _data.Size()).ToString();
        }

        private void SaveSuccessful() => _saveIconCanvas.enabled = true;
    }
}