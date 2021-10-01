using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    public int multiplyValue;
    //public GameObject playerPawn;
    //float nextCloneTime;
    public TMPro.TextMeshPro valueTxt;
    public int towerNumber;


    void Start()
    {
        valueTxt.text = "x" + multiplyValue.ToString();
    }

    private void OnTriggerEnter(Collider other) 
    /*Duvara çarpıtığında sadece 1 kere çalışmasına bir çözüm bulamadığım için 
    şimdilik bunu  yaptım*/
    {
        switch (towerNumber)
        {
            case 1:
                if (other.gameObject.name == "Player Pawn(Clone)")
                {
                    MultiplyPawn(other.gameObject);
                }
            break;

            case 2:
                if (other.gameObject.name == "Player Pawn(Clone)" ||
                other.gameObject.name == "Player Pawn(Clone)(Clone)")
                {
                    MultiplyPawn(other.gameObject);
                }
            break;
            
            case 3:
                if (other.gameObject.name == "Player Pawn(Clone)" ||
                other.gameObject.name == "Player Pawn(Clone)(Clone)" ||
                other.gameObject.name == "Player Pawn(Clone)(Clone)(Clone)")
                {
                    MultiplyPawn(other.gameObject);
                }
            break;
        }
    }

    void MultiplyPawn(GameObject CO)  // duvardaki rakama göre piyon çoğalması
    {
        //if (Time.time > nextCloneTime)
        //{
            for (int i = 1; i < multiplyValue; i++)
            {
                Instantiate(CO.gameObject,
                    new Vector3(CO.transform.position.x,
                                CO.transform.position.y,
                                CO.transform.position.z - 0.1f), Quaternion.identity);
            }
            //nextCloneTime = Time.time + 0.5f;
        //}

    }
}
