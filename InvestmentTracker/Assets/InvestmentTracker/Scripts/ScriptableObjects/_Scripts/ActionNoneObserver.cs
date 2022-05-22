using System;
using UnityEngine;

namespace InvestmentTracker.ScriptableObjects.Scripts
{
    [CreateAssetMenu(fileName = "ActionNoneObserver",
                     menuName = "InvestmentTracker/ScriptableObjects/ActionNoneObserver",
                     order = 1)]
    public class ActionNoneObserver : BaseScriptableObject
    {
        private Action _action;

        public void Subscribe(Action action) => _action += action;
        public void Unsubscribe(Action action) => _action -= action;
        public void Trigger() => _action();
    }
}