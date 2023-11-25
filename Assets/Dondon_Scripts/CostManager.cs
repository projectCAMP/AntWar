using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DondonScript
{
    public class CostManager : MonoBehaviour
    {
        [SerializeField] private int _maxCost = 100;
        public int MaxCost => _maxCost;
        private int _currentCost { get; set; }

        private PartyScriptableObject _partyScriptable;

        private void Start()
        {
            _currentCost = MaxCost;
            _partyScriptable = Resources.Load<PartyScriptableObject>("Data/PartyScriptableObject");
        }

        public void UseCost(int value)
        {
            _currentCost = Mathf.Max(0, _currentCost - value);
        }
    }
}