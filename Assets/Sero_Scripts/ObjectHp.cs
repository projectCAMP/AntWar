using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHp : MonoBehaviour
{
    GameObject Objectgeneration;
    [SerializeField] float destorylimittime;
    [SerializeField] float destorytime;
    [SerializeField] List<GameObject> vanishobject;
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
            if (Objectgeneration.GetComponent<objectgeneration>().Objectvalue > 0)
            {
                Objectgeneration.GetComponent<objectgeneration>().Objectvalue -= 1;
            }

             StartCoroutine("Vanish");
            
    }

    IEnumerator Vanish()
    {
        //3ïbí‚é~
        //yield return new WaitForSeconds(1);

        destorytime = 90;

        Objectgeneration.GetComponent<objectgeneration>().vanishes[0].SetActive(false);
        Objectgeneration.GetComponent<objectgeneration>().vanishes.RemoveAt(0);

        yield return null;
    }

}
