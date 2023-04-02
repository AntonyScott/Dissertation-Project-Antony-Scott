using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class HouseInsideCollider : MonoBehaviour
{
    private Player player;
    private Vector3 playerPosition = new Vector3(-1.5f, -2f, 0f);

    [Header("House to load")]
    public string houseToLoad;

    // Reference to the Cinemachine virtual camera
   // public CinemachineVirtualCamera virtualCamera;

    private bool isInside = false;

    void Start()
    {
        //virtualCamera = GameObject.FindGameObjectWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the player enters the house, disable the virtual camera
        if (other.gameObject.CompareTag("Player"))
        {
            //virtualCamera.gameObject.SetActive(false);
            isInside = true;
            SceneManager.LoadScene(houseToLoad);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // If the player exits the house, enable the virtual camera
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = playerPosition;
            isInside = false;
        }
    }

    /*void Update()
    {
        // If the player is outside the house and the virtual camera is not active, activate it
        if (!isInside && !virtualCamera.gameObject.activeInHierarchy)
        {
            virtualCamera.gameObject.SetActive(true);
        }
    }*/
}
