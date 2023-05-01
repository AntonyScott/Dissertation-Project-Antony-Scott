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
    }

    void Start()
    {
        totalCoins = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //increments new coin to the coin counter
            totalCoins++;
            //prints out total number of coins collected by the player
            Debug.Log("You currently have " + totalCoins + " Coins.");
            //destroys coin game object
            StartCoroutine(CoinPickup());
            //Destroy(gameObject);
        }
    }

    private IEnumerator CoinPickup()
    {
        animator.Play("Pick-Up_Anim");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
