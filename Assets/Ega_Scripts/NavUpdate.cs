using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NavMeshPlus.Components;
using NavMeshPlus.Extensions;
// [RequireComponent(typeof())]
public class NavUpdate : MonoBehaviour
{
    public  NavMeshSurface _surface;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeUpdate());
    }

    // Update is called once per frame
    IEnumerator TimeUpdate()
    {
        while (true)
        {
            _surface.BuildNavMesh();

            yield return new WaitForSeconds(5.0f);
        }
    }
}
