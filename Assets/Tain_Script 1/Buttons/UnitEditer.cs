using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEditer : MonoBehaviour
{
    //Å‘åŠi”[”(ˆê’U‘¦’l)
    int unitMaxCount = 3;
    //ƒŠƒXƒg‚ÅŠi”[—\’è•¨‚ğ•Û
    List<int> Units = new List<int>();
    public void UnitSelect()
    {
        if (Units.Count < unitMaxCount)
        {
            Units.Add(this.gameObject.GetComponent<UnitInformation>().editNumber);
        }
    }

    public void UnitDecision()
    {
        for (int i = 0; i < unitMaxCount; i++)
        {
            Datas.units.Add(Units[i]);
        }
        Units.Clear();
    }

    public void UnitReset()
    {
        Units.Clear();
    }
}
