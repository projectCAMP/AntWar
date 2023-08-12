using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHp : MonoBehaviour
{
    GameObject Objectgeneration;
    [SerializeField] float destorylimittime;
    float destorytime;
    bool value = true;

    // Start is called before the first frame update
    void Start()
    {
        Objectgeneration = GameObject.Find("Objectgenerater");
    }

    // Update is called once per frame
    void Update()
    {
        destorytime += Time.deltaTime;

        if(destorytime >= destorylimittime)
        {
            ObjectDestory();
        }

    }

    void ObjectDestory()
    {
            if (Objectgeneration.GetComponent<objectgeneration>().Objectvalue > 0 && value == true)
            {
                Objectgeneration.GetComponent<objectgeneration>().Objectvalue -= 1;
                value = false;
            }

            Destroy(this.gameObject, 0);

    }
    
}
