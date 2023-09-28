using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pools : MonoBehaviour
{
    //生成するアリの内容
    //[SerializeField] GameObject[] ant;
    //プールに用意しておくアリの数
    int antAmount = 5;
    //生成するオブジェクトの親name
    string parentName = "ObjectParent";
    //生成するオブジェクトの親
    GameObject objectParent;
    //生成予定の情報
    static List<GameObject> willCreateObjs = new List<GameObject>();
    //unitの配列情報(外部でも使用する)
    public static List<List<GameObject>> objs = new List<List<GameObject>>();
    //既に生成したオブジェクトを持っておく
    static List<List<GameObject>> createdObjs = new List<List<GameObject>>();
    //既に生成したアリの種類を持っておく
    List<GameObject> objType = new List<GameObject>();

    static int over = 0;
    public Pools() { }
    public Pools(string initialize)
    {
        objectParent = GameObject.Find(parentName);
        DontDestroyOnLoad(objectParent);
        for (int i = 0; i < 3; i++)
        {
            objs.Add(new List<GameObject>());
        }
    }
    public void PoolClear()
    {
        willCreateObjs.Clear();
    }
    public void PoolInput(GameObject input)
    {
        willCreateObjs.Add(input);
    }
    public void CreatePool()
    {
        //unitの配列情報をクリアする
        objs.Clear();
        //List<GameObject> numberStock = new List<GameObject>();
        for (int i = 0; i < willCreateObjs.Count; i++)
        {
            GameObject createAntData = willCreateObjs[i];
            bool end = false;
            //既にプールしてあるものと被らないようにチェックする
            for (int j = 0; j < objType.Count; j++)
            {
                if (createAntData == objType[j])
                {
                    objs.Add(createdObjs[j]);
                    //numberStock.Add(createAntData);
                    end = true;
                }
            }
            if (end) { continue; }
            List<GameObject> sub = new List<GameObject>();
            for (int j = 0; j < antAmount; j++)
            {
                var defaultName = willCreateObjs[i].name;
                GameObject stock = Instantiate(willCreateObjs[i], new Vector2(0, 0), Quaternion.identity);
                stock.transform.SetParent(objectParent.transform);
                stock.name = defaultName;
                stock.GetComponent<Ant>().CreateAnt();
                stock.SetActive(false);
                sub.Add(stock);
            }
            //ストック用と本番用のどちらにもオブジェクトをプールしたリストを追加する
            createdObjs.Add(sub);
            objs.Add(sub);
            objType.Add(willCreateObjs[i]);
        }
    }
}
