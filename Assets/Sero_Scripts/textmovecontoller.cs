using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textmovecontoller : MonoBehaviour
{
    [SerializeField] GameObject movetext;
    [SerializeField] float AnimationSpeed;
    string ObjectTagname;
    TextMeshProGeometryAnimator TG;
    bool MouseEnter = false;
    bool MouseClick = false;

    // Start is called before the first frame update
    void Start()
    {
        TG = movetext.GetComponent<TextMeshProGeometryAnimator>();

        TG.enabled = true;

        ObjectTagname = this.gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {

        if (ObjectTagname == "AnimationText1")
        {
            if (MouseClick == true)
            {

                if (TG.progress == 1)
                {


                    MouseClick = false;
                }
            }

            if (MouseEnter == true && TG.progress < 0.5f)
            {
                TG.progress += AnimationSpeed;
            }

            if (MouseEnter == false && TG.progress > 0 || TG.progress > 0.5f)
            {
                TG.progress -= AnimationSpeed;
            }

        }

        if (ObjectTagname == "AnimationText2")
        {
            if (MouseClick == true)
            {
                TG.progress += AnimationSpeed;

                if (TG.progress == 1)
                {

                }
            }

            if (MouseClick == false)
            {

                if (MouseEnter == true && MouseClick == false && TG.animationData.scale.use == false)
                {
                    TG.progress = 1;
                }

                if (MouseEnter == false && MouseClick == false && TG.animationData.scale.use  == false)
                {
                    TG.progress = 0;
                }

            }
        }

    }

    private void OnMouseEnter()
    {
        MouseEnter = true;

        Debug.Log("a");
    }

    private void OnMouseExit()
    {
        MouseEnter = false;
    }

    public void Clickbutton()
    {
        if (MouseClick == false)
        {

            if (ObjectTagname == "AnimationText1")
            {
                TextClickAnimation1();
            }

            if (ObjectTagname == "AnimationText2")
            {
                TextClickAnimation2();
            }

        }
    }

    void TextClickAnimation1()
    {
        TG.progress = 1f;
    }

    void TextClickAnimation2()
    {
        if (TG.progress == 1)
        {
            MouseClick = true;

            TG.animationData.color.use = false;

            TG.progress = 0;

            TG.animationData.scale.use = true;

        }
    }

}
