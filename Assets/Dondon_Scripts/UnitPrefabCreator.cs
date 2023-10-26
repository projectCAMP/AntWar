using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エディタ拡張用のスクリプタブルオブジェクト
/// </summary>
[CreateAssetMenu(fileName = "UnitPrefabCreator", menuName = "UnitPrefabCreator", order = 0)]
public class UnitPrefabCreator : ScriptableObject
{
    public AntData MasterData;
}