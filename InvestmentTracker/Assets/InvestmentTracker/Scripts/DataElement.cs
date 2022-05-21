using InvestmentTracker.Core;
using InvestmentTracker.ScriptableObjects.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InvestmentTracker
{
    public class DataElement : MonoBehaviour
    {
        [Header("DataElement Global Properties")]
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
        [SerializeField] private Image _indicator;
        [SerializeField] private Color _colGain;
        [SerializeField] private Color _colLoss;
        [SerializeField] private Color _colNutral;

        private Element _data;
        private float _gainMax = 50.0f;
        private float _gainMin = -25.0f;


        public void SetDataElement(Element element)
        {
            _data = element;
            _id.text = _data.id.ToString();
            _date.text = _data.date;
            _invested.text = _data.invested.ToString();
            _price.text = _data.priceBought.ToString();
            _stockAmount.text = _data.btc.ToString();
            _platform.text = _data.platform.ToString();
            _sellPrice.text = _data.sellPrice.ToString();
            _btcSellPrice.text = _data.btcSellPrice.ToString();
            UpdateData();
        }

        public void UpdateData()
        {
            if (_data != null)
            {
                _gainAmount.text = _data.gainAmount.ToString();
                _gainTotal.text = _data.gainTotal.ToString();
                _gain.text = _data.gain.ToString();

                if (_data.gain >= 0f) _indicator.color = Color.Lerp(_colNutral, _colGain, (_data.gain / _gainMax) >= 1f ? 1 : _data.gain / _gainMax);
                else _indicator.color = Color.Lerp(_colNutral, _colLoss, (_data.gain / _gainMin) >= 1 ? 1 : (_data.gain / _gainMin));
            }
        }
    }
}