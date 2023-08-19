using System.Collections.Generic;
using UnityEngine;

public class ButtonTap : MonoBehaviour
{
    [SerializeField] Information Info;
    [SerializeField] int unitCounter;
    //�t�F�[�Y��ύX����{�^���p�ϐ�
    public int phaseValue = 99;
    //���j�b�g�̔z��\����e
    public bool update;
    //���j�b�g��index
    int unitIndex = 0;
    //���j�b�g�̕ҏW�\��
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
