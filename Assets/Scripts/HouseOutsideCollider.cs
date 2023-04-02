using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseOutsideCollider : MonoBehaviour
{
    private Player player;
    private Vector3 playerPosition = new Vector3(-1.5f, -2f, 0f);

    [Header("Level to load")]
    public string levelToLoad;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject);
        SceneManager.LoadScene(levelToLoad);
        player.transform.position = playerPosition;
    }
}