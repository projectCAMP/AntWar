using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    [System.Serializable] public class PointsList
    {
        public GameObject[] point_list;
    }
    public List<PointsList> waypoints  = new List<PointsList>();
    public GameObject[] SetRoute(int num_route = 0)
    {
        return waypoints[num_route].point_list;
    }
}