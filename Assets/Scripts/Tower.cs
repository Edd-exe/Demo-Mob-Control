using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int towerHeart;
    public TMPro.TextMeshProUGUI towerHeartTxt;
    public GameControl playPosGC;
    GameObject towerPosZPawn;
    public float nextPos, nextTowerPosZ;
    public GameObject nextLevel;
    public GameObject thisLevel;


    void Update()
    {
        towerHeartTxt.text = towerHeart.ToString();

        if (towerHeart <= 0)
        {
            Debug.Log("win");
            towerHeartTxt.text = "0";
            Destroy(this.gameObject);
            playPosGC.GetComponent<GameControl>().playPos = nextPos;
            //towerPosZPawn.GetComponent<Pawn>().towerPosZ = nextTowerPosZ; 

            thisLevel.transform.Translate(0,-1 * Time.deltaTime,0);
            Destroy(thisLevel.gameObject, 3);
            nextLevel.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            towerHeart -= 1;
            Destroy(other.gameObject);
            //score+=10;
        }
    }

    // 0, 0.45, 13
    // 0, 0.45, 26
    // 0.6, 0.45, 39 / -0.6, 0.45, 39
}
