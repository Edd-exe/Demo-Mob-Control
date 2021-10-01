using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pawn : MonoBehaviour
{
    public float speedPawn;
    float towerDistance;
    public Transform tower;
    NavMeshAgent Agent;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        pawnMovement();
        pawnFollow();
    }

    void pawnMovement() // hareket
    {
        transform.Translate(0, 0, speedPawn * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void pawnFollow() //rakip merkeze gitmesi için
    {
        towerDistance = Vector3.Distance(transform.position, tower.position);
        
        if (towerDistance <= 3)
        {
            speedPawn = 0;
            Agent.destination = tower.position;
        }
    }

    
}
