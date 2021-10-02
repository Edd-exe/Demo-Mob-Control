using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    float mouseZ;
    public float speed;
    float nextCloneTime;
    public float cooldown;
    public GameObject playerPawn;
    public GameObject bigPawn;

    public float capacity;
    public Slider capacitySlider;
    public float maxPos;
    public GameObject player;


    public void Update()
    {
        mouseZ = Input.GetAxis("Mouse X");
        capacitySlider.value = capacity;

        if (Input.GetMouseButton(0))
        {
            CanonMovement();

            if (capacity == 26)
            {
                CloneBigPawn();
            }
            else
            {
                ClonePawn();
            }
        }
    }

    void CanonMovement() // Kanon hareketleri 
    {
        if (player.transform.position.x <= maxPos && player.transform.position.x >= -maxPos)
        {
            player.transform.Translate(0, 0, mouseZ * speed * Time.deltaTime);
        }
        if (player.transform.position.x > maxPos)
        {
            player.transform.position = new Vector3(maxPos, player.transform.position.y, player.transform.position.z);
        }
        if (player.transform.position.x < -maxPos)
        {
            player.transform.position = new Vector3(-maxPos, player.transform.position.y, player.transform.position.z);
        }
    }

    void ClonePawn() //Piyon klonlama
    {
        if (Time.time > nextCloneTime)
        {
            Instantiate(playerPawn, new Vector3(transform.position.x, 0.1f, transform.position.z + 0.5f), Quaternion.identity);
            PlayerSlider();
            nextCloneTime = Time.time + cooldown;
        }
    }

    void CloneBigPawn() //Büyük piyon klonlama
    {
        //if (capacity >= 26)
        //{
        Instantiate(bigPawn, new Vector3(transform.position.x, 0.1f, transform.position.z + 0.5f), Quaternion.identity);
        capacity = 0;
        //}
    }


    void PlayerSlider() //Slider renk geçişi
    {
        capacity += 1;

        if (capacity >= 25)
        {
            capacitySlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            capacitySlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.blue;
        }
    }


}
