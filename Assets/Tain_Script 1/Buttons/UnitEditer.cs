using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEditer : MonoBehaviour
{
    //�ő�i�[��(��U���l)
    int unitMaxCount = 3;
    //���X�g�Ŋi�[�\�蕨��ێ�
    static List<int> Units = new List<int>();
    public void UnitSelect(GameObject myObj)
    {
        if (Units.Count < unitMaxCount)
        {
            Units.Add(myObj.GetComponent<UnitInformation>().editNumber);
        }
    }

    public void UnitDecision()
    {
        if(Units.Count < unitMaxCount) { unitMaxCount = Units.Count; }
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
