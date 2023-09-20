using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonAnimation : BasicButton
{
    string ObjectTagname;
    bool Click = false;
    Vector3 defaultScale;

    private void Start()
    {
        defaultScale = this.transform.localScale;

        ObjectTagname = this.gameObject.tag;
    }

    public override void OnMouseDown()
    {
        ClickAnimation();

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
        if (ObjectTagname == "AnimationText1")
        {
            transform.DOKill();
            transform.localScale = defaultScale;
        }

        Debug.Log("exit");
        base.OnMouseExit();
    }

    void ClickAnimation()
    {
        if (Click == false)
        {

            if (ObjectTagname == "AnimationText2")
            {
                Click = true;
            }

            transform.DOKill();
            transform.localScale = defaultScale;
            transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.25f).OnComplete(() =>
            {
                transform.DOScale(new Vector3(1f, 1f, 1f), 0.25f);
            });

        }
    }
}
