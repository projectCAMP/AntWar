using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryMove : UnitMove
{

    protected override void Action()
    {
        if (agent.enabled)
        {
            agent.enabled = false;
            transform.parent = target.transform;
        }
    }

}
