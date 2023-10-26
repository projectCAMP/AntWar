using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public void EnemyPoolGenerator()
    {
        UnitEditer editor = new UnitEditer();
        for(int i = 0; i < 3; i++)
        {
            editor.UnitSelect(GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(3 + i).gameObject);
        }
        editor.UnitDecision("enemy");
    }
}
