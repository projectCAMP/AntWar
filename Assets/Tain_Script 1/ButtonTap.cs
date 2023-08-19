using System.Collections.Generic;
using UnityEngine;

public class ButtonTap : MonoBehaviour
{
    [SerializeField] Information Info;
    [SerializeField] int unitCounter;
    //フェーズを変更するボタン用変数
    public int phaseValue = 99;
    //ユニットの配列予定内容
    public bool update;
    //ユニットのindex
    int unitIndex = 0;
    //ユニットの編集可能数
    List<int> unitsStock = new List<int>();
    public void PhaseChanger(int value)
    {
        phaseValue = value;
        update = true;
    }
    public void PanelChanger(int value)
    {
        AllPanelVanish();
        switch (value)
        {
            case 0:
                Info.GamePanel.SetActive(true);
                break;
            case 1:
                Info.MenuPanel.SetActive(true);
                break;
            case 2:
                Info.EditPanel.SetActive(true);
                break;
        }
    }
    public void UnitChanger(int value)
    {
        if (unitIndex < unitCounter)
        {
            unitsStock.Add(value);
            unitIndex++;
        }
    }
    
    public void UnitDecide()
    {
        for(int i = 0; i < unitIndex; i++)
        {
            Datas.units.Add(unitsStock[i]);
        }
        unitIndex = 0;
        unitsStock.Clear();
    }
    public void UnitReflesh()
    {
        unitIndex = 0;
    }
    void AllPanelVanish()
    {
        Info.GamePanel.SetActive(false);
        Info.MenuPanel.SetActive(false);
        Info.EditPanel.SetActive(false);
    }

    public void buttonpush(int value)
    {
        AntPool.AntIndex = value;
    }
}
