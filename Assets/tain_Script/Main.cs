using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Pool;

public class Main : MonoBehaviour
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
    List<Character> orgnizationList = new List<Character>();
    //�I�u�W�F�N�g�v�[�������X�g�ŊǗ�
    List<ObjectPool<GameObject>> pools = new List<ObjectPool<GameObject>>();
    //�����\��̃I�u�W�F�N�g�����ԂɎ���(�����p�A�A���������Ƃ��Ɏg�p����)
    List<GameObject> vanishes = new List<GameObject>();
    //vanish�̃C���f�b�N�X������
    List<int> vaniIndex = new List<int>();

    //�����R�X�g�̎�ނ����肷��(�߂�ǂ������̂�public static�ɂ��Ă��܂�)�A���ӂƂ��ĉ������Ă��Ȃ���Ԃ�99�ɂ��Ă��܂�
    public static int characterIndex = 99;
    void Start()
    {
        for (int i = 0; i < createObj.Length; i++)
        {
            pools.Add(new ObjectPool<GameObject>(createFunc: CreatePooledItem, actionOnGet: OnTakeFromPool, actionOnRelease: OnReturnedToPool, actionOnDestroy: OnDestroyPoolObject, collectionCheck: true, defaultCapacity: 5, maxSize: 10));
        }
        TextWrite();
        for (int i = 0; i < createObj.Length; i++)
        {
            orgnizationList.Add(new Character(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //�L�����N�^�[�𐶐�
        if (characterIndex != 99)
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
        if (orgnizationList[characterIndex].Cost <= Stock)
        {
            Stock -= orgnizationList[characterIndex].Cost;
            TextWrite();
            var gameObject = pools[characterIndex].Get();
            vanishes.Add(gameObject);
            vaniIndex.Add(characterIndex);
            characterIndex = 99;
            Debug.Log("yes");
        }
        else
        {
            characterIndex = 99;
            Debug.Log("no");
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
        if (characterIndex != 99)
        {
            switch (characterIndex)
            {
                case 0:
                    return Instantiate(createObj[0], new Vector3(0, 0, 0), Quaternion.identity);
                case 1:
                    return Instantiate(createObj[1], new Vector3(0, 0, 0), Quaternion.identity);
                case 2:
                    return Instantiate(createObj[2], new Vector3(0, 0, 0), Quaternion.identity);
                case 3:
                    return Instantiate(createObj[3], new Vector3(0, 0, 0), Quaternion.identity);
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
        IEnumerator Process()
        {
            yield return new WaitForSeconds(3);
            pools[vaniIndex[0]].Release(vanishes[0]);
            vanishes.RemoveAt(0);
            vaniIndex.RemoveAt(0);
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
}
    
