using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CostManager : MonoBehaviour
{
    //�Q�[����Ŏg�p����R�X�g
    int cost;
    //�����ŃR�X�g�ǉ��^�C�~���O�����肷�郂�m
    [SerializeField] int costTiming;
    //�R�X�g�̍ő�����肷��
    [SerializeField] int maxCost;

    [SerializeField] TextMeshProUGUI costDisplay;

    bool gameStart;

    PartyScriptableObject partyData = new PartyScriptableObject();
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
            Debug.Log("����");
        }
        else
        {
            Debug.Log("���s");
        }
        costDisplay.text = cost + " / " + maxCost;
    }
}
