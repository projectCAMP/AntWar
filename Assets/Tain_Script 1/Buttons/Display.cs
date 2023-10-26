using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour
{
    public void PanelDisplay(Information.panelJudges panelEnum)
    {
        AllPanelVanish();
        Information.panelDictionary[panelEnum].SetActive(true);
    }

    public void PopDisplay(Information.popJudges popEnum)
    {
        AllPopVanish();
        //�\�����e��none�̏ꍇ�́Apop�����������ɂȂ�
        if (popEnum != Information.popJudges.none)
        {
            Information.popDictionary[popEnum].SetActive(true);
        }
    }

    void AllPanelVanish()
    {
        foreach(KeyValuePair<Information.panelJudges, GameObject> vanish in Information.panelDictionary)
        {
            if (vanish.Value != null)
            {
                vanish.Value.SetActive(false);
            }
        }
    }

    void AllPopVanish()
    {
        foreach (KeyValuePair<Information.popJudges, GameObject> vanish in Information.popDictionary)
        {
            if (vanish.Value != null)
            {
                vanish.Value.SetActive(false);
            }
        }
    }
}