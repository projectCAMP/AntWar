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
    public GameObject[] AntList => antList;

    private GameObject[] antList = new GameObject[4];

    public void SetAnt(GameObject prefab, int number)
    {
        if (number > 3) return;
        antList[number] = prefab;
    }
}