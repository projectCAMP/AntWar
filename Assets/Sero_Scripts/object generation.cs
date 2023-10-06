using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectgeneration : MonoBehaviour
{
    [SerializeField] int ObjectLimit = 5;
    int generationpositionnumber = 0;
    public int Objectnumber;
    public int Objectvalue;
    GameObject Waypoint;
    List<GameObject> generationPositionList = new List<GameObject>();
    List<GameObject> EnemygenerationPositionList = new List<GameObject>();
    Vector3 generationposition;

    public List<GameObject> vanishes = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Waypoint = GameObject.Find("WayPoints");

        int Length = Waypoint.GetComponent<WayPoints>().waypoints.Count;

        Debug.Log(Length);

        GameObject[] Route;

        for(int i = 0; i < Length; i++)
        {
            Route = Waypoint.GetComponent<WayPoints>().SetRoute(i);

            Debug.Log(Route[0]);

            generationPositionList.Add(Route[0]);

            EnemygenerationPositionList.Add(Route[Route.Length - 1]);

        }
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

            if (objectdirection == 0)
            {
                generationpositionnumber = 0;

                generationposition = generationPositionList[generationpositionnumber].transform.position;

                for(int i = 0; i < Pools.objs[Objectnumber].Count; i++)
                {


                    if (!Pools.objs[Objectnumber][i].activeSelf)
                    {
                        Pools.objs[Objectnumber][i].GetComponent<Move>().route = objectdirection;

                        Pools.objs[Objectnumber][i].SetActive(true);
                        vanishes.Add(Pools.objs[Objectnumber][i]);
                        Pools.objs[Objectnumber][i].GetComponent<Transform>().position = generationposition;
                        Objectvalue += 1;
                        //StartCoroutine("DelayVanish");

                        break;
                    }
                }
            }

            if (objectdirection == 1)
            {
                generationpositionnumber = 1;

                generationposition = generationPositionList[generationpositionnumber].transform.position;

                for (int i = 0; i < Pools.objs[Objectnumber].Count; i++)
                {
                    if (!Pools.objs[Objectnumber][i].activeSelf)
                    {
                        Pools.objs[Objectnumber][i].GetComponent<Move>().route = objectdirection;
                        Pools.objs[Objectnumber][i].SetActive(true);
                        vanishes.Add(Pools.objs[Objectnumber][i]);
                        Pools.objs[Objectnumber][i].GetComponent<Transform>().position = generationposition;
                        Objectvalue += 1;
                        //StartCoroutine("DelayVanish");

                        break;
                    }
                }
            }

            if (objectdirection == 2)
            {
                generationpositionnumber = 2;

                generationposition = generationPositionList[generationpositionnumber].transform.position;

                for (int i = 0; i < Pools.objs[Objectnumber].Count; i++)
                {
                    if (!Pools.objs[Objectnumber][i].activeSelf)
                    {
                        Pools.objs[Objectnumber][i].GetComponent<Move>().route = objectdirection;
                        Pools.objs[Objectnumber][i].SetActive(true);
                        vanishes.Add(Pools.objs[Objectnumber][i]);
                        Pools.objs[Objectnumber][i].GetComponent<Transform>().position = generationposition;
                        Objectvalue += 1;
                        //StartCoroutine("DelayVanish");

                        break;
                    }
                }
            }
            
        }
    }

    /*IEnumerator DelayVanish()
    {
        //3�b��~
        yield return new WaitForSeconds(3);

        vanishes[0].SetActive(false);
        vanishes.RemoveAt(0);

        yield return null;
    }*/
}
