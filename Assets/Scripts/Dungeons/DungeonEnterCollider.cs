using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class DungeonEnterCollider : MonoBehaviour
{
    private Player player;
    private Vector2 playerPosition = Vector2.zero;

    [Header("Dungeon to load")]
    public string dungeonToLoad;

    private bool isInside = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the player enters the house, disable the virtual camera
        if (other.gameObject.CompareTag("Player"))
        {
            isInside = true;
            SceneManager.LoadScene(dungeonToLoad);
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
}
