using System.Collections.Generic;
using UnityEngine;

public class ActionButton : BasicButton
{
    //ボタンの役割を表す分岐
    [SerializeField] Role role;
    public enum Role
    {
        unitEditer,
        sceneMover,
        panelpopInformationInitializer,
        panelDisplay,
        popDisplay
    }

    //-----------------------------------------
    //ボタンのアクション内容分岐
    [SerializeField] ActionSplit actionInput;
    public enum ActionSplit
    {
        none,
        unitSelect,
        unitDecision,
        enemyDecision,
        unitReset
    }

    //シーン遷移先を入力
    [SerializeField] SceneName sceneInput;
    public enum SceneName
    {
        none,
        tainScene,
        playScene
    }

    //パネルやポップを受け渡しする
    [SerializeField] Information.panelJudges panelInput;
    [SerializeField] Information.popJudges popInput;

    //displayにおいてInformationの内容を初期化するために必要
    private void Start()
    {
        if (role == Role.panelpopInformationInitializer)
        {
            display = new Display();
        }
    }

    public override void OnMouseUp()
    {
        switch (role)
        {
            case Role.unitEditer:
                UnitEditing();
                break;
            case Role.sceneMover:
                SceneMoving();
                break;
            case Role.panelDisplay:
                PanelChange();
                break;
            case Role.popDisplay:
                PopChange();
                break;
        }
    }

    void UnitEditing()
    {
        switch (actionInput)
        {
            case ActionSplit.unitSelect:
                //unitを選択する際に走る処理
                editer.UnitSelect(this.gameObject);
                break;
            case ActionSplit.unitDecision:
                //選択が終わりプールを作成する時に走る処理
                editer.UnitDecision("mine");
                break;
            case ActionSplit.enemyDecision:
                //敵側のプールを作成する時に走る処理
                break;
            case ActionSplit.unitReset:
                //選択状態などを全てリセット
                editer.UnitReset();
                break;
        }
    }

    //ここだけボタン内で処理を実行する
    void SceneMoving()
    {
        switch (sceneInput)
        {
            case SceneName.tainScene:
                SceneLoader.Instance.SceneMove("testmainScene");
                break;
            case SceneName.playScene:
                SceneLoader.Instance.SceneMove("testplayScene");
                break;
        }
    }

    void PanelChange()
    {
        display.PanelDisplay(panelInput);
    }

    void PopChange()
    {
        display.PopDisplay(popInput);
    }
}
