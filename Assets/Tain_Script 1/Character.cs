using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int Cost = 0;
    public readonly int index = 0;
    public Character(int value)//�R���X�g���N�^�ŃR�X�g���擾
    {
        Cost = 0;
        index = value;
    }
}
