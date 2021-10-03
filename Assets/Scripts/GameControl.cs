using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject player;
    public GameObject canvasGame;
    public GameObject canvasMenu;
    public Transform canon;
    public float playPos;
    bool gameStart;
    public GameObject playerControl;
    public GameObject deadPawn;


    void Start()
    {
        mainCamera.transform.position = new Vector3(0, 3, -1.5f);
        player.GetComponent<Player>().Update();
    }

    void Update()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = false;

        if (gameStart == true)
        {
            GamePlay();
        }

        if (Input.GetMouseButton(0))
        {
            gameStart = true;
        }
    }

    void GamePlay()  // oyunun başlması için çalışacak fonksiyon
    {
        canvasMenu.SetActive(false);
        canvasGame.SetActive(transform);
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, 6, player.transform.position.z - 2.5f);

        if (player.transform.position.z <= playPos)
        {
            WaitPlay();
        }
        else
        {
            StartPlay();
        }
    }

    void WaitPlay()
    {
        player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(0, player.transform.position.y, player.transform.position.z), 2 * Time.deltaTime);
        player.transform.Translate(0, 1 * Time.deltaTime, 0);
        canon.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), 3 * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), 3 * Time.deltaTime);
        playerControl.SetActive(false);
        deadPawn.SetActive(true);

    }

    void StartPlay()
    {
        canon.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 3 * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 3 * Time.deltaTime);
        playerControl.SetActive(true);
        deadPawn.SetActive(false);
    }

    //5.7
    //18.35
    // 30.35

}
