using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHp : MonoBehaviour
{
    GameObject Objectgeneration;
    float destorylimittime;
    float destorytime;
    bool value = true;

    // Start is called before the first frame update
    void Start()
    {
        Objectgeneration = GameObject.Find("Objectgenerater");

        destorylimittime = this.gameObject.GetComponent<Ant>().Stats.Health;
    }

    // Update is called once per frame
    void Update()
    {
        destorytime += Time.deltaTime;

        if(destorytime >= destorylimittime)
        {
            ObjectVanish();
        }

    }

    void ObjectVanish()
    {
            if (Objectgeneration.GetComponent<objectgeneration>().Objectvalue > 0 && value == true)
            {
                Objectgeneration.GetComponent<objectgeneration>().Objectvalue -= 1;
                value = false;
            }

            StartCoroutine("DelayVanish");

    }

    IEnumerator DelayVanish()
    {
        //3ïbí‚é~
        yield return new WaitForSeconds(3);

        Objectgeneration.GetComponent<objectgeneration>().vanishes[0].SetActive(false);
        Objectgeneration.GetComponent<objectgeneration>().vanishes.RemoveAt(0);

        yield return null;
    }

}
