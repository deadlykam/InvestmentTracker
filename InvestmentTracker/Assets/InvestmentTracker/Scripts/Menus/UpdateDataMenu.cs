using InvestmentTracker.ScriptableObjects.Scripts;
using TMPro;
using UnityEngine;

namespace InvestmentTracker.Menus
{
    public class UpdateDataMenu : BaseMenu
    {
        [Header("AddDataMenu Global Properties")]
        [SerializeField] private Data _data;
        [SerializeField] private IntVec3Observer _listenerHighlight;
        [SerializeField] private ActionNoneObserver _observers;

        [Header("AddDataMenu Local Properties")]
        [SerializeField] private GameObject _screenDisabler;
        [SerializeField] private TMP_InputField _date;
        [SerializeField] private TMP_InputField _invested;
        [SerializeField] private TMP_InputField _price;
        [SerializeField] private TMP_InputField _btc;
        [SerializeField] private TMP_InputField _platform;

        private int _id = -1;

        private void Start() => _listenerHighlight.Subscribe(SelectedData);

        private void Update()
        {
            if (IsShown())
            {
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    if (_date.isFocused) _invested.Select();
                    else if (_invested.isFocused) _price.Select();
                    else if (_price.isFocused) _btc.Select();
                    else if (_btc.isFocused) _platform.Select();
                    else _date.Select();
                }

                //if (Input.GetKeyDown(KeyCode.LeftControl)) UpdateData(); // Update Key
            }
        }

        public void UpdateData()
        {
            _data.GetData()[_id].date = _date.text;
            _data.GetData()[_id].invested = float.Parse(_invested.text);
            _data.GetData()[_id].priceBought = float.Parse(_price.text);
            _data.GetData()[_id].btc = float.Parse(_btc.text);
            _data.GetData()[_id].platform = _platform.text;
            _observers.Trigger();
            HideMenu();
        }

        public override void ShowMenu()
        {
            if (_id != -1)
            {
                base.ShowMenu();
                _screenDisabler.SetActive(true);
                _date.text = _data.GetData()[_id].date;
                _invested.text = _data.GetData()[_id].invested.ToString();
                _price.text = _data.GetData()[_id].priceBought.ToString();
                _btc.text = _data.GetData()[_id].btc.ToString();
                _platform.text = _data.GetData()[_id].platform;
            }
        }

        public override void HideMenu()
        {
            base.HideMenu();
            _screenDisabler.SetActive(false);
        }

        private void SelectedData(int id, Vector3 pos) => _id = id;
    }
}