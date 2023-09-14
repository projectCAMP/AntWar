using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleBase : MonoBehaviour
{
     private Objectvalue object_value;
     private objectgeneration object_generation;

    int RandomUnit(int unit_sum)
    {
        int unit;
        unit = (int)Random.Range(0, unit_sum);
        return unit;
    }

    // string RandomType()
    // {
    //     // string type;
    //     // return type;
    // }

    // int RandamRoute()
    // {
    //     int route;

    //     return route;
    // }

    void CheckUnit()
    {

    }

    float[] EvaluateRoute(int num_route = 3, int num_type = 2)
    {
        float[] value_route = new float[num_route];

        int index_route;
        int unit_type;
        foreach(GameObject obs in GameObject.FindGameObjectsWithTag("unit"))
        {
            // index_route = obs.GetComponent<Move>().route;
            // value_route[index_route]++;
        }
        return value_route;
    }
    void RandomGeneration()
    {
        // unit_seed = (int)Random.Range();
        // CheckUnit();

    }
    void Update()
    {
        //  timeElapsed += Time.deltaTime;

        // if(timeElapsed >= timeOut) {
        //     if(timeElapsed > Random.Range(0,15))
        //     {
        //         return;
        //     }
        //     RandomGeneration();
        //     timeElapsed = 0.0f;
        // }
    }
}
