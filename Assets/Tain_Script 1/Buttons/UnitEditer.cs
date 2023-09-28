using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEditer : MonoBehaviour
{
    //最大格納数(一旦即値)
    int unitMaxCount = 3;
    //リストで格納予定物を保持
    static List<int> Units = new List<int>();
    //パーティーのデータを取得
    PartyScriptableObject partyData = null;
    public void UnitSelect(GameObject myObj)
    {
        if (Units.Count < unitMaxCount)
        {
            Units.Add(myObj.GetComponent<UnitInformation>().editNumber);
        }
    }

    public void UnitDecision()
    {
        if(partyData == null)
        {
            partyData = Resources.Load<PartyScriptableObject>("Data/PartyScriptableObject1");
        }
        if(Units.Count < unitMaxCount) { unitMaxCount = Units.Count; }
        Pools objectPooler = new Pools("Initialize");
        objectPooler.PoolClear();
        for (int i = 0; i < unitMaxCount; i++)
        {
            Debug.Log(partyData.AntList[i]);
            objectPooler.PoolInput(partyData.AntList[i]);
        }
        objectPooler.CreatePool();
        Units.Clear();
    }

    public void UnitReset()
    {
        Units.Clear();
    }
}
