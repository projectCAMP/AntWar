using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectgeneration : MonoBehaviour
{
    //[SerializeField] List<GameObject> ObjectList;
    [SerializeField] List<GameObject> generationpositionList;
    [SerializeField] int ObjectLimit = 5;
    int generationpositionnumber = 0;
    public int Objectnumber;
    public int Objectvalue;
    Vector3 generationposition;

    List<GameObject> vanishes = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generation(int objectdirection)
    {
        Debug.Log(Objectnumber);
        Debug.Log(Pools.objs.Count);
        if (Objectvalue < ObjectLimit && Pools.objs[Objectnumber] != null)
        {
            
            if(objectdirection == 0)
            {
                generationpositionnumber = 0;

                generationposition = generationpositionList[generationpositionnumber].transform.position;

                for(int i = 0; i < Pools.objs[Objectnumber].Count; i++)
                {
                    if (!Pools.objs[Objectnumber][i].activeSelf)
                    {
                        Pools.objs[Objectnumber][i].SetActive(true);
                        vanishes.Add(Pools.objs[Objectnumber][i]);
                        Pools.objs[Objectnumber][i].GetComponent<Transform>().position = generationposition;
                        StartCoroutine("DelayVanish");
                        break;
                    }
                }
            }

            if (objectdirection == 1)
            {
                generationpositionnumber = 1;

                generationposition = generationpositionList[generationpositionnumber].transform.position;

                for (int i = 0; i < Pools.objs[Objectnumber].Count; i++)
                {
                    if (!Pools.objs[Objectnumber][i].activeSelf)
                    {
                        Pools.objs[Objectnumber][i].SetActive(true);
                        vanishes.Add(Pools.objs[Objectnumber][i]);
                        Pools.objs[Objectnumber][i].GetComponent<Transform>().position = generationposition;
                        StartCoroutine("DelayVanish");
                        break;
                    }
                }
            }

            if (objectdirection == 2)
            {
                generationpositionnumber = 2;

                generationposition = generationpositionList[generationpositionnumber].transform.position;

                for (int i = 0; i < Pools.objs[Objectnumber].Count; i++)
                {
                    if (!Pools.objs[Objectnumber][i].activeSelf)
                    {
                        Pools.objs[Objectnumber][i].SetActive(true);
                        vanishes.Add(Pools.objs[Objectnumber][i]);
                        Pools.objs[Objectnumber][i].GetComponent<Transform>().position = generationposition;
                        StartCoroutine("DelayVanish");
                        break;
                    }
                }
            }
            Objectvalue += 1;
        }
    }
    IEnumerator DelayVanish()
    {
        //3ïbí‚é~
        yield return new WaitForSeconds(3);

        vanishes[0].SetActive(false);
        vanishes.RemoveAt(0);

        yield return null;
    }
}
