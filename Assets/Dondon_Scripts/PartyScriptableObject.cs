using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 編成されるパーティーをScriptableObjectで管理する
/// Prefabを4つもつ
/// </summary>
[CreateAssetMenu(fileName = "PartyScriptableObject", menuName = "PartyScriptableObject", order = 0)]
public class PartyScriptableObject : ScriptableObject
{
    public GameObject[] AntList => _antList;

    private GameObject[] _antList = new GameObject[4];

    private GameObject[] _prefabs;

    public void SetAnt(GameObject prefab, int number)
    {
        if (number > 3) return;
        _antList[number] = prefab;
    }

    public void ResetParty()
    {
        for (int i = 0; i < _antList.Length; i++)
        {
            _antList[i] = null;
        }
    }
}