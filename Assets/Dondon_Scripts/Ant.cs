using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{
    /// <summary>
    /// このキャラのステータス
    /// ScriptableObject使ってるのに結局プレハブごとに設定している奴、妥協
    /// </summary>
    [SerializeField]
    private AntStats _stats;

    public AntStats Stats => _stats;

    /// <summary>
    /// 敵ならばtrue
    /// </summary>
    [SerializeField]
    private bool _isHostile;

    public bool IsHostile => _isHostile;

    /// <summary>
    /// 現在体力
    /// </summary>
    [SerializeField]
    private int _health;

    public int Health => _health;

    /// <summary>
    /// 現在スピード
    /// </summary>
    [SerializeField]
    private int _speed;

    public int Speed => _speed;

    /// <summary>
    /// 現在パワー
    /// </summary>
    [SerializeField]
    private int _power;

    public int Power => _power;

    /// <summary>
    /// エディタ拡張から呼ばれる関数。
    /// 初期状態の体力、スピード、パワーを定義
    /// </summary>
    /// <param name="stats"></param>
    public void CreateAnt(AntStats stats)
    {
        _stats = stats;
        if (!IsHostile)
        {
            _health = stats.Health;
            _speed = stats.Speed;
            _power = stats.Power;
        }
        else if (IsHostile)
        {
            _health = stats.Health;
            _speed = stats.Speed;
            //敵ならばパワーをマイナスに
            _power = -stats.Power;
        }
    }

    /// <summary>
    /// 未使用
    /// </summary>
    public void CreateAnt()
    {
        /*Data = Resources.Load<AntData>("Data/AntData");
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
        }*/
    }

    protected virtual void Start()
    {
    }
}