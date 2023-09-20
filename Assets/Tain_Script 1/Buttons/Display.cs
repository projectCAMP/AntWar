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
        Debug.Log("##");
        AllPopVanish();
        //ï\é¶ì‡óeÇ™noneÇÃèÍçáÇÕÅApopÇè¡Ç∑èàóùÇ…Ç»ÇÈ
        if (popEnum != Information.popJudges.none)
        {
            Information.popDictionary[popEnum].SetActive(true);
        }
    }

    void AllPanelVanish()
    {
        foreach(KeyValuePair<Information.panelJudges, GameObject> vanish in Information.panelDictionary)
        {
            vanish.Value.SetActive(false);
        }
    }

    void AllPopVanish()
    {
        foreach (KeyValuePair<Information.popJudges, GameObject> vanish in Information.popDictionary)
        {
            vanish.Value.SetActive(false);
        }
    }
}