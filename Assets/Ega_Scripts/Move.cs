using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    protected NavMeshAgent agent;
    protected GameObject WayPoint;
    protected GameObject[] WayPoints;
    protected PtStatus[] ptS;
    protected int num_pt=-1;
    protected int layerMask;
    protected string status = "Stop";
    protected bool isMovingForward = true;
    protected RaycastHit2D[] _raycastHits = new RaycastHit2D[10];
    public int route = 0;
    public bool Enemy = false;
    protected WayPoints routes;

    protected virtual void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;


        if (SceneManager.GetActiveScene().name != "testplayScene")
        {
            return;
        }

        if (Enemy)
        {
            routes = GameObject.Find("EnemyWayPoints").GetComponent<WayPoints>();
        }else
        {
            routes = GameObject.Find("WayPoints").GetComponent<WayPoints>();
        }

        WayPoints = routes.SetRoute(route);

        GameObject t_WayPoint;
        ptS = new PtStatus[WayPoints.Length];
        for (int i=0; i< WayPoints.Length; i++)
        {
            t_WayPoint = WayPoints[i];
            ptS[i] = t_WayPoint.GetComponent<PtStatus>();
        }

        layerMask = 1 << LayerMask.NameToLayer("wall");
    }

    protected virtual void InitialTarget()
    {
        float nearDis = 0;
        float tmpDis = 0;
        GameObject tmpWayPoint = null;
        GameObject nearWayPoint = null;
        int nearNumPt= -1;

        for (int i = 0; i < WayPoints.Length; i++) 
        {
            tmpWayPoint = WayPoints[i];
            // if (tmpWayPoint == WayPoint)
            // {
            //     continue;
            // }
            var posDiff = tmpWayPoint.transform.position - transform.position;
            var distance = posDiff.magnitude;
            var direction = posDiff.normalized;
            var hitCount = Physics2D.RaycastNonAlloc(transform.position, direction, _raycastHits, distance, layerMask);
            if (hitCount != 0)
            {
                continue;
            }
            tmpDis = Vector2.Distance(tmpWayPoint.transform.position, transform.position);
            if (nearDis == 0 || nearDis > tmpDis)
                {
                    nearDis = tmpDis;
                    nearNumPt = i;
                    nearWayPoint = tmpWayPoint;
                }
        }
        WayPoint = nearWayPoint;
        num_pt = nearNumPt;
        status = "Walk";
    }

    void SetForwardPoint()
    {
        GameObject pt;
        PtStatus pt_s;
        if (num_pt > WayPoints.Length -1)
        {
            return;
        }
        for (int i=num_pt+1; i<WayPoints.Length; i++)
        {
            pt = WayPoints[i];
            pt_s = ptS[i];
            if (pt_s.CheckSpace(pt, 0.1f, 0.0f, layerMask))
            {
                num_pt = i;
                WayPoint = WayPoints[i];
                break;
            }
        }
    }

    void SetBackwardPoint()
    {
        GameObject pt;
        PtStatus pt_s;
        if (num_pt == 0)
        {
            return;
        }
        for (int i=num_pt-1; i==0; i--)
        {
            pt = WayPoints[i];
            pt_s = ptS[i];
            if (pt_s.CheckSpace(pt, 0.1f, 0.0f, layerMask))
            {
                num_pt = i;
                WayPoint = WayPoints[i];
                break;
            }
        }
    }

    protected void WalkMove(bool isMovingForward=true)
    {

        if(WayPoint == null || Vector2.Distance(WayPoint.transform.position, transform.position) < 0.5)
        {
            if(isMovingForward)
            {
                SetForwardPoint();
            } else{
                SetBackwardPoint();
            }
        }
        agent.SetDestination(WayPoint.transform.position); 
    }

    protected virtual void Action()
    {

    }

    protected virtual void Update()
    {
        switch (status)
        {
            case "Stop":
                InitialTarget();
                break;
            case "Action":
                Action();
                break;
            case "Walk":
                WalkMove(isMovingForward);
                break;
        }
    }
}