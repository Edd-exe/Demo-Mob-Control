using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pawn : MonoBehaviour
{
    public float speedPawn;
    float towerDistance;
    public Transform tower;
    float waittime = 1f;
    NavMeshAgent Agent;
    public float towerPosX, towerPosY, towerPosZ; 


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
        towerDistance = Vector3.Distance(transform.position, new Vector3(towerPosX, towerPosY, towerPosZ));
        
        if (towerDistance <= 3)
        {
            speedPawn = 0;
            Agent.destination = new Vector3(towerPosX, towerPosY, towerPosZ);
        }
    }

    public IEnumerator ChangeTag()  // yeni klonlanan nesneler aynı duvara tekrar çarptığında tekrar klonlanmasın diye
    {  
        yield return new WaitForSeconds(waittime);
        this.gameObject.tag = "Player";
        //Debug.Log("tag değişti");
    }

    private void OnTriggerEnter(Collider other) // Düşman piyon ile çarpışma
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.name == "Dead Pawn")
        {
            Destroy(this.gameObject,1);
        }
    }

    
}
