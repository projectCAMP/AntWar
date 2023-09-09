using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Detector : MonoBehaviour
{
    [SerializeField] private TriggerEvent onTriggerStay = new TriggerEvent();
    [SerializeField] private TriggerEvent onTriggerExit = new TriggerEvent();

    private void OnTriggerStay(Collider other)
    {
        onTriggerStay.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        onTriggerExit.Invoke(other);
    }


    [Serializable]
    public class TriggerEvent : UnityEvent<Collider>
    {
    }

}
