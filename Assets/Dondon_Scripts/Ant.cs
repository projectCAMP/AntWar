using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{
    /// <summary>
    /// マスタデータ
    /// </summary>
    private AntData _data;
    public AntData Data { get { return _data; } private set { _data = value; } }

    /// <summary>
    /// ステータス
    /// </summary>
    private AntStats _stats;
    public AntStats Stats { get { return _stats; } protected set { _stats = value; } }

    /// <summary>
    /// 敵ならばtrue
    /// </summary>
    [SerializeField]
    private bool _isHostile;
    public bool IsHostile => _isHostile;

    /// <summary>
    /// 現在体力
    /// </summary>
    private int _health;
    public int Health => _health;

    /// <summary>
    /// 現在スピード
    /// </summary>
    private int _speed;
    public int Speed => _speed;

    /// <summary>
    /// 現在パワー
    /// </summary>
    private int _power;
    public int Power => _power;

    /*private void Awake()
    {
        Data = Resources.Load<AntData>("Data/AntData");
        Stats = Data.GetDataByName(gameObject.name);//オブジェクトの名前からステータスを取得
        if (!IsHostile)
        {
            _health = Stats.Health;
            _speed = Stats.Speed;
            _power = Stats.Power;
        }
        else if (IsHostile)
        {
            _health = Stats.Health;
            _speed = Stats.Speed;
            //敵ならばパワーをマイナスに
            _power = -Stats.Power;
        }
    }*/
    public  void CreateAnt()
    {
        Data = Resources.Load<AntData>("Data/AntData");
        Stats = Data.GetDataByName(gameObject.name);//オブジェクトの名前からステータスを取得
        if (!IsHostile)
        {
            _health = Stats.Health;
            _speed = Stats.Speed;
            _power = Stats.Power;
        }
        else if (IsHostile)
        {
            _health = Stats.Health;
            _speed = Stats.Speed;
            //敵ならばパワーをマイナスに
            _power = -Stats.Power;
        }
    }
    protected virtual void Start()
    {

    }
}
