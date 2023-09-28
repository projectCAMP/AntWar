using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEditer : MonoBehaviour
{
    //�ő�i�[��(��U���l)
    int unitMaxCount = 3;
    //���X�g�Ŋi�[�\�蕨��ێ�
    static List<int> Units = new List<int>();
    //�p�[�e�B�[�̃f�[�^���擾
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
