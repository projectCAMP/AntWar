using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Pool;

public class AntPool : MonoBehaviour
{
    //コンポーネント取得が目的
    //スコア表示のテキスト
    [SerializeField] TextMeshProUGUI costTex;
    //壁のオブジェクト
    [SerializeField] GameObject wall;

    //値変更が目的
    //最大のコストを設定
    [SerializeField] int maxCost;
    //生成するobject(今後これがアリになる)
    [SerializeField] GameObject[] createObj;

    //マウス位置を一定間隔で取得するためのカウント
    int count = 0;
    //コストを計算
    int Stock = 0;

    //キャラクターの編成情報をリストで管理
    List<Ant> organizationList = new List<Ant>();
    //オブジェクトプールをリストで管理
    List<ObjectPool<GameObject>> pools = new List<ObjectPool<GameObject>>();
    //消す予定のオブジェクトを順番に持つ(試験用、アリを消すときに使用する)
    List<GameObject> vanishes = new List<GameObject>();
    //vanishのインデックスを持つ
    List<int> vaniIndex = new List<int>();

    //消費するコストの種類を決定する(めんどくさいのでpublic staticにしています)、注意として何もしていない状態を99にしています
    public static int AntIndex = 2;
    void Start()
    {
        for (int i = 0; i < createObj.Length; i++)
        {
            pools.Add(new ObjectPool<GameObject>(createFunc: CreatePooledItem, actionOnGet: OnTakeFromPool, actionOnRelease: OnReturnedToPool, actionOnDestroy: OnDestroyPoolObject, collectionCheck: true, defaultCapacity: 5, maxSize: 10));
        }
        TextWrite();
        for (int i = 0; i < createObj.Length; i++)
        {
            organizationList.Add(createObj[i].GetComponent<Ant>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        //キャラクターを生成
        if (AntIndex != 99)
        {
            Use();
        }

        //壁を生成
        if (Input.GetMouseButtonDown(0))
        {
            //Instantiate(wall, mousePosition(), Quaternion.identity);
        }
    }

    private void FixedUpdate()//updateだと不規則な加算になっていたためfixedに一旦置いてある
    {
        count++;
        if (count % 20 == 0 && Stock < maxCost)
        {
            Stock++;
            TextWrite();
        }
    }
    void TextWrite()
    {
        costTex.text = "Cost = " + Stock.ToString() + "/ " + maxCost;
    }

    //コスト消費&召喚
    void Use()
    {
        if (organizationList[AntIndex].Stats.Cost <= Stock)
        {
            Stock -= organizationList[AntIndex].Stats.Cost;
            TextWrite();
            var gameObject = pools[AntIndex].Get();
            vanishes.Add(gameObject);
            vaniIndex.Add(AntIndex);
            AntIndex = 99;
        }
        else
        {
            AntIndex = 99;
        }
    }
    //マウスポジションの取得
    Vector2 mousePosition()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 target = Camera.main.ScreenToWorldPoint(mousePosition);
        return target;
    }

    //ここからObjectPool用の関数
    private GameObject CreatePooledItem()
    {
        if (AntIndex != 99)
        {
            switch (AntIndex)
            {
                case 0:
                    var defaultName = createObj[0].name;
                    GameObject stock = Instantiate(createObj[0], new Vector3(0, 0, 0), Quaternion.identity);
                    stock.name = defaultName;
                    stock.GetComponent<Ant>().CreateAnt();
                    return stock;
                case 1:
                    var defaultName2 = createObj[1].name;
                    GameObject stock2 = Instantiate(createObj[1], new Vector3(0, 0, 0), Quaternion.identity);
                    stock2.name = defaultName2;
                    stock2.GetComponent<Ant>().CreateAnt();

                    return stock2;
                case 2:
                    var defaultName3 = createObj[2].name;
                    GameObject stock3 = Instantiate(createObj[2], new Vector3(0, 0, 0), Quaternion.identity);
                    stock3.name = defaultName3;
                    stock3.GetComponent<Ant>().CreateAnt();

                    return stock3;
                case 3:
                    var defaultName4 = createObj[3].name;
                    GameObject stock4 = Instantiate(createObj[3], new Vector3(0, 0, 0), Quaternion.identity);
                    stock4.name = defaultName4;
                    stock4.GetComponent<Ant>().CreateAnt();

                    return stock4;
            }
        }
        return createObj[0];
    }

    private void OnTakeFromPool(GameObject gameObject)
    {
        // プールから取得したオブジェクトをアクティブにします
        gameObject.SetActive(true);

        // オブジェクトの位置をランダムに設定します
        const float range = 5f;
        gameObject.transform.position = new Vector3
        (
            x: Random.Range(-range, range),
            y: Random.Range(-range, range),
            z: Random.Range(-range, range)
        );
        // プールから取得したオブジェクトを 2 秒後にプールに戻すコルーチンを実行します
        //StartCoroutine(Process());
    }

    private void OnReturnedToPool(GameObject gameObject)
    {
        // プールに戻すオブジェクトは非アクティブにします
        gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(GameObject gameObject)
    {
        // 最大サイズを超えたオブジェクトはプールに戻さずに削除します
        Destroy(gameObject);
    }
}
    
