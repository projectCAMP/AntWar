using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BasicButton : MonoBehaviour
{
    //ƒNƒ‰ƒX‚ðŽæ“¾‚·‚é
    protected UnitEditer editer = new UnitEditer();
    protected Display display = new Display();
    protected Information info = new Information();
    public virtual void OnMouseDown()
    {
        //Debug.Log("parent");
    }

    public virtual void OnMouseUp()
    {
        //Debug.Log("parent");
    }

    public virtual void OnMouseEnter()
    {
        //Debug.Log("parent");
    }

    public virtual void OnMouseExit()
    {
        //Debug.Log("parent");
    }
}
