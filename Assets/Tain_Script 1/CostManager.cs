using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CostManager : MonoBehaviour
{
    public static CostManager instance;

    //ゲーム上で使用するコスト
    int cost;
    //内部でコスト追加タイミングを決定するモノ
    [SerializeField] int costTiming;
    //コストの最大を決定する
    [SerializeField] int maxCost;

    [SerializeField] TextMeshProUGUI costDisplay;

    bool gameStart;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (gameStart)
        {
            costTiming++;
            if(costTiming > 200)
            {
                if (cost <= maxCost)
                {
                    cost++;
                }
                costTiming = 0;
                costDisplay.text = cost + " / " + maxCost;
            }
        }
    }
    public void CostStarter()
    {
        gameStart = true;
    }

    public void CostDecrease(int value)
    {
        if (cost >= value)
        {
            cost -= value;
            Debug.Log("成功");
        }
        else
        {
            Debug.Log("失敗");
        }
        costDisplay.text = cost + " / " + maxCost;
    }
}
