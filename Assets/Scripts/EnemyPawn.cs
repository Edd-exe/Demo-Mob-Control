using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPawn : MonoBehaviour
{
 
    void Update()
    {
        transform.Translate(0, 0, 0.75f * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 180, 0); 
    }
    private void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.name == "Dead Pawn")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }    
    }

}
