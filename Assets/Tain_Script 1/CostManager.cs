using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CostManager : MonoBehaviour
{
    //�Q�[����Ŏg�p����R�X�g
    int cost;
    //�����ŃR�X�g�ǉ��^�C�~���O�����肷�郂�m
    int costAddTiming;
    //�R�X�g�̍ő�l�����肷��
    int maxCost;
    //�R�X�g��ǉ�����܂ł�~�ς���
    int timingCounter;
    //�R�X�g�̐����n�߂𔻒f
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
    //�R�X�g�𑝂₵�n�߂�^�C�~���O�ɂ��̊֐���}��
    public void CostStarter()
    {
        gameStart = true;
    }
    public void CostConsumption()
    {

    }
}
