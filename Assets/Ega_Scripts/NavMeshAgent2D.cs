using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgent2D : MonoBehaviour
{
    [Header("Steering")]
    public float speed = 1.0f;
    public float stoppingDistance = 0;

    [HideInInspector]//常にUnityエディタから非表示
    private Vector2 trace_area=Vector2.zero;
    public Vector2 destination
    {
        get { return trace_area; }
        set
        {
            trace_area = value;
            Debug.Log(transform.position);
            Vector3 pos3 = transform.position;
            Vector2 pos4 = new Vector2(pos3.x, pos3.y);
            Debug.Log(pos4);
            Trace(pos4, value);
        }
    }
    public bool SetDestination(Vector2 target)
    {
        destination = target;
        return true;
    }

    private void Trace(Vector2 current,Vector2 target)
    {
        if (Vector2.Distance(current,target) <= stoppingDistance)
        {
            return;
        }

        // NavMesh に応じて経路を求める
        Debug.Log("aaaaa");
        NavMeshPath path = new NavMeshPath();
        Debug.Log("bbbbbbbb");
        NavMesh.CalculatePath(current, target, NavMesh.AllAreas, path);
        Debug.Log("ccccccc");
        Debug.Log(path.corners);
        Vector2 corner = path.corners[0];
        Debug.Log("dddddddd");
        if (Vector2.Distance(current, corner) <= 0.05f)
        {
            corner = path.corners[1];
        }
        Debug.Log("eeeeeeeee");
        transform.position = Vector2.MoveTowards(current, corner, speed * Time.deltaTime);
    }
}