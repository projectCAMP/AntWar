using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 運搬ユニットのスクリプト
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class CarryAnt : Ant
{
  protected override void Start()
  {
    base.Start();
    if (Stats.Type == UnitType.CC)
    {
      Debug.Log("UnitType Error");
    }
  }

  /// <summary>
  /// Resourceという名前のオブジェクトにぶつかるとそのオブジェクトの子オブジェクトになる
  /// </summary>
  /// <param name="collision"></param>
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.name == "Resource")
    {
      transform.parent = collision.transform;
    }
  }

  private void OnTriggerStay2D(Collider2D collision)
  {
    if (collision.gameObject.name == "Resource")
    {
      transform.parent = collision.transform;
    }
  }

}
