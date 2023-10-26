using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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
        if (SceneManager.GetActiveScene().name != "testplayScene")
        {
            return;
        }
		status = "Stop";
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

	}

    void SearchTarget(GameObject thisObs,string tag = "resource")
    {
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tag))
        {
            if(Vector2.Distance(obs.transform.position, thisObs.transform.position) < 3)
            {
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