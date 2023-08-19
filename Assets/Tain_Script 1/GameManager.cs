using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[SerializeField] ButtonTap button;
    [SerializeField] GameObject[] ant;
    [SerializeField] int antAmount;
    //unit�̔z����
    List<List<GameObject>> objs = new List<List<GameObject>>();
    //���ɐ��������A���̎�ނ������Ă���
    List<int> objType = new List<int>();
    private void Awake()
    {
    }
    private void Update()
    {
        if(Datas.units != null)
        {
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
                for(int j = 0; j < antAmount; j++)
                {
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
