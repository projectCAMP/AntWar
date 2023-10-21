using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class ResourceScript : MonoBehaviour
{
    /// <summary>
    /// 資源の重さ
    /// </summary>
    [SerializeField]
    private float _mass;
    public float Mass => _mass;

    /// <summary>
    /// 資源のスコア
    /// </summary>
    [SerializeField]
    private int _score;
    public int Score => _score;

    private Rigidbody2D _rigid;
    //子オブジェクト判定用
    private int _previousChildCount;

    public GameObject entityToSpawn;
    private ResourceMove _resourceMove;

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _previousChildCount = transform.childCount;
        _resourceMove = GetComponent<ResourceMove>();
    }

    void Update()
    {
        //update内で子オブジェクトの数を監視
        if (transform.childCount != _previousChildCount)
        {
            //変化していたら力を計算
            CaluculateSpeed();
        }
        //子オブジェクトの数を合わせる
        _previousChildCount = transform.childCount;
    }

    /// <summary>
    /// 子オブジェクト全てを見て、力を計算
    /// 一番遅いスピードに合わせる
    /// </summary>
    void CaluculateSpeed()
    {
        //力
        float power = 0f;
        //スピード
        float speed = 100f;

        //子オブジェクト全て見る
        foreach (Transform child in transform)
        {
            var antSpeed = child.GetComponent<CarryAnt>();
            if (antSpeed == null)
            {
                Debug.Log("子オブジェクトにAntUnitスクリプトが含まれていません");
            }
            //力を足す
            Debug.Log(child.name);
            power += antSpeed.Power;
            //スピードを低いものに合わせる
            if (speed > antSpeed.Speed) speed = antSpeed.Speed;
        }

        if (power > 0f)
        {
            _resourceMove.direction = "backward";
            Debug.Log("mikata");
        }
        else if (power == 0f)
        {
            speed = 0;
            _resourceMove.direction = "idol";
        }
        else
        {
            _resourceMove.direction = "forward";
            Debug.Log("teki");
        }
        _resourceMove.speed = speed;
    }

    /// <summary>
    /// 陣地に戻ったら消える
    /// </summary>
    public void OnDisable()
    {
        gameObject.SetActive(false);
    }
}
