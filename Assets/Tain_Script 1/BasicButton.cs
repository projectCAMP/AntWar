using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicButton : MonoBehaviour
{
    protected string objectType;

    private void Start()
    {
        objectType = this.gameObject.tag;
    }

    public virtual void OnMouseDown()
    {
        Debug.Log("parent");
    }

    public virtual void OnMouseUp()
    {
        Debug.Log("parent");
    }

    public virtual void OnMouseEnter()
    {
        Debug.Log("parent");
    }

    public virtual void OnMouseExit()
    {
        Debug.Log("parent");
    }
}
