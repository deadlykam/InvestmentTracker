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

        private void Awake()
        {
            _stockPrice.SetValue(24000.00f); // REMOVE THIS TEST VALUE AND REPLACE FROM ONLINE
            _stockValue.text = $"£{_stockPrice.GetValue().ToString()}";
        }
    }
}