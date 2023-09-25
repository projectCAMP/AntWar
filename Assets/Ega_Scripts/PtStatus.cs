using System;
using UnityEngine;

public class PtStatus : MonoBehaviour
{
    private RaycastHit2D[] _raycastHits = new RaycastHit2D[10];
    // public route_num;
    // public num_order;

    public bool CheckSpace(GameObject pt, float radius, float distance, int layerMask)
    {
        bool free = true;
        var posDiff = pt.transform.position - transform.position;
        var direction = posDiff.normalized;
        var hitCount = Physics2D.CircleCastNonAlloc(
                                                    transform.position,
                                                    radius,
                                                    direction,
                                                    _raycastHits,
                                                    distance,
                                                    layerMask
                                                );
        if (hitCount != 0)
            {
                free = false;
            }
        return free;
    }

}
