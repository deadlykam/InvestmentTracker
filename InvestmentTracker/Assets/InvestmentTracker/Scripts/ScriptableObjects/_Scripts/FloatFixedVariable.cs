using UnityEngine;

namespace InvestmentTracker.ScriptableObjects.Scripts
{
    [CreateAssetMenu(fileName = "FloatFixedVariable",
                     menuName = "InvestmentTracker/ScriptableObjects/FloatFixedVariable",
                     order = 1)]
    public class FloatFixedVariable : BaseScriptableObject
    {
        [SerializeField] private float _value;

        public float GetValue() => _value;
    }
}