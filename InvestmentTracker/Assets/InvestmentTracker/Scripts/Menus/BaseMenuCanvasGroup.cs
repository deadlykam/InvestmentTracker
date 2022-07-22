using UnityEngine;

namespace InvestmentTracker.Menus
{
    public class BaseMenuCanvasGroup : BaseMenu
    {
        [Header("BaseMenuCanvasGroup Local Properties")]
        [SerializeField] private CanvasGroup _mainCanvasGroup;

        public override void ShowMenu() => SetMainGroupCanvas(true);
        public override void HideMenu() => SetMainGroupCanvas(false);
        public override bool IsShown() => _mainCanvasGroup.alpha > 0f;
        public void SetAlpha(float value) => _mainCanvasGroup.alpha = value;

        private void SetMainGroupCanvas(bool isEnable)
        {
            _mainCanvasGroup.alpha = isEnable ? 1f : 0f;
            _mainCanvasGroup.interactable = isEnable;
            _mainCanvasGroup.blocksRaycasts = isEnable;
        }
    }
}