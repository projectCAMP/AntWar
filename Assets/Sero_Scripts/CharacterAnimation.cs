using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterAnimation : MonoBehaviour
{
    bool isAnimation = false;
    [SerializeField] Character character;
    [SerializeField] GameObject Body;
    [SerializeField] GameObject Head;
    [SerializeField] GameObject Hand;
    [SerializeField] GameObject Hand2;
    [SerializeField] GameObject Leg;
    [SerializeField] GameObject Tall;

    public enum Character
    {
        Hedgehog,
        Bear,
        Dog,
        Bird
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Animation();
    }

    void Animation()
    {
        switch(character)
        {
            case Character.Hedgehog:
                if (isAnimation == false)
                {
                    Debug.Log("a");

                    isAnimation = true;

                    Body.transform.DOLocalMoveY(0.25f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
                }
                break;

            case Character.Bear:
                if(isAnimation == false)
                {
                    //CharecterHeadPosition = Bearhead.transform.position;

                    isAnimation = true;

                    Body.transform.DOLocalMoveY(0.35f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

                    Head.transform.DOLocalMoveY(0.85f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

                    Hand.transform.DOLocalRotate(new Vector3(0, 0, -45f), 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

                    Leg.transform.DOLocalRotate(new Vector3(0, 0, -10f), 0.75f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

                }
                break;

            case Character.Dog:
                if(isAnimation == false)
                {
                    isAnimation = true;

                    Body.transform.DOLocalMoveY(-1.25f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

                    Head.transform.DOLocalMoveY(-0.8f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

                    Hand.transform.DOLocalRotate(new Vector3(0, 0, -40f), 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

                    Hand2.transform.DOLocalRotate(new Vector3(0, 0, -40f), 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

                    Leg.transform.DOLocalRotate(new Vector3(0, 0, -15f), 0.75f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

                    Tall.transform.DOLocalRotate(new Vector3(0, 0, -45f), 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
                }
                break;

            case Character.Bird:
                if(isAnimation == false)
                {
                    isAnimation = true;

                    Head.transform.DOLocalMoveY(1.1f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

                    Body.transform.DOLocalMoveY(0.5f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

                    Hand.transform.DOLocalRotate(new Vector3(0, 0, 15f), 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

                    Hand2.transform.DOLocalRotate(new Vector3(0, 0, -15f), 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
                }
                break;


        }
    }
}
