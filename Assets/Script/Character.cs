using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int Cost = 0;
    public Character()//�R���X�g���N�^�ŃR�X�g���擾
    {
        Cost = Random.Range(10, 40);
    }
}
