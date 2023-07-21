using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Pool;

public class Main : MonoBehaviour
{
    //��������Inspector�ŃR���|�[�l���g�Ȃǂ��擾���Ă���
    //�}�E�X�ʒu�m�F�p�̃I�u�W�F�N�g��Transform
    [SerializeField] Transform test;
    //�X�R�A�\���̃e�L�X�g
    [SerializeField] TextMeshProUGUI scoreTex;
    //����Object
    [SerializeField] GameObject tester;

    //��������Inspector�ł��l��ύX�ł���悤�ɐݒ肵�Ă���
    //�ő�̃R�X�g��ݒ�
    [SerializeField] int maxScore;

    //�}�E�X�ʒu�����Ԋu�Ŏ擾���邽�߂̃J�E���g
    int count = 0;
    //�R�X�g���v�Z
    int Stock = 0;

    //�L�����N�^�[�̕Ґ��������X�g�ŊǗ�
    List<Character> orgnizationList = new List<Character>();

    //�����R�X�g�̎�ނ����肷��(�߂�ǂ������̂�public static�ɂ��Ă��܂�)�A���ӂƂ��ĉ������Ă��Ȃ���Ԃ�99�ɂ��Ă��܂�
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

    private void FixedUpdate()//update���ƕs�K���ȉ��Z�ɂȂ��Ă�������fixed�Ɉ�U�u���Ă���
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

    //�R�X�g����&����
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

    //��������ObjectPool�p�̊֐�
    private GameObject CreatePooledItem()
    {
        return GameObject.CreatePrimitive(PrimitiveType.Cube);
    }

    private void OnTakeFromPool(GameObject gameObject)
    {
        // �v�[������擾�����I�u�W�F�N�g���A�N�e�B�u�ɂ��܂�
        gameObject.SetActive(true);

        // �I�u�W�F�N�g�̈ʒu�������_���ɐݒ肵�܂�
        const float range = 5f;
        gameObject.transform.position = new Vector3
        (
            x: Random.Range(-range, range),
            y: Random.Range(-range, range),
            z: Random.Range(-range, range)
        );

        // �v�[������擾�����I�u�W�F�N�g�� 2 �b��Ƀv�[���ɖ߂��R���[�`��
        IEnumerator Process()
        {
            yield return new WaitForSeconds(6);
            pools.Release(gameObject);
        }

        // �v�[������擾�����I�u�W�F�N�g�� 2 �b��Ƀv�[���ɖ߂��R���[�`�������s���܂�
        StartCoroutine(Process());
    }

    private void OnReturnedToPool(GameObject gameObject)
    {
        // �v�[���ɖ߂��I�u�W�F�N�g�͔�A�N�e�B�u�ɂ��܂�
        gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(GameObject gameObject)
    {
        // �ő�T�C�Y�𒴂����I�u�W�F�N�g�̓v�[���ɖ߂����ɍ폜���܂�
        Destroy(gameObject);
    }

    private void OnGUI()
    {
        GUILayout.Label($"�v�[���Ώۂ̂��ׂẴI�u�W�F�N�g�̐��F{pools.CountAll.ToString()}");
        GUILayout.Label($"�A�N�e�B�u�ȃI�u�W�F�N�g�̐��F{pools.CountActive.ToString()}");
        GUILayout.Label($"��A�N�e�B�u�ȃI�u�W�F�N�g�̐��F{pools.CountInactive.ToString()}");

        if (GUILayout.Button("����"))
        {
            var gameObject = pools.Get();
        }
        else if (GUILayout.Button("�v�[�����N���A"))
        {
            pools.Clear();
        }
    }
}
    
