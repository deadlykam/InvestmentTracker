using UnityEngine;

namespace InvestmentTracker.Menus
{
    public class BaseMenu : MonoBehaviour
    {
        [Header("BaseMenu Local Properties")]
        [SerializeField] private Canvas _mainCanvas;

        /// <summary>
        /// This method shows the menu.
        /// </summary>
        public virtual void ShowMenu() => _mainCanvas.enabled = true;

        /// <summary>
        /// This method hides the menu.
        /// </summary>
        public virtual void HideMenu() => _mainCanvas.enabled = false;

        /// <summary>
        /// This method checks if the menu is showing.
        /// </summary>
        /// <returns>True means the menu is showing, false otherwise, of type bool</returns>
        public bool IsShown() => _mainCanvas.enabled;
    }
}