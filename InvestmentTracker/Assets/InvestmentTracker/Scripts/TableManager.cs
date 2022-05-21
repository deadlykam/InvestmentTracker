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

        [Header("TableManager Local Properties")]
        [SerializeField] private TextMeshProUGUI _textInvested;
        [SerializeField] private TextMeshProUGUI _textPriceBought;
        [SerializeField] private TextMeshProUGUI _textBTC;
        [SerializeField] private TextMeshProUGUI _textGainAmount;
        [SerializeField] private TextMeshProUGUI _textGainTotal;
        [SerializeField] private TextMeshProUGUI _textGain;
        [SerializeField] private TextMeshProUGUI _textSellPrice;
        [SerializeField] private TextMeshProUGUI _textBTCSellPrice;

        private float _invested, _priceBought, _btc, _gainAmount, _gainTotal, _gain, _sellPrice, _btcSellPrice;
        private bool _isUpdate;
        private int _pointer;

        private void Awake()
        {
            _data.Reset();
            _data.Subscribe(NewElement);
            _listener.Subscribe(Listener);
        }

        private void Update()
        {
            if (_isUpdate)
            {
                UpdateValues(_data.GetData()[_pointer].GetGainAmount(), _data.GetData()[_pointer].GetGainTotal(), _data.GetData()[_pointer].GetGain());
                _pointer++;

                if(_pointer >= _data.Size())
                {
                    UpdateValuesText();
                    _isUpdate = false;
                }
            }
        }

        public void BtnSave() => _data.SaveData();
        public void BtnLoad() => _data.LoadData();

        private void Listener()
        {
            _isUpdate = true;
            _pointer = 0;
        }

        private void NewElement(Element element)
        {
            _invested += element.GetInvested();
            _priceBought += element.GetPriceBought();
            _btc += element.GetBTC();
            _sellPrice += element.GetSellPrice();
            _btcSellPrice += element.GetBTCSellPrice();
            UpdateValues(element.GetGainAmount(), element.GetGainTotal(), element.GetGain());

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
    }
}