using UnityEngine;

namespace InvestmentTracker.ScriptableObjects.Scripts
{
    [CreateAssetMenu(fileName = "UniqueIDGenerator",
                     menuName = "InvestmentTracker/ScriptableObjects/UniqueIDGenerator",
                     order = 1)]
    public class UniqueIDGenerator : BaseScriptableObject
    {
        private int _id = -1; // So that starting will be 0

        private void Awake() => _id = -1;
        public void Reset() => _id = -1;
        public int GetID() => ++_id;
        public int GetCurrentID() => _id;
    }
}