using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Objectvalue objValueScript;
    [SerializeField] objectgeneration objGeneration;

    public void EnemyGenerate()
    {
        int typeRandomInteger = Random.Range(0, 4);
        objGeneration.Objectnumber = typeRandomInteger;
        int posRandomInter = Random.Range(0, 4);
        objGeneration.generation(posRandomInter);
    }
}
