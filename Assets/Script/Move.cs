using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] Transform target;
    // private Transform[] WayPoints = [];
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // void SetWayPoint()
    // {

    // }
    // void SetTarget(string state)
    // {

    // }

    // void MoveToTarget(string state)
    // {
    //     if (target == null || Vector2.Distance(target.transform.position, transform.position) < 0.5)
    //     {
    //         SetTarget(string state);
    //     }
    //     agent.SetDestination(target.position);
    // }

    void Update()
    {
        agent.SetDestination(target.position);
    }
}