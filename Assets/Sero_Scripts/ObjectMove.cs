using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    [SerializeField] float Movespeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Movedirection = this.gameObject.transform.rotation * new Vector3(Movespeed, 0, 0);

        this.gameObject.transform.position += Movedirection * Time.deltaTime;
    }

}
