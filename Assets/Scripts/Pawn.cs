using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pawn : MonoBehaviour
{
    public float speedPawn;
    float towerDistance;
    public Transform tower;
    float waittime = 0.7f;
    NavMeshAgent Agent;


    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        this.gameObject.tag = "Untagged";
        StartCoroutine(ChangeTag());
    }

    void Update()
    {
        PawnMovement();
        PawnFollow();
    }

    void PawnMovement() // hareket
    {
        transform.Translate(0, 0, speedPawn * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void PawnFollow() //rakip merkeze gitmesi için
    {
        towerDistance = Vector3.Distance(transform.position, tower.position);
        
        if (towerDistance <= 3)
        {
            speedPawn = 0;
            Agent.destination = tower.position;
        }
    }

    public IEnumerator ChangeTag()
    {  
        yield return new WaitForSeconds(waittime);
        this.gameObject.tag = "Player";
        //Debug.Log("tag değişti");
    }

    
}
