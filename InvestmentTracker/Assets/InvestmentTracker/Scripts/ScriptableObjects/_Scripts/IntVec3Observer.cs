using System;
using UnityEngine;

namespace InvestmentTracker.ScriptableObjects.Scripts
{
    [CreateAssetMenu(fileName = "IntVec3Variable",
                     menuName = "InvestmentTracker/ScriptableObjects/IntVec3Variable",
                     order = 1)]
    public class IntVec3Observer : BaseScriptableObject
    {
        private Action<int, Vector3> _observers;
        private int _valueInt;
        private Vector3 _valueVec3;

        public void SetValue(int valueInt, Vector3 valueVec3)
        {
            _valueInt = valueInt;
            _valueVec3 = valueVec3;
            Trigger();
        }

        public void Trigger() => _observers(_valueInt, _valueVec3);
        public void Subscribe(Action<int, Vector3> observer) => _observers += observer;
        public void Unsubscribe(Action<int, Vector3> observer) => _observers -= observer;
    }
}