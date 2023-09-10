using UnityEngine;
using UnityEngine.AI;

public class ResourceMove : Move
{

    public string direction = "idol";
    public float speed = 0;
    protected override void Start()
    {
        base.Start();
        InitialTarget();
    }

    protected override void InitialTarget()
    {
        float[] nearDis = new float[]{0f,0f};
        float tmpDis = 0;
        GameObject tmpWayPoint = null;
        int[] nearNumPt = new int[]{-1,-1};

        for (int i = 0; i < WayPoints.Length; i++) 
        {
            tmpWayPoint = WayPoints[i];
            var posDiff = tmpWayPoint.transform.position - transform.position;
            var distance = posDiff.magnitude;
            var direction = posDiff.normalized;
            var hitCount = Physics2D.RaycastNonAlloc(transform.position, direction, _raycastHits, distance, layerMask);
            if (hitCount != 0)
            {
                continue;
            }
            tmpDis = Vector2.Distance(tmpWayPoint.transform.position, transform.position);
            if (nearDis[0] == 0 || nearDis[0] > tmpDis)
            {
                nearDis[1] = nearDis[0];
                nearDis[0] = tmpDis;
                nearNumPt[1] = nearNumPt[0];
                nearNumPt[0] = i;
                continue;
            }
            if (nearDis[1] == 0 || nearDis[1] > tmpDis)
            {
                nearDis[1] = tmpDis;
                nearNumPt[1] = i;
            }
        }
        if(direction=="forward")
        {
            num_pt = Mathf.Max(nearNumPt[0], nearNumPt[1]);
            WayPoint = WayPoints[num_pt];
            isMovingForward = true;
        }
        if(direction=="backward")
        {
            num_pt = Mathf.Min(nearNumPt[0], nearNumPt[1]);
            WayPoint = WayPoints[num_pt];
            isMovingForward = false;
        }
        status = "Walk";
    }
    protected override void Update()
    {
        agent.speed = speed;
        if(direction == "idol")
        {
            status = "Stop";
        }
        switch (status)
        {
            case "Stop":
                agent.isStopped = true;
                if(direction !="idol")
                {
                    InitialTarget();
                    agent.isStopped = false;
                }
                break;
            case "Walk":
                WalkMove(isMovingForward);
                break;
        }
    }
}