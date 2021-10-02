using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int towerHeart;
    public TMPro.TextMeshProUGUI towerHeartTxt;


    void Update()
    {
        towerHeartTxt.text = towerHeart.ToString();

        if (towerHeart <= 0)
        {
            Debug.Log("win");
            towerHeartTxt.text = "0";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            towerHeart -= 1;
            Destroy(other.gameObject);
        }
    }
}
