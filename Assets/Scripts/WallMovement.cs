using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public float minPos, maxPos;
    public float wallSpeed;
    int a = 1; 
    // Update is called once per frame
    void Update()
    {
         transform.Translate( 0, 0, wallSpeed* a* Time.deltaTime);
            if (transform.position.x <= minPos)
            {
                a = 1; 
            }
        
            if (transform.position.x >= maxPos)
            {
                a=-1;
            }
    }
}
