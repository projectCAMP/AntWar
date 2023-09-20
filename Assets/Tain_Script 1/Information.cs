using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Information : MonoBehaviour
{
    //表示関連用の変数(表示の関連上シーン毎に配列を作成しなければならない)
    List<GameObject> menuPanels = new List<GameObject>();
    List<GameObject> gamePanels = new List<GameObject>();

    List<GameObject> menuPops = new List<GameObject>();
    List<GameObject> gamePops = new List<GameObject>();

    public GameObject popParent;

    //panelやpopの識別用enum(呼び出しの名前なので自由に付けてok)
    public enum panelJudges
    {
        none,
        menuPanel,
        gamePanel,
        editPanel,
        stagePanel,
    }
    public enum popJudges
    {
        none,
        settingPop
    }

    //ゲームオブジェクトを検索する際の文字列用(必ず文字が被るように)
    enum panelSearchNames
    {
        None,
        Menu,
        Game,
        Edit,
        Stage,
    }

    enum popSearchNames
    {
        None,
        Setting
    }

    //buttonで使用するためにdictionaryにゲームオブジェクトを登録
    public static Dictionary<panelJudges, GameObject> panelDictionary = new Dictionary<panelJudges, GameObject>();
    public static Dictionary<popJudges, GameObject> popDictionary = new Dictionary<popJudges, GameObject>();

    //表示系GameObject達の親になる名前を定数で表示
    private const string panelParentName = "Canvas";
    private const string popParentName = "Pops";

    //ケースを分けるためにシーンの名前を入力
    private const string menuSceneName = "tainScene";
    private const string gameSceneName = "PlayScene";
    private void Start()
    {
        GetInformation();
    }

    public void GetInformation()
    {
        //親を名前検索で取得
        GameObject panelParent = GameObject.Find(panelParentName);
        popParent = GameObject.Find(popParentName);
        //子オブジェクトの数を取得
        int panelChildCount = panelParent.transform.childCount;
        int popChildCount = popParent.transform.childCount;
        //シーンごとに使用する配列が異なるので取得
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        //参照を行えるように配列にGameObjectを格納
        for (int i = 0; i < panelChildCount; i++)
        {
            switch (sceneName)
            {
                case menuSceneName:
                    menuPanels.Add(panelParent.transform.GetChild(i).gameObject);
                    break;
                case gameSceneName:
                    gamePanels.Add(panelParent.transform.GetChild(i).gameObject);
                    break;

            }
        }
        for (int i = 0; i < popChildCount; i++)
        {
            switch (sceneName)
            {
                case menuSceneName:
                    menuPops.Add(popParent.transform.GetChild(i).gameObject);
                    break;
                case gameSceneName:
                    gamePops.Add(popParent.transform.GetChild(i).gameObject);
                    break;

            }
        }
        panelDictionaring(sceneName, panelChildCount);
        popDictionaring(sceneName, popChildCount);
    }

    //panelのDicitionaryを作成する
    private void panelDictionaring(string splitName, int roopCount)
    {
        //enumの配列についての情報を取得
        var nameArray = Enum.GetNames(typeof(panelSearchNames));
        var valueArray = (panelJudges[])Enum.GetValues(typeof(panelJudges));

        int panelSearchCounter;
        if (menuPanels.Count > gamePanels.Count)
        {
            panelSearchCounter = menuPanels.Count;
        }
        else
        {
            panelSearchCounter = gamePanels.Count;
        }
        //子オブジェクトの分だけdictionaryに登録
        for (int i = 0; i < 1; i++)
        {
            //今回の検索対象の子オブジェクトがenumのどれに対応しているかを配列の添え字で取得
            for (int j = 0; j < panelSearchCounter; j++)
            {
                for (int k = 1; k < nameArray.Length; k++)
                {
                   // Debug.Log(nameArray[k]);
                    if (splitName == menuSceneName && menuPanels[j].name.Contains(nameArray[k].ToString()))
                    {
                        panelDictionary.Add(valueArray[k], menuPanels[j]);
                    }
                    else if (splitName == gameSceneName && gamePanels[j].name.Contains(nameArray[k].ToString()))
                    {
                        panelDictionary.Add(valueArray[k], gamePanels[j]);
                    }
                }
            }
        }
    }

    //panelのDicitionaryを作成する
    private void popDictionaring(string splitName, int roopCount)
    {
        //enumの配列についての情報を取得
        var nameArray = Enum.GetNames(typeof(popSearchNames));
        var valueArray = (popJudges[])Enum.GetValues(typeof(popJudges));

        int popSearchCounter;
        if (menuPops.Count > gamePops.Count)
        {
            popSearchCounter = menuPops.Count;
        }
        else
        {
            popSearchCounter = gamePops.Count;
        }
        //子オブジェクトの分だけdictionaryに登録
        for (int i = 0; i < 1; i++)
        {
            //今回の検索対象の子オブジェクトがenumのどれに対応しているかを配列の添え字で取得
            for (int j = 0; j < popSearchCounter; j++)
            {
                for (int k = 1; k < nameArray.Length; k++)
                {
                    if (splitName == menuSceneName && menuPops[j].name.Contains(nameArray[k].ToString()))
                    {
                        popDictionary.Add(valueArray[k], menuPops[j]);
                    }
                    else if (splitName == gameSceneName && gamePops[j].name.Contains(nameArray[k].ToString()))
                    {
                        popDictionary.Add(valueArray[k], gamePops[j]);
                    }
                }
            }
        }
    }

}
