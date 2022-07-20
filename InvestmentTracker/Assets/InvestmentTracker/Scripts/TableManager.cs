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
        [SerializeField] private ActionNone _triggerUpdate;

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
        [SerializeField] private CanvasGroup _savePromptCanvasGroup;

        private float _invested, _priceBought, _btc, _gainAmount, _gainTotal, _gain, _sellPrice, _btcSellPrice;
        private bool _isUpdate;
        private int _pointer;

        private void Awake()
        {
            _data.Reset();
            _data.Subscribe(NewElement);
            _listener.Subscribe(Listener);
            _listenerSave.Subscribe(SaveSuccessful);
            _triggerUpdate.SetDelegate(Listener);
        }

        private void Update()
        {
            if (_isUpdate)
            {
                UpdateValues(_data.GetData()[_pointer]);
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
            if (_data.IsSaveFileExist()) SetSavePromptCanvas(true);
            else SaveData();
        }

        public void BtnSaveFORCED() 
        {  
            SaveData();
            SetSavePromptCanvas(false);
        }

        public void BtnHidePrompt() => SetSavePromptCanvas(false);

        public void BtnLoad()
        {
            _data.LoadData();
            _saveIconCanvas.enabled = true;
        }

        private void Listener()
        {
            _isUpdate = true;
            _pointer = 0;
            _invested = 0;
            _priceBought = 0;
            _btc = 0;
            _sellPrice = 0;
            _btcSellPrice = 0;
            _gainAmount = 0;
            _gainTotal = 0;
            _gain = 0;
        }

        private void SaveData()
        {
            _saveIconCanvas.enabled = false;
            _data.SaveData();
        }

        private void SetSavePromptCanvas(bool isEnable)
        {
            _savePromptCanvasGroup.alpha = isEnable ? 1f : 0f;
            _savePromptCanvasGroup.interactable = isEnable;
            _savePromptCanvasGroup.blocksRaycasts = isEnable;
        }

        private void NewElement(Element element)
        {
            UpdateValues(element);
            UpdateValuesText();
        }

        private void UpdateValues(Element element)
        {
            _invested += element.invested;
            _priceBought += element.priceBought;
            _btc += element.btc;
            _sellPrice += element.sellPrice;
            _btcSellPrice += element.btcSellPrice;
            _gainAmount += element.gainAmount;
            _gainTotal += element.gainTotal;
            _gain += element.gain;
        }

        private void UpdateValuesText()
        {
            _textInvested.text = _invested.ToString();
            _textPriceBought.text = (_priceBought / _data.Size()).ToString();
            _textBTC.text = _btc.ToString("0.00000000");
            _textSellPrice.text = _sellPrice.ToString();
            _textBTCSellPrice.text = (_btcSellPrice / _data.Size()).ToString();
            _textGainAmount.text = _gainAmount.ToString("0.00");
            _textGainTotal.text = _gainTotal.ToString("0.00");
            _textGain.text = (_gain / _data.Size()).ToString("0.00");
        }

        private void SaveSuccessful() => _saveIconCanvas.enabled = true;
    }
}