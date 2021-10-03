using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int towerHeart;
    public TMPro.TextMeshProUGUI towerHeartTxt;
    public GameControl playPosGC;
    GameObject towerPosZPawn;
    public float nextPos/*, nextTowerPosZ*/;
    public GameObject nextLevel;
    public GameObject thisLevel;
    public int gameScore;
    public TMPro.TextMeshProUGUI gameScoreTxt;
    public GameObject enemyPawn;
    public float nextCloneTime;
    public int multiplyValue;
    public GameObject playerControl;


    void Update()
    {
        towerHeartTxt.text = towerHeart.ToString();
        
        if (playerControl.activeSelf)
        {
           StartCoroutine(CloneObject());
        }
        
        gameScoreTxt.text = gameScore.ToString();
        
        if (towerHeart <= 0)
        {
            Debug.Log("win");
            towerHeartTxt.text = "0";
            Destroy(this.gameObject);
            playPosGC.GetComponent<GameControl>().playPos = nextPos;
            //towerPosZPawn.GetComponent<Pawn>().towerPosZ = nextTowerPosZ; 

            //thisLevel.transform.Translate(0,-20 * Time.deltaTime, 0);
            Destroy(thisLevel.gameObject, 1);
            nextLevel.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            towerHeart -= 1;
            Destroy(other.gameObject);
            gameScore += 10;
            gameScoreTxt.text = gameScore.ToString();
        }
    }

   /* void CloneEnemyPawn()
    {
        
        if (Time.time > nextCloneTime)
        {
            for (int i = 0; i < multiplyValue; i++)
            {
                Instantiate(enemyPawn, new Vector3(
                    Random.Range(-0.2f,0.2f), 
                    0.1f, 
                    transform.position.z - 0.5f - Random.Range(-0.2f,0.2f)), Quaternion.identity);
            }
            nextCloneTime = Time.time + 5;
        }
    }*/

    public IEnumerator CloneObject()
    {
        yield return new WaitForSeconds(4);
        if (Time.time > nextCloneTime)
        {
            for (int i = 0; i < multiplyValue; i++)
            {
                Instantiate(enemyPawn, new Vector3(
                    Random.Range(-0.2f,0.2f), 
                    0.1f, 
                    transform.position.z - 0.5f - Random.Range(-0.2f,0.2f)), Quaternion.identity);
            }
            nextCloneTime = Time.time + 5;
        }
    
    }



    // 0, 0.45, 13
    // 0, 0.45, 26
    // 0.6, 0.45, 39 / -0.6, 0.45, 39
}
