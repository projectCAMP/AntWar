using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    //bool値を一時的に持つ
    bool flag;
    public void PhaseChanger(int value)
    {
        phaseValue = value;
        update = true;
    }
    public void PanelChanger(int value)
    {
        //新しくパネルを追加したら下の方で消す処理を追加するのを忘れずに
        AllPanelVanish();
        switch (value)
        {
            case 0:
                Info.GamePanel.SetActive(true);
                //CostManager.instance.CostStarter();
                break;
            case 1:
                Info.MenuPanel.SetActive(true);
                if (flag)
                {
                    var imageStuck = Info.MenuPanel.GetComponent<Image>();
                    imageStuck.color = new Color(imageStuck.color.r, imageStuck.color.g, imageStuck.color.b, 255);
                    flag = false;
                }
                break;
            case 2:
                Info.EditPanel.SetActive(true);
                break;
            //settingPanelだけ特殊
            case 3:
                Info.MenuPanel.SetActive(true);
                var imageStuck2 =  Info.MenuPanel.GetComponent<Image>();
                imageStuck2.color = new Color(imageStuck2.color.r, imageStuck2.color.g, imageStuck2.color.b, 120);
                Info.SettingPanel.SetActive(true);
                flag = true;
                break;
        }
    }
    public void UnitChanger(int value)
    {
        if (unitIndex < unitCounter)
        {
            //Info.SE.PlayOneShot(Info.sound);
            AudioManager.instance.PlaySE(AudioManager.SE.ButtonTap);
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
        AudioManager.instance.PlaySE(AudioManager.SE.Any);
        unitIndex = 0;
        unitsStock.Clear();
    }
    public void UnitReflesh()
    {
        unitIndex = 0;
        for(int i = 0; i < 3; i++)
        {
            Info.unitDisplay[i].sprite = Info.unitDefault;
        }
    }
    void AllPanelVanish()
    {
        Info.GamePanel.SetActive(false);
        Info.MenuPanel.SetActive(false);
        Info.EditPanel.SetActive(false);
        Info.SettingPanel.SetActive(false);
    }

    public void buttonpush(int value)
    {
        AntPool.AntIndex = value;
    }

    public void GenerateAction(int value)
    {
        //CostManager.instance.CostDecrease(value);
    }
    public void ChangeScene(string sceneName)
    {
        AudioManager.instance.PlayBGM(AudioManager.BGM.GamePlay);
        SceneManager.LoadScene(sceneName);
    }
}
