using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class ResourceScript : MonoBehaviour
{
    /// <summary>
    /// �����̏d��
    /// </summary>
    [SerializeField]
    private float _mass;
    public float Mass => _mass;

    /// <summary>
    /// �����̃X�R�A
    /// </summary>
    [SerializeField]
    private int _score;
    public int Score => _score;

    private Rigidbody2D _rigid;
    //�q�I�u�W�F�N�g����p
    private int _previousChildCount;

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _previousChildCount = transform.childCount;
    }

    void Update()
    {
        //update���Ŏq�I�u�W�F�N�g�̐����Ď�
        if (transform.childCount != _previousChildCount)
        {
            //�ω����Ă�����͂��v�Z
            CaluculateSpeed();
        }
        //�q�I�u�W�F�N�g�̐������킹��
        _previousChildCount = transform.childCount;
    }

    /// <summary>
    /// �q�I�u�W�F�N�g�S�Ă����āA�͂��v�Z
    /// ��Ԓx���X�s�[�h�ɍ��킹��
    /// </summary>
    void CaluculateSpeed()
    {
        //��
        float power = 0f;
        //�X�s�[�h
        float speed = 100f;

        //�q�I�u�W�F�N�g�S�Č���
        foreach (Transform child in transform)
        {
            //�ύX�\��
            var testSpeed = child.GetComponent<TestSpeed>();
            //�͂𑫂�
            power += testSpeed.Power;
            //�X�s�[�h��Ⴂ���̂ɍ��킹��
            if (speed > testSpeed.Speed) speed = testSpeed.Speed;
        }

        if (power > 0f)
        {
            _rigid.velocity = Vector2.right * speed;
        }
        else if (power == 0f)
        {
            _rigid.velocity = Vector2.zero;
        }
        else
        {
            _rigid.velocity = Vector2.left * speed;
        }
    }

    /// <summary>
    /// �w�n�ɖ߂����������
    /// </summary>
    public void OnDisable()
    {
        gameObject.SetActive(false);
    }
}
