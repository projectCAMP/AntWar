using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectgeneration : MonoBehaviour
{
    [SerializeField] List<GameObject> ObjectList;
    [SerializeField] List<GameObject> generationpositionList;
    [SerializeField] int ObjectLimit = 5;
    int generationpositionnumber = 0;
    public int Objectnumber;
    public int Objectvalue;
    Vector3 generationposition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generation(int objectdirection)
    {
        if (Objectvalue < ObjectLimit)
        {
            
            if(objectdirection == 0)
            {
                generationpositionnumber = 0;

                generationposition = generationpositionList[generationpositionnumber].transform.position;

                Instantiate(ObjectList[Objectnumber], generationposition, Quaternion.Euler(0, 0, 0));
            }

            if (objectdirection == 1)
            {
                generationpositionnumber = 1;

                generationposition = generationpositionList[generationpositionnumber].transform.position;

                Instantiate(ObjectList[Objectnumber], generationposition, Quaternion.Euler(0, 0, 45));
            }

            if (objectdirection == 2)
            {
                generationpositionnumber = 2;

                generationposition = generationpositionList[generationpositionnumber].transform.position;

                Instantiate(ObjectList[Objectnumber], generationposition, Quaternion.Euler(0, 0, -45));
            }

            Objectvalue += 1;
        }
    }
}
