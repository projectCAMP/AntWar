using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(ResourceChangeProcess))]
public class ResourceScript : MonoBehaviour
{
    [SerializeField]
    private float _mass;
    public float Mass => _mass;

    [SerializeField]
    private int _score;
    public int Score => _score;

    private Rigidbody2D _rigid;
    private ResourceChangeProcess _changeProcess;

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _changeProcess = GetComponent<ResourceChangeProcess>();
        _changeProcess.ResourceChanged += CaluculateSpeed;
    }

    public void OnDisable()
    {
        gameObject.SetActive(false);
    }

    void CaluculateSpeed()
    {
        float power = 0f;
        float speed = 100f;
        foreach (Transform child in transform)
        {
            var testSpeed = child.GetComponent<TestSpeed>();
            power += testSpeed.Power;
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
}
