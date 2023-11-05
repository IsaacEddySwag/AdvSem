using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMoveUp : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject floor1;
    public GameObject floor2;

    public bool Time1 = false;
    public bool Time2 = false;

    // Update is called once per frame
    void Update()
    {
        if(Time1)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, floor1.transform.position.y, transform.position.z), 0.4f * Time.deltaTime);
            if(transform.position == new Vector3(transform.position.x, floor1.transform.position.y, transform.position.z))
            {
                Time1 = false;
            }
        }

        if (Time2)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, floor2.transform.position.y, transform.position.z), 0.4f * Time.deltaTime);
            if (transform.position == new Vector3(transform.position.x, floor2.transform.position.y, transform.position.z))
            {
                Time2 = false;
            }
        }
    }
    
    public void MoveUp()
    {
        Time1 = true;
    }

    public void MoveUp2()
    {
        Time2 = true;
    }
}
