using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationButton : BasicButton
{
    public override void OnMouseDown()
    {
        Debug.Log("down");
        base.OnMouseDown();
    }

    public override void OnMouseUp()
    {
        Debug.Log("up");
        base.OnMouseUp();
    }

    public override void OnMouseEnter()
    {
        Debug.Log("enter");
        base.OnMouseEnter();
    }

    public override void OnMouseExit()
    {
        Debug.Log("exit");
        base.OnMouseExit();
    }
}