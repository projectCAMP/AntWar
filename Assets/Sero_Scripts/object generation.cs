using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectgeneration : MonoBehaviour
{
    [SerializeField] private GameObject WayPoint;
    [SerializeField] bool Enemy;
    [SerializeField] int ObjectLimit = 5;
    int generationpositionnumber = 0;
    public int Objectnumber;
    public int Objectvalue;
    List<GameObject> generationPositionList = new List<GameObject>();
    List<GameObject> EnemygenerationPositionList = new List<GameObject>();
    Vector3 generationposition;
    public List<GameObject> vanishes = new List<GameObject>();
    
    //プールをgeneration内で敵と味方で分岐
    const string myTagName = "mine";
    const string enemyTagName = "enemy";
    string stockTagName;
    // Start is called before the first frame update
    void Start()
    {
        int Length = WayPoint.GetComponent<WayPoints>().waypoints.Count;

        GameObject[] Route;

        for(int i = 0; i < Length; i++)
        {
            Route = WayPoint.GetComponent<WayPoints>().SetRoute(i);


            generationPositionList.Add(Route[0]);

            EnemygenerationPositionList.Add(Route[Route.Length - 1]);

        }

        //タグでこのクラスが自分用なのか敵用なのかを判断する
        stockTagName = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generation(int objectdirection)
    {
        //参照渡しを用いて自身と敵のどちらのプールを使用するかを決める
        ref List<List<GameObject>> stockPooler = ref Pools.objs;
        if(stockTagName == myTagName)
        {
            stockPooler = Pools.objs;
        }
        else if(stockTagName == enemyTagName)
        {
            stockPooler = Pools.enemyObjs;
        }

        if (Objectvalue < ObjectLimit && stockPooler[Objectnumber] != null)
        {

            if (objectdirection == 0)
            {
                generationpositionnumber = 0;

                generationposition = generationPositionList[generationpositionnumber].transform.position;

                for(int i = 0; i < stockPooler[Objectnumber].Count; i++)
                {


                    if (!stockPooler[Objectnumber][i].activeSelf)
                    {
                        stockPooler[Objectnumber][i].GetComponent<Move>().route = objectdirection;
                        stockPooler[Objectnumber][i].GetComponent<Move>().Enemy = Enemy;

                        stockPooler[Objectnumber][i].SetActive(true);
                        if (Enemy == true)
                        {
                            Debug.Log("来ているかい？");
                            stockPooler[Objectnumber][i].GetComponent<Ant>().IsHostile = true;
                            stockPooler[Objectnumber][i].GetComponent<Ant>().CreateAnt(stockPooler[Objectnumber][i].GetComponent<Ant>().Stats);
                        }
                        vanishes.Add(stockPooler[Objectnumber][i]);
                        stockPooler[Objectnumber][i].GetComponent<Transform>().position = generationposition;
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

                for (int i = 0; i < stockPooler[Objectnumber].Count; i++)
                {
                    if (!stockPooler[Objectnumber][i].activeSelf)
                    {
                        stockPooler[Objectnumber][i].GetComponent<Move>().route = objectdirection;
                        stockPooler[Objectnumber][i].GetComponent<Move>().Enemy = Enemy;
                        stockPooler[Objectnumber][i].SetActive(true);
                        if (Enemy == true)
                        {
                            stockPooler[Objectnumber][i].GetComponent<Ant>().IsHostile = true;
                            stockPooler[Objectnumber][i].GetComponent<Ant>().CreateAnt();
                        }
                        vanishes.Add(stockPooler[Objectnumber][i]);
                        stockPooler[Objectnumber][i].GetComponent<Transform>().position = generationposition;
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

                for (int i = 0; i < stockPooler[Objectnumber].Count; i++)
                {
                    if (!stockPooler[Objectnumber][i].activeSelf)
                    {
                        stockPooler[Objectnumber][i].GetComponent<Move>().route = objectdirection;
                        stockPooler[Objectnumber][i].GetComponent<Move>().Enemy = Enemy;
                        stockPooler[Objectnumber][i].SetActive(true);
                        if (Enemy == true)
                        {
                            stockPooler[Objectnumber][i].GetComponent<Ant>().IsHostile = true;
                            stockPooler[Objectnumber][i].GetComponent<Ant>().CreateAnt();
                        }
                        vanishes.Add(stockPooler[Objectnumber][i]);
                        stockPooler[Objectnumber][i].GetComponent<Transform>().position = generationposition;
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
