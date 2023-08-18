using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 妨害ユニットのスクリプト
/// </summary>
public class CCAnt : Ant
{
    protected override void Start()
    {
        base.Start();
        if (Stats.Type == AntStats.UnitType.Carry)
        {
            Debug.Log("UnitType Error");
        }
    }
}
