using UnityEngine;
using UnityEngine.AI;

public class UnitMove : Move
{
    protected GameObject target;

    protected override void Start()
    {
        base.Start();
        var antStatus = GetComponent<Ant>();

        agent.speed = antStatus.Speed;
    }

	void OnEnable() {
		status = "Stop";
        Debug.Log("mitiiii"+route);
        WayPoints = routes.SetRoute(route);
        GameObject t_WayPoint;
        ptS = new PtStatus[WayPoints.Length];
        for (int i=0; i< WayPoints.Length; i++)
        {
            t_WayPoint = WayPoints[i];
            ptS[i] = t_WayPoint.GetComponent<PtStatus>();
        }

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

    void ChaseMove()
    {
        if (target == null || Vector2.Distance(target.transform.position, transform.position) > 2)
        {
            status = "Stop";
            target = null;
            return;
        }
        if (Vector2.Distance(target.transform.position, transform.position) < 1.0)
        {
            status = "Action";
            return;
        }

        agent.SetDestination(target.transform.position); 
    }

    // protected virtual void Action()
    // {

    // }

    protected override void Update()
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