using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Pool;

public class Main : MonoBehaviour
{
    //ここからInspectorでコンポーネントなどを取得している
    //マウス位置確認用のオブジェクトのTransform
    [SerializeField] Transform test;
    //スコア表示のテキスト
    [SerializeField] TextMeshProUGUI scoreTex;
    //生成Object
    [SerializeField] GameObject tester;

    //ここからInspectorでも値を変更できるように設定している
    //最大のコストを設定
    [SerializeField] int maxScore;

    //マウス位置を一定間隔で取得するためのカウント
    int count = 0;
    //コストを計算
    int Stock = 0;

    //キャラクターの編成情報をリストで管理
    List<Character> orgnizationList = new List<Character>();

    //消費するコストの種類を決定する(めんどくさいのでpublic staticにしています)、注意として何もしていない状態を99にしています
    public static int costIndex = 99;

    ObjectPool<GameObject> pools;
    void Start()
    {
        pools = new ObjectPool<GameObject>(createFunc: CreatePooledItem, actionOnGet: OnTakeFromPool, actionOnRelease: OnReturnedToPool, actionOnDestroy: OnDestroyPoolObject, collectionCheck: true, defaultCapacity: 10, maxSize: 100);
        TextWrite();
        for (int i = 0; i < 4; i++)
        {
            orgnizationList.Add(new Character());
        }
    }

    // Update is called once per frame
    void Update()
    {
        //count++;
        if (count % 3 == 0)
        {
            Vector2 mousePosition = Input.mousePosition;
            Vector2 target = Camera.main.ScreenToWorldPoint(mousePosition);
            test.position = target;
        }

        /*if(count % 60 == 0 && Stock < maxScore)
        {
            Stock++;
            TextWrite();
        }*/

        if (costIndex != 99)
        {
            Use();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            var gameObject = pools.Get();
            Debug.Log(pools.CountInactive);
        }
    }

    private void FixedUpdate()//updateだと不規則な加算になっていたためfixedに一旦置いてある
    {
        count++;
        if (count % 20 == 0 && Stock < maxScore)
        {
            Stock++;
            TextWrite();
        }
    }
    void TextWrite()
    {
        scoreTex.text = "Score = " + Stock.ToString() + "/ " + maxScore;
    }

    //コスト消費&召喚
    void Use()
    {
        if (orgnizationList[costIndex].Cost <= Stock)
        {
            Stock -= orgnizationList[costIndex].Cost;
            TextWrite();
            costIndex = 99;
            Debug.Log("yes");
        }
        else
        {
            costIndex = 99;
            Debug.Log("no");
        }
    }

    //ここからObjectPool用の関数
    private GameObject CreatePooledItem()
    {
        return GameObject.CreatePrimitive(PrimitiveType.Cube);
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

        // プールから取得したオブジェクトを 2 秒後にプールに戻すコルーチン
        IEnumerator Process()
        {
            yield return new WaitForSeconds(6);
            pools.Release(gameObject);
        }

        // プールから取得したオブジェクトを 2 秒後にプールに戻すコルーチンを実行します
        StartCoroutine(Process());
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

    private void OnGUI()
    {
        GUILayout.Label($"プール対象のすべてのオブジェクトの数：{pools.CountAll.ToString()}");
        GUILayout.Label($"アクティブなオブジェクトの数：{pools.CountActive.ToString()}");
        GUILayout.Label($"非アクティブなオブジェクトの数：{pools.CountInactive.ToString()}");

        if (GUILayout.Button("生成"))
        {
            var gameObject = pools.Get();
        }
        else if (GUILayout.Button("プールをクリア"))
        {
            pools.Clear();
        }
    }
}
    
