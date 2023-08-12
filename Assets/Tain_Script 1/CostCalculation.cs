using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostCalculation : MonoBehaviour
{
    public void DecideCost(int value)//0番から自軍のキャラクターのインデックスを指定する
    {
        Main.characterIndex = value;
    }
}
