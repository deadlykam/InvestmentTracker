using InvestmentTracker.ScriptableObjects.Scripts;
using System;
using TMPro;
using UnityEngine;

namespace InvestmentTracker.Menus
{
    public class AddDataMenu : BaseMenu
    {
        [Header("AddDataMenu Global Properties")]
        [SerializeField] private Data _data;

        [Header("AddDataMenu Local Properties")]
        [SerializeField] private GameObject _screenDisabler;
        [SerializeField] private TMP_InputField _date;
        [SerializeField] private TMP_InputField _invested;
        [SerializeField] private TMP_InputField _price;
        [SerializeField] private TMP_InputField _btc;
        [SerializeField] private TMP_InputField _platform;

        private DateTime _dateTime;

        public void AddData()
        {
            _data.AddData(_date.text, float.Parse(_invested.text), float.Parse(_price.text), float.Parse(_btc.text), _platform.text);
            HideMenu();
        }

        public override void ShowMenu()
        {
            base.ShowMenu();
            _screenDisabler.SetActive(true);
            _dateTime = DateTime.Today;
            _date.text = _dateTime.ToString("dd/MM/yyyy");
            _invested.text = "";
            _price.text = "";
            _btc.text = "";
            _platform.text = "";
        }

        public override void HideMenu()
        {
            base.HideMenu();
            _screenDisabler.SetActive(false);
        }
    }
}