using System;
using UnityEngine;

namespace InvestmentTracker.ScriptableObjects.Scripts
{
    [CreateAssetMenu(fileName = "ActionNone",
                     menuName = "InvestmentTracker/ScriptableObjects/ActionNone",
                     order = 1)]
    public class ActionNone : BaseScriptableObject
    {
        private Action _action;

        /// <summary>
        /// This method sets the action delegate.
        /// </summary>
        /// <param name="action">The action delegate to set, of type
        ///                      Action</param>
        public virtual void SetDelegate(Action action) => _action = action;

        /// <summary>
        /// This method calls the delegate.
        /// </summary>
        public virtual void CallDelegate() => _action();
    }
}