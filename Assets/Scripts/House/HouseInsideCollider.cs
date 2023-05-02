using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class HouseInsideCollider : MonoBehaviour
{
    [Header("House to load")]
    public string houseToLoad;
    public Vector2 playerPosition;
    public VectorValue playerVector;
    public Player player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !other.isTrigger)
        {
            // Set the VectorValue object to the desired position
            //playerVector.initValue = playerPosition;

            // Load the next scene
            SceneManager.LoadScene(houseToLoad);
            Debug.Log(GameObject.FindGameObjectWithTag("Player").transform.position);
        }
    }

}
