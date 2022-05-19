using UnityEngine;

namespace InvestmentTracker.ScriptableObjects.Scripts
{
    [CreateAssetMenu(fileName = "FloatVariable",
                     menuName = "InvestmentTracker/ScriptableObjects/FloatVariable",
                     order = 1)]
    public class FloatVariable : BaseScriptableObject
    {
        private float _value;

        public float GetValue() => _value;
        public void SetValue(float value) => _value = value;
    }
}