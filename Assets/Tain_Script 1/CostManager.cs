using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CostManager : MonoBehaviour
{
    //ゲーム上で使用するコスト
    int cost;
    //内部でコスト追加タイミングを決定するモノ
    int costAddTiming;
    //コストの最大値を決定する
    int maxCost;
    //コストを追加するまでを蓄積する
    int timingCounter;
    //コストの数え始めを判断
    bool gameStart;

    public CostManager(int costTime, int maxValue)
    {
        costAddTiming = costTime;
        maxCost = maxValue;
    }
    private void Update()
    {
        if (gameStart)
        {
            timingCounter++;
            if(timingCounter > costAddTiming)
            {
                if (cost <= maxCost)
                {
                    cost++;
                }
                costAddTiming = 0;
            }
        }
    }
    //コストを増やし始めるタイミングにこの関数を挿入
    public void CostStarter()
    {
        gameStart = true;
    }
    public void CostConsumption()
    {

    }
}
