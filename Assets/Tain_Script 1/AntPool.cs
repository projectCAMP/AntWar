using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Pool;

public class AntPool : MonoBehaviour
{
    //�R���|�[�l���g�擾���ړI
    //�X�R�A�\���̃e�L�X�g
    [SerializeField] TextMeshProUGUI costTex;
    //�ǂ̃I�u�W�F�N�g
    [SerializeField] GameObject wall;

    //�l�ύX���ړI
    //�ő�̃R�X�g��ݒ�
    [SerializeField] int maxCost;
    //��������object(���ケ�ꂪ�A���ɂȂ�)
    [SerializeField] GameObject[] createObj;

    //�}�E�X�ʒu�����Ԋu�Ŏ擾���邽�߂̃J�E���g
    int count = 0;
    //�R�X�g���v�Z
    int Stock = 0;

    //�L�����N�^�[�̕Ґ��������X�g�ŊǗ�
    List<Ant> organizationList = new List<Ant>();
    //�I�u�W�F�N�g�v�[�������X�g�ŊǗ�
    List<ObjectPool<GameObject>> pools = new List<ObjectPool<GameObject>>();
    //�����\��̃I�u�W�F�N�g�����ԂɎ���(�����p�A�A���������Ƃ��Ɏg�p����)
    List<GameObject> vanishes = new List<GameObject>();
    //vanish�̃C���f�b�N�X������
    List<int> vaniIndex = new List<int>();

    //�����R�X�g�̎�ނ����肷��(�߂�ǂ������̂�public static�ɂ��Ă��܂�)�A���ӂƂ��ĉ������Ă��Ȃ���Ԃ�99�ɂ��Ă��܂�
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
        //�L�����N�^�[�𐶐�
        if (AntIndex != 99)
        {
            Use();
        }

        //�ǂ𐶐�
        if (Input.GetMouseButtonDown(0))
        {
            //Instantiate(wall, mousePosition(), Quaternion.identity);
        }
    }

    private void FixedUpdate()//update���ƕs�K���ȉ��Z�ɂȂ��Ă�������fixed�Ɉ�U�u���Ă���
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

    //�R�X�g����&����
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
    //�}�E�X�|�W�V�����̎擾
    Vector2 mousePosition()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 target = Camera.main.ScreenToWorldPoint(mousePosition);
        return target;
    }

    //��������ObjectPool�p�̊֐�
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
        // �v�[������擾�����I�u�W�F�N�g�� 2 �b��Ƀv�[���ɖ߂��R���[�`�������s���܂�
        //StartCoroutine(Process());
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
}
    
