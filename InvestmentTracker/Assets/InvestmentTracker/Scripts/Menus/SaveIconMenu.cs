using InvestmentTracker.ScriptableObjects.Scripts;
using UnityEngine;

namespace InvestmentTracker.Menus
{
    public class SaveIconMenu : BaseMenuCanvasGroup
    {
        [Header("SaveIconMenu Global Properties")]
        [SerializeField] private FloatFixedVariable _timeSeconds;

        [Header("SaveIconMenu Local Properties")]

        private float _currentTime;
        private bool _isTimer = false;

        private void Update()
        {
            if (_isTimer)
            {
                _currentTime += Time.deltaTime;

                if(_currentTime >= _timeSeconds.GetValue())
                {
                    _isTimer = false;
                    SetAlpha(0);
                    return;
                }

                SetAlpha(1f - (_currentTime / _timeSeconds.GetValue())); // Setting alpha value through time
            }
        }

        public override void ShowMenu()
        {
            SetAlpha(1f);
            _currentTime = 0f;
        }

        public override void HideMenu() => _isTimer = true;
    }
}