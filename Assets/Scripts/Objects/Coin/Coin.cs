using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int totalCoins = 0;
    private Animator animator;

    void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
        animator = GetComponent<Animator>();
        //DontDestroyOnLoad(this);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //increments new coin to the coin counter
            totalCoins++;
            //prints out total number of coins collected by the player to the debug console
            Debug.Log("You currently have " + totalCoins + " Coins.");
            //plays coin pickup animation then destroys gameobject
            StartCoroutine(CoinPickup());

            PlayerPrefs.SetInt("CoinCount", totalCoins);
            PlayerPrefs.Save();
            //gameState.objectsInScene = SaveManager.GetObjectsInScene();

        }
    }

    private IEnumerator CoinPickup()
    {
        //plays pickup animation, waits for half a second then destroys gameobject
        animator.Play("Pick-Up_Anim");
        FindObjectOfType<AudioManager>().Play("Coin");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
