using InvestmentTracker.Core;
using InvestmentTracker.ScriptableObjects.Scripts;
using TMPro;
using UnityEngine;

namespace InvestmentTracker
{
    public class DataElement : MonoBehaviour
    {
        [Header("DataElement Global Properties")]
        [SerializeField] private FloatVariable _stockPrice;
        [SerializeField] private FloatFixedVariable _targetXTime;

        [Header("DataElement Local Properties")]
        [SerializeField] private TextMeshProUGUI _id;
        [SerializeField] private TextMeshProUGUI _date;
        [SerializeField] private TextMeshProUGUI _invested;
        [SerializeField] private TextMeshProUGUI _price;
        [SerializeField] private TextMeshProUGUI _stockAmount;
        [SerializeField] private TextMeshProUGUI _gainAmount;
        [SerializeField] private TextMeshProUGUI _gainTotal;
        [SerializeField] private TextMeshProUGUI _gain;
        [SerializeField] private TextMeshProUGUI _sellPrice;
        [SerializeField] private TextMeshProUGUI _btcSellPrice;
        [SerializeField] private TextMeshProUGUI _platform;

        private Element _data;
        private float _gainValue;

        public void SetDataElement(Element element)
        {
            _data = element;
            _id.text = _data.GetID().ToString();
            _date.text = _data.GetDate();
            _invested.text = _data.GetInvested().ToString();
            _price.text = _data.GetPriceBought().ToString();
            _stockAmount.text = _data.GetBTC().ToString();
            _platform.text = _data.GetPlatform().ToString();
            UpdateData();
        }

        public void UpdateData()
        {
            if (_data != null)
            {
                _gainValue = ((_stockPrice.GetValue() - _data.GetPriceBought()) / _data.GetPriceBought()) * 100;
                _gainAmount.text = ((_gainValue / 100) * _data.GetInvested()).ToString();
                _gainTotal.text = (((_gainValue / 100) + 1) * _data.GetInvested()).ToString();
                _gain.text = _gainValue.ToString();
                _sellPrice.text = (_targetXTime.GetValue() * _data.GetInvested()).ToString();
                _btcSellPrice.text = (_targetXTime.GetValue() * _data.GetPriceBought()).ToString();
            }
        }
    }
}