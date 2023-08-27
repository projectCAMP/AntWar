using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//参考：https://ekulabo.com/csv-to-scriptable-object

//ユニットの種類
public enum UnitType_old
{
  //運搬
  Carry,
  //妨害
  CC
}

[CreateAssetMenu(menuName = "MyScriptable/ Create AntData")]
public class AntStats_old : ScriptableObject
{
  /// <summary>
  /// 名前
  /// </summary>
  [SerializeField]
  private string _name;
  public string Name { get { return _name; } set { _name = value; } }

  /// <summary>
  /// ユニットタイプ
  /// </summary>
  [SerializeField]
  private UnitType_old _type;
  public UnitType_old Type { get { return _type; } set { _type = value; } }

  /// <summary>
  /// コスト
  /// </summary>
  [SerializeField]
  private int _cost;
  public int Cost { get { return _cost; } set { _cost = value; } }

  /// <summary>
  /// 体力
  /// </summary>
  [SerializeField]
  private int _health;
  public int Health { get { return _health; } set { _health = value; } }

  /// <summary>
  /// スピード
  /// </summary>
  [SerializeField]
  private int _speed;
  public int Speed { get { return _speed; } set { _speed = value; } }

  /// <summary>
  /// パワー
  /// </summary>
  [SerializeField]
  private int _power;
  public int Power { get { return _power; } set { _power = value; } }
}
