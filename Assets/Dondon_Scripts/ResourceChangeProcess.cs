using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourceChangeProcess : MonoBehaviour
{
    public delegate void ResourceChangedHandler();
    public event ResourceChangedHandler ResourceChanged;

    private int _previousChildCount;

    void Start()
    {
        _previousChildCount = transform.childCount;
    }

    void Update()
    {
        if (transform.childCount != _previousChildCount)
        {
            ResourceChanged.Invoke();
        }
        _previousChildCount = transform.childCount;
    }
}
