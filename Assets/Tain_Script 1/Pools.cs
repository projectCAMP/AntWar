using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pools: MonoBehaviour
{
    //��������A���̓��e
    [SerializeField] GameObject[] ant;
    //�v�[���ɗp�ӂ��Ă����A���̐�
    [SerializeField] int antAmount;
    //�ǂݎ���p�̃f�[�^�Q����荞��
    [SerializeField] Information Info;
    //unit�̔z����(�O���ł��g�p����)
    public static List<List<GameObject>> objs = new List<List<GameObject>>();
    //���ɐ��������I�u�W�F�N�g�������Ă���
    List<List<GameObject>> createdObjs = new List<List<GameObject>>();
    //���ɐ��������A���̎�ނ������Ă���
    List<int> objType = new List<int>();
    private void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            objs.Add(new List<GameObject>());
        }
    }
    private void Update()
    {   
        if(Datas.units.Count != 0)
        {
            //unit�̔z������N���A����
            objs.Clear();
            List<int> numberStock = new List<int>();
            for(int i = 0; i < Datas.units.Count; i++)
            {
                int createAntData = Datas.units[i];
                bool end = false;
                for(int j = 0; j < objType.Count; j++)
                {
                    if(createAntData == objType[j])
                    {
                        objs.Add(createdObjs[j]);
                        numberStock.Add(createAntData);
                        end = true;
                    }
                }
                if (end) { continue; }
                List<GameObject> sub = new List<GameObject>();
                for(int j = 0; j < antAmount; j++)
                {
                    var defaultName = ant[createAntData].name;
                    GameObject stock = Instantiate(ant[createAntData], new Vector2(0, 0), Quaternion.identity);
                    stock.name = defaultName;
                    stock.GetComponent<Ant>().CreateAnt();
                    stock.SetActive(false);
                    sub.Add(stock);
                }
                //�X�g�b�N�p�Ɩ{�ԗp�̂ǂ���ɂ��I�u�W�F�N�g���v�[���������X�g��ǉ�����
                createdObjs.Add(sub);
                objs.Add(sub);
                objType.Add(Datas.units[i]);
                numberStock.Add(createAntData);
            }

            //�Ґ����e���G�f�B�b�g�ɔ��f����
            for(int i = 0; i < numberStock.Count; i++)
            {
                Debug.Log(numberStock[i]);
                Debug.Log(Info.unitSprites.Length);
                Info.unitDisplay[i].sprite = Info.unitSprites[numberStock[i]];
            }
            Datas.units.Clear();
        }
    }
}
