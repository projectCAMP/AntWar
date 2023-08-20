using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[SerializeField] ButtonTap button;
    [SerializeField] GameObject[] ant;
    [SerializeField] int antAmount;
    //unit‚Ì”z—ñî•ñ
    public static List<List<GameObject>> objs = new List<List<GameObject>>();
    //Šù‚É¶¬‚µ‚½ƒAƒŠ‚Ìí—Ş‚ğ‚Á‚Ä‚¨‚­
    List<int> objType = new List<int>();
    private void Awake()
    {
    }
    private void Update()
    {
        Debug.Log(Datas.units);
        if(Datas.units != null)
        {
            Debug.Log("$");
            for(int i = 0; i < Datas.units.Count; i++)
            {
                bool end = false;
                for(int j = 0; j < objType.Count; j++)
                {
                    if(Datas.units[i] == objType[j])
                    {
                        end = true;
                    }
                }
                if (end) { continue; }
                List<GameObject> sub = new List<GameObject>();
                Debug.Log("!!");
                for(int j = 0; j < antAmount; j++)
                {
                    Debug.Log("99");
                    GameObject stock = Instantiate(ant[Datas.units[i]], new Vector2(0, 0), Quaternion.identity);
                    stock.SetActive(false);
                    sub.Add(stock);
                }
                objs.Add(sub);
                objType.Add(Datas.units[i]);
            }
            Datas.units.Clear();
        }
    }
}
