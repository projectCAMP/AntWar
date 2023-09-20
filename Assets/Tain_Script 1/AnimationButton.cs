using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationButton : BasicButton
{
    [SerializeField] GameObject movetext;
    [SerializeField] float AnimationSpeed;
    string ObjectTagname;
    TextMeshProGeometryAnimator TG;
    bool MouseEnter = false;
    bool ClickPlay = false;
    bool MouseClick = false;

    // Start is called before the first frame update
    void Start()
    {
        TG = movetext.GetComponent<TextMeshProGeometryAnimator>();

        TG.enabled = true;

        ObjectTagname = this.gameObject.tag;
    }

    public override void OnMouseDown()
    {
        if(ObjectTagname == "AnimationText1")
        {
            TG.progress = 1;

            StartCoroutine("AnimationPlay1"); 
        }

        if (ObjectTagname == "AnimationText2")
        {
            TextClickAnimation2();
        }

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
        if (ObjectTagname == "AnimationText1")
        {
            MouseEnter = true;

            StartCoroutine("AnimationPlay1");
        }

        if (ObjectTagname == "AnimationText2")
        {
            TextEnterAnimation2();
        }

        Debug.Log("enter");
        base.OnMouseEnter();
    }

    public override void OnMouseExit()
    {
        if (ObjectTagname == "AnimationText1")
        {
            MouseEnter = false;

            TG.progress = 0;
        }

        if (ObjectTagname == "AnimationText2")
        {
            TextExitAnimation2();
        }

        Debug.Log("exit");
        base.OnMouseExit();
    }

    void TextEnterAnimation2()
    {
        if (ClickPlay == false)
        {

            TG.progress = 1;

            MouseClick = true;

        }
    }

    void TextEnterAnimation1()
    {
        if (ClickPlay == false)
        {
            TG.progress += AnimationSpeed;

            MouseClick = true;
        }
    }

    void TextExitAnimation2()
    {
        if (ClickPlay == false)
        {

            TG.progress = 0;

            MouseClick = false;

        }
    }

    void TextClickAnimation2()
    {
        if (ClickPlay == false)
        {

            if (MouseClick == true)
            {
                TG.animationData.color.use = false;

                TG.progress = 0;

                TG.animationData.scale.use = true;

                StartCoroutine("AnimationPlay2");

                ClickPlay = true;

            }

        }
    }

    IEnumerator AnimationPlay1()
    {
        yield return null;

        if (MouseEnter == true)
        {

            if (TG.progress < 0.49)
            {
                TG.progress += AnimationSpeed;

                StartCoroutine("AnimationPlay1");
            }

            if (TG.progress > 0.5)
            {
                TG.progress -= AnimationSpeed;

                StartCoroutine("AnimationPlay1");
            }

        }

    }

    IEnumerator AnimationPlay2()
    {
        yield return null;

        TG.progress += AnimationSpeed;

        if(TG.progress < 1)
        {
            StartCoroutine("AnimationPlay2");
        }

    }
}