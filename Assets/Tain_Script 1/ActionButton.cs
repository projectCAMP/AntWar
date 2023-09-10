using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButton : BasicButton
{
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        switch (objectType)
        {
            case "SceneMover":
                //SceneLoader.Instance.SceneMove()
                break;
        }
    }

    public override void OnMouseUp()
    {
        base.OnMouseUp();
    }

    public override void OnMouseEnter()
    {
        base.OnMouseEnter();
    }

    public override void OnMouseExit()
    {
        base.OnMouseExit();
    }
}
