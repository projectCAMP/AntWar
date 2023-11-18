using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddUnitButton : MonoBehaviour
{
    [SerializeField]
    private PartyScriptableObject _partyScriptableObject;

    [SerializeField]
    private AntData _antData;

    [SerializeField]
    private int antNumber = 0;

    private void OnEnable()
    {
        _partyScriptableObject = Resources.Load<PartyScriptableObject>("Data/PartyScriptableObject");
        _antData = Resources.Load<AntData>("Data/AntData");
    }

    public void ButtonPushed()
    {
        for (int i = 0; i < 3; i++)
            _partyScriptableObject.SetAnt(_antData.PrefabList[antNumber], i);
    }
}