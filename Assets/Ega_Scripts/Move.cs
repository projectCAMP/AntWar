using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject WayPoint;
    [SerializeField] private GameObject[] WayPoints;
    private PtStatus[] ptS;
    private int num_pt=-1;
    private string target_tag = "unit";
    private int layerMask;

    private string status = "Stop";

    private RaycastHit2D[] _raycastHits = new RaycastHit2D[10];

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        GameObject t_WayPoint;
        ptS = new PtStatus[WayPoints.Length];
        for (int i=0; i< WayPoints.Length; i++)
        {
            t_WayPoint = WayPoints[i];
            ptS[i] = t_WayPoint.GetComponent<PtStatus>();
        }

        layerMask = 1 << LayerMask.NameToLayer("wall");
    }

    void InitialTarget()
    {
        float nearDis = 0;
        float tmpDis = 0;
        GameObject tmpWayPoint = null;
        GameObject nearWayPoint = null;
        int nearNumPt= -1;

        for (int i = 0; i < WayPoints.Length; i++) 
        {
            tmpWayPoint = WayPoints[i];
            if (tmpWayPoint == WayPoint)
            {
                continue;
            }
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

    void SetWayPoints()
    {
        GameObject pt;
        PtStatus pt_s;
        if (num_pt > WayPoints.Length -1)
        {
            return;
        }
        Debug.Log(num_pt);
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

    void SetTarget(Collider collider)
    {
        status = "Chase";
        if (collider.CompareTag(target_tag))
        {
            var posDiff = collider.transform.position - transform.position;
            var direction = posDiff.normalized;
            var distance = posDiff.magnitude;
            var hitCount = Physics2D.RaycastNonAlloc(
                                                    transform.position,
                                                    direction,
                                                    _raycastHits,
                                                    distance
                                                );
            if (hitCount == 1)
            {
                agent.SetDestination(collider.transform.position);
            }
        }
    }

    void WalkMove()
    {
        if (num_pt==-1)
        {
            InitialTarget();
        }
        if (WayPoint == null || Vector2.Distance(WayPoint.transform.position, transform.position) < 0.1)
        {
            SetWayPoints();
        }
        // Debug.Log(WayPoint);
        agent.SetDestination(WayPoint.transform.position); 
    }

    void ChaseMove()
    {
        if (WayPoint == null || Vector2.Distance(WayPoint.transform.position, transform.position) < 0.1)
        {
            
        }
        agent.SetDestination(WayPoint.transform.position); 
    }

    void Action()
    {

    }

    void Update()
    {
        switch (status)
        {
            case "Stop":
                InitialTarget();
                break;
            case "Attack":
                Action();
                break;
            case "Walk":
                WalkMove();
                break;
            case "Chase":
                ChaseMove();
                break;
        }
    }
}