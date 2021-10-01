﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject player;
    public GameObject canvasGame;
    public GameObject canvasMenu;
    public GameObject canon;
    public float playPos;
    bool gameStart;


    void Start()
    {
        mainCamera.transform.position = new Vector3(0, 3, -1.5f);
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

        if (gameStart == true)
        {
            GamePlay();
        }

        if (Input.GetMouseButton(0))
        {
            gameStart = true;
        }
    }

    void GamePlay()
    {
        canvasMenu.SetActive(false);
        canvasGame.SetActive(transform);
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, 6, player.transform.position.z - 2.5f);  
       
        if (player.transform.position.z <= playPos)
        {
            player.transform.Translate(0, 1 * Time.deltaTime, 0);
            //canon.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion(0,0,0), 0.1f);
        }
        else
        {
            
        }
    }
}
