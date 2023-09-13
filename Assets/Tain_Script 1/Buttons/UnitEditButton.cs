using System.Collections.Generic;
using UnityEngine;

public class Button : BasicButton
{
    //ボタンの役割を表す分岐
    [SerializeField] Role role;

    //-----------------------------------------
    //unit編成用の分岐
    [SerializeField] UnitRole roleInput;

    public enum Role
    {
        unitEditer,
        sceneMover
    }

    //-----------------------------------------
    public enum UnitRole
    {
        unitSelect,
        unitDecision,
        unitReset
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
        }
    }

    void UnitEditing()
    {
        switch (roleInput)
        {
            case UnitRole.unitSelect:
                //unitを選択する際に走る処理
                editer.UnitSelect();
                break;
            case UnitRole.unitDecision:
                //選択が終わりプールを作成する時に走る処理
                editer.UnitDecision();
                break;
            case UnitRole.unitReset:
                //選択状態などを全てリセット
                editer.UnitReset();
                break;
        }
    }

    void SceneMoving()
    {
        SceneLoader.Instance.SceneMove("NextTestScene");
    }
}
