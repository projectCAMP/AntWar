using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pools : MonoBehaviour
{
    //生成するアリの内容
    [SerializeField] private GameObject[] ant;

    //プールに用意しておくアリの数
    [SerializeField] private int antAmount;

    //読み取り専用のデータ群を取り込む
    [SerializeField] private Information Info;

    //unitの配列情報(外部でも使用する)
    public static List<List<GameObject>> objs = new List<List<GameObject>>();

    //既に生成したオブジェクトを持っておく
    private List<List<GameObject>> createdObjs = new List<List<GameObject>>();

    //既に生成したアリの種類を持っておく
    private List<int> objType = new List<int>();

    private PartyScriptableObject _partyScriptable;
    private GameObject[] _partyInfo;

    private void Awake()
    {
        _partyScriptable = Resources.Load<PartyScriptableObject>("Data/PartyScriptableObject");
        _partyInfo = _partyScriptable.AntList;
    }

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            objs.Add(new List<GameObject>());
        }
    }

    private void Update()
    {
        if (Datas.units.Count != 0)
        {
            //unitの配列情報をクリアする
            objs.Clear();
            List<int> numberStock = new List<int>();
            for (int i = 0; i < Datas.units.Count; i++)
            {
                int createAntData = Datas.units[i];
                bool end = false;
                for (int j = 0; j < objType.Count; j++)
                {
                    if (createAntData == objType[j])
                    {
                        objs.Add(createdObjs[j]);
                        numberStock.Add(createAntData);
                        end = true;
                    }
                }
                if (end) { continue; }
                List<GameObject> sub = new List<GameObject>();
                for (int j = 0; j < antAmount; j++)
                {
                    var defaultName = ant[createAntData].name;
                    GameObject stock = Instantiate(ant[createAntData], new Vector2(0, 0), Quaternion.identity);
                    stock.name = defaultName;
                    stock.GetComponent<Ant>().CreateAnt();
                    stock.SetActive(false);
                    sub.Add(stock);
                }
                //ストック用と本番用のどちらにもオブジェクトをプールしたリストを追加する
                createdObjs.Add(sub);
                objs.Add(sub);
                objType.Add(Datas.units[i]);
                numberStock.Add(createAntData);
            }

            //編成内容をエディットに反映する
            for (int i = 0; i < numberStock.Count; i++)
            {
                Info.unitDisplay[i].sprite = Info.unitSprites[numberStock[i]];
            }
            Datas.units.Clear();
        }
    }
}