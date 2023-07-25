using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCAnt : Ant
{
  protected override void Start()
  {
    base.Start();
    if (Stats.Type == UnitType.Carry)
    {
      Debug.Log("UnitType Error");
    }
  }
}
