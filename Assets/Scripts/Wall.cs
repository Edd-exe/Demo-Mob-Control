using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int multiplyValue;
    public TMPro.TextMeshPro valueTxt;
  

    void Start()
    {
        valueTxt.text = "x" + multiplyValue.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MultiplyPawn(other.gameObject);
        }
    }

    void MultiplyPawn(GameObject CO)  // duvardaki rakama göre piyon çoğalması
    {
        for (int i = 1; i < multiplyValue; i++)
        {
            Instantiate(CO.gameObject,
                new Vector3(CO.transform.position.x - 0.1f,
                            CO.transform.position.y,
                            CO.transform.position.z - 0.1f), Quaternion.identity);
        }
    }
    
}
