using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectvalue : MonoBehaviour
{
    [SerializeField] GameObject objectgeneration;
    int ov;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Objectgenerate(int obnumber)
    {
        objectgeneration.GetComponent<objectgeneration>().Objectnumber = obnumber;
    }
}
