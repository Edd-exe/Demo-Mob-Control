using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionWall : MonoBehaviour
{
    public float postionTower;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Pawn>().towerPosZ = postionTower;
        }
    }
}
