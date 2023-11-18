using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEffect : MonoBehaviour
{
    [SerializeField] Effectscritableobject ESO;
    [SerializeField] GameObject effectObject;
    Effectscritableobject effectscript;
    [SerializeField] List<GameObject> tapEffectList = new List<GameObject>();
    Vector3 EV;

    // Start is called before the first frame update
    void Start()
    {
        // effectscript = Resources.Load<Effectscritableobject>("Data/Effectscritableobject");

        effectObject = ESO.EffectObject;
    }

    // Update is called once per frame
    void Update()
    {
        Tap();
    }

    void Tap()
    {

        if (Input.GetMouseButtonDown(0))
        {
            EV = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (tapEffectList.Count > 0)
            {

                for (int i = 0; i <= tapEffectList.Count; i++)
                {
                    Debug.Log(i);
                    Debug.Log(tapEffectList.Count);


                    if (tapEffectList.Count <= i && tapEffectList[tapEffectList.Count - 1].activeSelf)
                    {
                        EffectInstantiate();
                        break;
                    }

                    if (!tapEffectList[i].activeSelf)
                    {
                        tapEffectList[i].transform.position = new Vector3(EV.x, EV.y, effectObject.transform.position.z);
                        tapEffectList[i].SetActive(true);
                        break;
                    }
                }

            }

            if (tapEffectList.Count == 0)
            {
                EffectInstantiate();
            }

        }

    }

    void EffectInstantiate()
    {
        GameObject InstantiateObject;

        InstantiateObject = Instantiate(effectObject, new Vector3(EV.x, EV.y, effectObject.transform.position.z), Quaternion.identity);

        tapEffectList.Add(InstantiateObject);
    }

}
