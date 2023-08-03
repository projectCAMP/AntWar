using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour
{
    public float speed = 2.0f;
    private Vector2 targetPos;
    public GameObject p1;
    public GameObject target;
    private int layerMask;
    private RaycastHit2D[] _raycastHits = new RaycastHit2D[10];

    // void SetAxes(Vector2 targetPos)
    // {
    //     Array.Resize(ref x, x.Length + 1);
    //     x[x.Length - 1] = targetPos.x;
    //     Array.Resize(ref y, y.Length + 1);
    //     y[y.Length - 1] = targetPos.y;
    // }

    // void SplineGetPos(Vector2 current)
    // {
    //     if (baseM.transform.position.x < current.x)
    //     {
    //         SetAxes(baseM.transform.position);
    //     }
    //     if (p1.transform.position.x < current.x)
    //     {
    //         SetAxes(p1.transform.position);
    //     }
    //     if (p2.transform.position.x < current.x)
    //     {
    //         SetAxes(p2.transform.position);
    //     }
    //     if (p3.transform.position.x < current.x)
    //     {
    //         SetAxes(p3.transform.position);
    //     }
    //     if (p4.transform.position.x < current.x)
    //     {
    //         SetAxes(p4.transform.position);
    //     }
    //     if (p5.transform.position.x < current.x)
    //     {
    //         SetAxes(p5.transform.position);
    //     }
    //     if (baseE.transform.position.x < current.x)
    //     {
    //         SetAxes(baseE.transform.position);
    //     }
    // }

    // float Spline_Sc()
    // {
    //     c[0] = c[c.Length]
    // }

    // void Spline_S()
    // {
    //     a = y;
    //     c = 
    //     b = (n_a - a)/(n_x - x) - (n_x - x)*()/3;
    //     d = ()/(3*(n_x - x))
    // }
    // void Spline()
    // {
    //     current = this.transform.position;
    //     var x = new float[1] {current.x};
    //     var y = new float[1] {current.y};
    //     SplineGetPos(current);
    //     var a = new float[x.Length - 1];
    //     var b = new float[x.Length - 1];
    //     var c = new float[x.Length - 1];
    //     var d = new float[x.Length - 1];
    // }

    void SetDestination()
    {
        float tmpDis = 0; 
        float nearDis = 0;
        bool forward = false;
        GameObject targetObj = null;
        foreach (GameObject obs in  GameObject.FindGameObjectsWithTag("pt"))
        {
            var posDiff = obs.transform.position - transform.position;
            var distance = posDiff.magnitude;
            var direction = posDiff.normalized;
            var hitCount = Physics2D.RaycastNonAlloc(transform.position, direction, _raycastHits, distance, layerMask);
            if (target == obs || hitCount != 0)
            {
                continue;
            }
            if (forward && transform.position.x > obs.transform.position.x)
            {
                continue;
            }
            if (!forward && transform.position.x < obs.transform.position.x)
                {
                    forward = true;
                    nearDis = 0;
                }
            tmpDis = Vector2.Distance(obs.transform.position, transform.position);
            if (nearDis == 0 || nearDis > tmpDis)
                        {
                            nearDis = tmpDis;
                            targetObj = obs;
                        }

        }
        target = targetObj;
        Debug.Log(target.name);
    }

    void Liner(Vector2 targetPos)
    {
        Vector2 playerPos = transform.position;
        transform.position = Vector2.MoveTowards(playerPos, targetPos, speed * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        layerMask = 1 << LayerMask.NameToLayer("wall");
        SetDestination();
    }

    // Update is called once per frame
    void Update()
    {
        var posDiff = target.transform.position - transform.position;
        var distance = posDiff.magnitude;
        var direction = posDiff.normalized;
        var hitCount = Physics2D.RaycastNonAlloc(transform.position, direction, _raycastHits, distance, layerMask);
        if (target == null || Vector2.Distance(target.transform.position, transform.position) < 0.5 || hitCount != 0)
        {
            SetDestination();
        }
        Liner(target.transform.position);
    }
}
