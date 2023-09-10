using UnityEngine;
using UnityEngine.AI;

public class Mo : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject WayPoint;
    private GameObject[] WayPoints;
    private PtStatus[] ptS;
    private int num_pt=-1;
    private GameObject target;
    private int layerMask;
    private string status = "Stop";
    private RaycastHit2D[] _raycastHits = new RaycastHit2D[10];
    [SerializeField] private GameObject routes;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        WayPoints r = routes.GetComponent<WayPoints>();
        WayPoints = r.SetRoute(0);

        GameObject t_WayPoint;
        ptS = new PtStatus[WayPoints.Length];
        for (int i=0; i< WayPoints.Length; i++)
        {
            t_WayPoint = WayPoints[i];
            ptS[i] = t_WayPoint.GetComponent<PtStatus>();
        }

        // List<GameObject> WayPoints_List = new List<GameObject>();

        // foreach (GameObject obs in GameObject.FindGameObjectsWithTag("pt"))
        // {
        //     PtStatus ptState = obs.GetComponent<PtStatus>();
        //     if (route == ptState.route_num)
        //     {

        //     }
        // }



        layerMask = 1 << LayerMask.NameToLayer("wall");
    }

	void OnEnable() {
		status = "Stop";
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

    // void SetTarget(Collider collider)
    // {
    //     status = "Chase";
    //     if (collider.CompareTag(target_tag))
    //     {
    //         var posDiff = collider.transform.position - transform.position;
    //         var direction = posDiff.normalized;
    //         var distance = posDiff.magnitude;
    //         var hitCount = Physics2D.RaycastNonAlloc(
    //                                                 transform.position,
    //                                                 direction,
    //                                                 _raycastHits,
    //                                                 distance
    //                                             );
    //         if (hitCount == 1)
    //         {
    //             agent.SetDestination(collider.transform.position);
    //         }
    //     }
    // }

    void WalkMove()
    {

        if (num_pt==-1)
        {
            InitialTarget();
        }

        if (WayPoint == null || Vector2.Distance(WayPoint.transform.position, transform.position) < 0.5)
        {
            SetWayPoints();
        }
    
        agent.SetDestination(WayPoint.transform.position); 
    }

    void ChaseMove()
    {
        if (target == null || Vector2.Distance(target.transform.position, transform.position) > 2)
        {
            status = "Stop";
            target = null;
            return;
        }
        if (Vector2.Distance(target.transform.position, transform.position) < 0.5)
        {
            status = "Action";
            return;
        }

        agent.SetDestination(target.transform.position); 
    }

    protected virtual void Action()
    {

    }

    void SearchTarget(GameObject thisObs,string tag = "resource")
    {
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tag))
        {
            if(Vector2.Distance(obs.transform.position, thisObs.transform.position) < 3)
            {
                Debug.Log(obs.gameObject.tag);
                status = "Chase";
                target = obs;
                break;
            }
        }
    }

    void Update()
    {
        Debug.Log(status);
        if (status != "Action" && status != "Chase")
        {
            SearchTarget(gameObject, "resource");
        }
        switch (status)
        {
            case "Stop":
                InitialTarget();
                break;
            case "Action":
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