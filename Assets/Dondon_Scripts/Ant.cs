using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{
  /// <summary>
  /// ステータス参照用
  /// </summary>
  [SerializeField]
  private AntStats _stats;
  public AntStats Stats => _stats;

  /// <summary>
  /// 敵ならばtrue
  /// </summary>
  [SerializeField]
  private bool _isHostile;
  public bool IsHostile => _isHostile;

  /// <summary>
  /// 現在体力
  /// </summary>
  private int _health;
  public int Health => _health;

  /// <summary>
  /// 現在スピード
  /// </summary>
  private int _speed;
  public int Speed => _speed;

  /// <summary>
  /// 現在パワー
  /// </summary>
  private int _power;
  public int Power => _power;

  protected virtual void Start()
  {
    if (!IsHostile)
    {
      _health = Stats.Health;
      _speed = Stats.Speed;
      _power = Stats.Power;
    }
    else if (IsHostile)
    {
      _health = Stats.Health;
      _speed = Stats.Speed;
      //敵ならばパワーをマイナスに
      _power = -Stats.Power;
    }
  }
}
