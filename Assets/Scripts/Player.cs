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
    public GameObject mainCamera;
    public GameObject playerPawn;
    public GameObject bigPawn;
    public GameObject canvasGame;

    public float capacity;
    public Slider capacitySlider;
    public float maxPos;

    void Update()
    { 
        mouseZ = Input.GetAxis("Mouse X");
        capacitySlider.value = capacity;

        if (Input.GetMouseButton(0))
        {
            CanonMovement();
            ClonePawn();
            CloneBigPawn();
        }
    }

    void CanonMovement() // Kanon hareketleri 
    {
        if (transform.position.x <= maxPos && transform.position.x >= -maxPos)
        {
            transform.Translate(0, 0, mouseZ * speed * Time.deltaTime);
        }
        if (transform.position.x > maxPos)
        {
            transform.position = new Vector3(maxPos, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -maxPos)
        {
            transform.position = new Vector3(-maxPos, transform.position.y, transform.position.z);
        }
    }

    void ClonePawn() //Piyon klonlama
    {
        if (Time.time > nextCloneTime)
        {
            Instantiate(playerPawn, new Vector3(transform.position.x, 0.1f, transform.position.z + 0.5f), Quaternion.identity);
            playerSlider();
            nextCloneTime = Time.time + cooldown;
            OnMouseExit();
        }
    }

    void CloneBigPawn() //Büyük piyon klonlama
    {
        if (capacity >= 26)
        {
            Debug.Log("worked");
            Instantiate(bigPawn, new Vector3(transform.position.x, 0.1f, transform.position.z + 0.5f), Quaternion.identity);
            capacity = 0;
        }
    }

    void OnMouseExit() 
    {
        Debug.Log("Mouse is no longer on GameObject.");
    }

    void playerSlider() //Slider renk geçişi
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
