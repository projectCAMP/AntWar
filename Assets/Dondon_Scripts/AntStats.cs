using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AntStats
{
    public enum UnitType
    {
        //運搬
        Carry,
        //妨害
        CC
    }

    /// <summary>
    /// 名前
    /// </summary>
    public string Name;

    /// <summary>
    /// ユニットタイプ
    /// </summary>
    public UnitType Type;

    /// <summary>
    /// コスト
    /// </summary>
    public int Cost;

    /// <summary>
    /// 体力
    /// </summary>
    public int Health;

    /// <summary>
    /// スピード
    /// </summary>
    public int Speed;

    /// <summary>
    /// パワー
    /// </summary>
    public int Power;
}
